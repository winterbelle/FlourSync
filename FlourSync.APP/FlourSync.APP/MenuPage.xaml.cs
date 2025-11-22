//using Android.App.AppSearch;
using FlourSync.APP.Models;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Devices;
using System.Collections.ObjectModel;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Windows.Input;
using Microsoft.Maui;


namespace FlourSync.APP;

public partial class MenuPage : ContentPage
{

	//holds the products fetched from the api
	private ObservableCollection<Product> _products = new();

    public ObservableCollection<Product> Products => _products;

    private ObservableCollection<CartItem> _cartItems = new();
    public ObservableCollection<CartItem> CartItems => _cartItems;

    private decimal _cartTotal;

    public ICommand DeleteCommand { get; }

    public bool ShowSwipe => DeviceInfo.Platform == DevicePlatform.Android;
    public bool ShowDeleteButton => DeviceInfo.Platform == DevicePlatform.WinUI || DeviceInfo.Platform == DevicePlatform.MacCatalyst;



    public MenuPage(string? categoryName) //filtering by category
	{
        InitializeComponent();
        BindingContext = this; //this connects XAML to code
        DeleteCommand = new Command<int>(async (cartId) => await DeleteCartItemAsync(cartId));

        LoadProductsAsync(categoryName);
        LoadCartAsync();
    }

    //function to load products to product cards
    private async void LoadProductsAsync(string? categoryName)
    {
        try
        {
            using var client = new HttpClient();

            // Base URL of backend
            string baseURL = "http://192.168.7.122:5275/api/Products";

            // If a category is passed, filter
            if (!string.IsNullOrEmpty(categoryName))
            {
                baseURL += $"?category={Uri.EscapeDataString(categoryName)}";
            }

            var response = await client.GetFromJsonAsync<List<Product>>(baseURL);

            if (response != null)
            {
                _products.Clear(); // wipe current products

                foreach (var item in response)
                {
                    _products.Add(item); // add new ones one by one
                }
            }
        }
        catch (Exception ex)
        {
            // Use platform-specific code to handle DisplayAlert
            if (OperatingSystem.IsWindows() || OperatingSystem.IsMacCatalyst())
            {
                await DisplayAlert("Error", $"Failed to load products.\n\n{ex.Message}", "OK");
            }
            else
            {
                // Handle unsupported platforms gracefully
                System.Diagnostics.Debug.WriteLine($"Error: Failed to load products. {ex.Message}");
            }
        }
    }

    //function that will load the tapped products to the cart.
    private async void LoadCartAsync()
    {
        try
        {
            using var client = new HttpClient();
            var response = await client.GetFromJsonAsync<List<CartItem>>("http://192.168.7.122:5275/api/Cart");

            if (response != null)
            {
                _cartItems.Clear();
                foreach (var item in response)
                {
                    _cartItems.Add(item);
                }

                // Calculate total
                CartTotal = _cartItems.Sum(item => item.PriceAtTime * item.Quantity);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error loading cart: {ex.Message}");
        }
    }


    //function that will save products tapped to cart table.
    private async void OnProductTapped(object sender, TappedEventArgs e)
    {
        // Check if the tapped element is a Frame and has a Products object as its BindingContext
        if (sender is Frame frame && frame.BindingContext is Product tappedProduct)
        {
            // Create an HTTP client to send the POST request to your API
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };
            using var client = new HttpClient(handler);

            var existingItems = await client.GetFromJsonAsync<List<CartItem>>($"http://192.168.7.122:5275/api/Cart?employeeId=1");

            var existing = existingItems?.FirstOrDefault(c => c.ProductID == tappedProduct.ProductID);

            if (existing != null)
            {
                // Already in cart? Increment quantity
                var updatedCartItem = new
                {
                    CartId = existing.CartID, // assume you have it
                    ProductId = existing.ProductID,
                    EmployeeId = existing.EmployeeID,
                    Quantity = existing.Quantity + 1,
                    PriceatTime = existing.PriceAtTime,
                    AddedAt = DateTime.Now
                };

                var jsonUpdate = JsonSerializer.Serialize(updatedCartItem);
                var contentUpdate = new StringContent(jsonUpdate, Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"http://192.168.7.122:5275/api/Cart/{existing.CartID}", contentUpdate);
                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Updated", "Quantity increased 🧮", "OK");
                    LoadCartAsync();
                }
                else
                { 
                    await DisplayAlert("Error", "Couldn't update quantity 💀", "Sad");
                }
            }
            else
            {
                // Not in cart? Add new
                var cartItem = new
                {
                    ProductId = tappedProduct.ProductID,
                    EmployeeID = 1,
                    Quantity = 1,
                    PriceAtTime = tappedProduct.ProductPrice,
                    AddedAt = DateTime.Now
                };

                var json = JsonSerializer.Serialize(cartItem);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("http://192.168.7.122:5275/api/Cart", content);
                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("🛒 Added", $"{tappedProduct.ProductName} added to cart.", "Yum");

                    LoadCartAsync();

                }
                else
                {
                    await DisplayAlert("💥 Error", "Couldn't add to cart.", "Boo");
                }
            }

        }
    }

   
    public decimal CartTotal
    {
        get => _cartTotal;
        set
        {
            _cartTotal = value;
            OnPropertyChanged(nameof(CartTotal));
        }
    }

    private async Task DeleteCartItemAsync(int cartId)
    {
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
        };
        using var client = new HttpClient(handler);

        var response = await client.DeleteAsync($"http://192.168.7.122:5275/api/Cart/{cartId}");

        if (response.IsSuccessStatusCode)
        {
            await DisplayAlert("🗑️ Removed", "Item removed from cart.", "OK");

            LoadCartAsync(); // Refresh cart
        }
        else
        {
            await DisplayAlert("😵", "Couldn't delete the item.", "Oops");
        }
    }

}
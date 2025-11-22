namespace FlourSync.APP;

public partial class DummyPageCategories : ContentPage
{
	public DummyPageCategories()
	{
		InitializeComponent();
	}

    private async void Pastries_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MenuPage("Pastry"));
    }

    private async void Cakes_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MenuPage("Cake"));
    }

    private async void Drinks_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MenuPage("Beverage"));
    }
}
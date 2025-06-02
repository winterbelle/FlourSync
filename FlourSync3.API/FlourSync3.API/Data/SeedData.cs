using Microsoft.EntityFrameworkCore; // Importing EF Core for database operations
using FlourSync3.API.Models; // Importing the models for database entities

namespace FlourSync3.API.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(FlourSyncContext context)
        {
            //ensure database exists
            await context.Database.EnsureCreatedAsync();

            //check for existing products
            if (!context.Products.Any())
            {
                //add sample products
                var products = new List<Products>
                {
                    new Products{ProductName = "Croissant", ProductCategory = "Bakery", ProductPrice = 3.50m, ImagePath = null, StockQty = 10},
                    new Products{ProductName = "Chocolate Croissant", ProductCategory = "Bakery", ProductPrice = 4.00m, ImagePath = null, StockQty = 8},
                    new Products{ProductName = "Almond Croissant", ProductCategory = "Bakery", ProductPrice = 4.50m, ImagePath = null, StockQty = 8},
                    new Products{ProductName = "Corn Muffin", ProductCategory = "Bakery", ProductPrice = 2.00m, ImagePath = null, StockQty = 15},
                    new Products{ProductName = "Blueberry Muffin", ProductCategory = "Bakery", ProductPrice = 2.00m, ImagePath = null, StockQty = 12},
                    new Products{ProductName = "Chocolate Chip Muffin", ProductCategory = "Bakery", ProductPrice = 2.00m, ImagePath = null, StockQty = 10},
                    new Products{ProductName = "Cupcake", ProductCategory = "Cake", ProductPrice = 3.00m, ImagePath = null, StockQty = 20},
                    new Products{ProductName = "Mini Cupcake", ProductCategory = "Cake", ProductPrice = 2.00m, ImagePath = null, StockQty = 20},
                    new Products{ProductName = "8\" Round Cake", ProductCategory = "Cake", ProductPrice = 25.00m, ImagePath = null, StockQty = 5},
                    new Products{ProductName = "7\" Round Cake", ProductCategory = "Cake", ProductPrice = 20.00m, ImagePath = null, StockQty = 5},
                    new Products{ProductName = "4\" Round Cake", ProductCategory = "Cake", ProductPrice = 9.00m, ImagePath = null, StockQty = 5},
                    new Products{ProductName = "3\" Round Cake", ProductCategory = "Cake", ProductPrice = 6.00m, ImagePath = null, StockQty = 5},
                    new Products{ProductName = "Mixed Fruit Tart", ProductCategory = "Pastry", ProductPrice = 6.00m, ImagePath = null, StockQty = 10},
                    new Products{ProductName = "Apple Tart", ProductCategory = "Pastry", ProductPrice = 6.00m, ImagePath = null, StockQty = 10},
                    new Products{ProductName = "Napoleon", ProductCategory = "Pastry", ProductPrice = 5.00m, ImagePath = null, StockQty = 10},
                    new Products{ProductName = "Eclair", ProductCategory = "Pastry", ProductPrice = 4.00m, ImagePath = null, StockQty = 10},
                    new Products{ProductName = "Cookies by lb.", ProductCategory = "Cookies", ProductPrice = 15.00m, ImagePath = null, StockQty = 100},
                    new Products{ProductName = "Big Cookie", ProductCategory = "Cookies", ProductPrice = 2.50m, ImagePath = null, StockQty = 20},
                    new Products{ProductName = "Semolina Bread", ProductCategory = "Bread", ProductPrice = 5.50m, ImagePath = null, StockQty = 15},
                    new Products{ProductName = "Sourdough Bread", ProductCategory = "Bread", ProductPrice = 4.00m, ImagePath = null, StockQty = 15},
                    new Products{ProductName = "French Bread", ProductCategory = "Bread", ProductPrice = 4.50m, ImagePath = null, StockQty = 15},
                    new Products{ProductName = "Challah Bread", ProductCategory = "Bread", ProductPrice = 7.00m, ImagePath = null, StockQty = 10},
                    new Products{ProductName = "Coffee", ProductCategory = "Beverage", ProductPrice = 2.00m, ImagePath = null, StockQty = 50},
                    new Products{ProductName = "Tea", ProductCategory = "Beverage", ProductPrice = 1.50m, ImagePath = null, StockQty = 50},
                    new Products{ProductName = "Hot Chocolate", ProductCategory = "Beverage", ProductPrice = 2.50m, ImagePath = null, StockQty = 30},
                    new Products{ProductName = "Orange Juice", ProductCategory = "Beverage", ProductPrice = 3.00m, ImagePath = null, StockQty = 20},
                    new Products{ProductName = "Apple Juice", ProductCategory = "Beverage", ProductPrice = 3.00m, ImagePath = null, StockQty = 20},
                    new Products{ProductName = "Lemonade", ProductCategory = "Beverage", ProductPrice = 2.50m, ImagePath = null, StockQty = 20},
                    new Products{ProductName = "Iced Tea", ProductCategory = "Beverage", ProductPrice = 2.50m, ImagePath = null, StockQty = 20},
                    new Products{ProductName = "Iced Coffee", ProductCategory = "Beverage", ProductPrice = 3.00m, ImagePath = null, StockQty = 20},
                    new Products{ProductName = "Soda", ProductCategory = "Beverage", ProductPrice = 1.50m, ImagePath = null, StockQty = 50},
                    new Products{ProductName = "Sparkling Water", ProductCategory = "Beverage", ProductPrice = 2.00m, ImagePath = null, StockQty = 30},
                    new Products{ProductName = "Bottled Water", ProductCategory = "Beverage", ProductPrice = 1.00m, ImagePath = null, StockQty = 100}


                };

                await context.Products.AddRangeAsync(products); // Add the sample products to the context
                await context.SaveChangesAsync();
            }

            //check for existing employees
            if (!context.Employees.Any())
            {
                //add sample employees
                var employees = new List<Employees>
                {
                    new Employees{Fname = "Belle", Lname = "Roca", Role = "Manager", PinCode = "2206"},
                    new Employees{Fname = "Joshua", Lname = "Blake", Role = "Baker", PinCode = "2410"},
                    new Employees{Fname = "Jessica", Lname = "Martinez", Role = "Barista", PinCode = "1222"},
                    new Employees{Fname = "Melody", Lname = "Cruz", Role = "Cashier", PinCode = "4276"}
                    };
                await context.Employees.AddRangeAsync(employees); // Add the sample employees to the context
                await context.SaveChangesAsync();

            }
        }
    }
}

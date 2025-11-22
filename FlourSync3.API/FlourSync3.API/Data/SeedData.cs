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

            //======================================
            //Seed Data for Products
            //======================================

            //check for existing products
            if (!context.Products.Any())
            {
                //add sample products
                var products = new List<Products>
                {
                    new Products{ProductName = "Croissant", ProductCategory = "Bakery", ProductPrice = 3.50m, ImagePath = "croissant.jpg", StockQty = 10},
                    new Products{ProductName = "Chocolate Croissant", ProductCategory = "Bakery", ProductPrice = 4.00m, ImagePath = "croissant.jpg", StockQty = 8},
                    new Products{ProductName = "Almond Croissant", ProductCategory = "Bakery", ProductPrice = 4.50m, ImagePath = "croissant.jpg", StockQty = 8},
                    new Products{ProductName = "Corn Muffin", ProductCategory = "Bakery", ProductPrice = 2.00m, ImagePath = "muffins.jpeg", StockQty = 15},
                    new Products{ProductName = "Blueberry Muffin", ProductCategory = "Bakery", ProductPrice = 2.00m, ImagePath = "muffins.jpeg", StockQty = 12},
                    new Products{ProductName = "Chocolate Chip Muffin", ProductCategory = "Bakery", ProductPrice = 2.00m, ImagePath = "muffins.jpeg", StockQty = 10},
                    new Products{ProductName = "Cupcake", ProductCategory = "Cake", ProductPrice = 3.00m, ImagePath = "cupcakes.jpg", StockQty = 20},
                    new Products{ProductName = "Mini Cupcake", ProductCategory = "Cake", ProductPrice = 2.00m, ImagePath = "minicupcakes.jpg", StockQty = 20},
                    new Products{ProductName = "8\" Round Cake", ProductCategory = "Cake", ProductPrice = 25.00m, ImagePath = "cake8inch.jpg", StockQty = 5},
                    new Products{ProductName = "7\" Round Cake", ProductCategory = "Cake", ProductPrice = 20.00m, ImagePath = "cake7inch.jpg", StockQty = 5},
                    new Products{ProductName = "4\" Round Cake", ProductCategory = "Cake", ProductPrice = 9.00m, ImagePath = "cake4inch.jpg", StockQty = 5},
                    new Products{ProductName = "3\" Round Cake", ProductCategory = "Cake", ProductPrice = 6.00m, ImagePath = "cake3inch.png", StockQty = 5},
                    new Products{ProductName = "Mixed Fruit Tart", ProductCategory = "Pastry", ProductPrice = 6.00m, ImagePath = "minipastries.jpg", StockQty = 10},
                    new Products{ProductName = "Apple Tart", ProductCategory = "Pastry", ProductPrice = 6.00m, ImagePath = "minipastries.jpg", StockQty = 10},
                    new Products{ProductName = "Napoleon", ProductCategory = "Pastry", ProductPrice = 5.00m, ImagePath = "minipastries.jpg", StockQty = 10},
                    new Products{ProductName = "Eclair", ProductCategory = "Pastry", ProductPrice = 4.00m, ImagePath = "minipastries.jpg", StockQty = 10},
                    new Products{ProductName = "Cookies by lb.", ProductCategory = "Cookies", ProductPrice = 15.00m, ImagePath = "cookiesbythepound.jpg", StockQty = 100},
                    new Products{ProductName = "Big Cookie", ProductCategory = "Cookies", ProductPrice = 2.50m, ImagePath = "bigcookie.png", StockQty = 20},
                    new Products{ProductName = "Semolina Bread", ProductCategory = "Bread", ProductPrice = 5.50m, ImagePath = "semolinaroll.jpg", StockQty = 15},
                    new Products{ProductName = "Sourdough Bread", ProductCategory = "Bread", ProductPrice = 4.00m, ImagePath = "semolinaroll.jpg", StockQty = 15},
                    new Products{ProductName = "French Bread", ProductCategory = "Bread", ProductPrice = 4.50m, ImagePath = "baguette.jpg", StockQty = 15},
                    new Products{ProductName = "Challah Bread", ProductCategory = "Bread", ProductPrice = 7.00m, ImagePath = "challahbread.jpg", StockQty = 10},
                    new Products{ProductName = "Coffee", ProductCategory = "Beverage", ProductPrice = 2.00m, ImagePath = "minipastries.jpg", StockQty = 50},
                    new Products{ProductName = "Tea", ProductCategory = "Beverage", ProductPrice = 1.50m, ImagePath = "beverage.jpeg", StockQty = 50},
                    new Products{ProductName = "Hot Chocolate", ProductCategory = "Beverage", ProductPrice = 2.50m, ImagePath = "beverage.jpeg", StockQty = 30},
                    new Products{ProductName = "Orange Juice", ProductCategory = "Beverage", ProductPrice = 3.00m, ImagePath = "beverage.jpeg", StockQty = 20},
                    new Products{ProductName = "Apple Juice", ProductCategory = "Beverage", ProductPrice = 3.00m, ImagePath = "beverage.jpeg", StockQty = 20},
                    new Products{ProductName = "Lemonade", ProductCategory = "Beverage", ProductPrice = 2.50m, ImagePath = "beverage.jpeg", StockQty = 20},
                    new Products{ProductName = "Iced Tea", ProductCategory = "Beverage", ProductPrice = 2.50m, ImagePath = "beverage.jpeg", StockQty = 20},
                    new Products{ProductName = "Iced Coffee", ProductCategory = "Beverage", ProductPrice = 3.00m, ImagePath = "beverage.jpeg", StockQty = 20},
                    new Products{ProductName = "Soda", ProductCategory = "Beverage", ProductPrice = 1.50m, ImagePath = "beverage.jpeg", StockQty = 50},
                    new Products{ProductName = "Sparkling Water", ProductCategory = "Beverage", ProductPrice = 2.00m, ImagePath = "beverage.jpeg", StockQty = 30},
                    new Products{ProductName = "Bottled Water", ProductCategory = "Beverage", ProductPrice = 1.00m, ImagePath = "beverage.jpeg", StockQty = 100}


                };

                await context.Products.AddRangeAsync(products); // Add the sample products to the context
                await context.SaveChangesAsync();
            }

            //======================================
            //Seed Data for Employees
            //======================================

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

            //======================================
            //Seed Data for Cart
            //======================================

            //check for existing Cart
            if (!context.Cart.Any())
            {
                //get product references
                var chocCroissant = await context.Products.FirstOrDefaultAsync(p => p.ProductName == "Chocolate Croissant");
                var bigCookie = await context.Products.FirstOrDefaultAsync(p => p.ProductName == "Big Cookie");
                var semolina = await context.Products.FirstOrDefaultAsync(p => p.ProductName == "Semolina Bread");
                var lemonade = await context.Products.FirstOrDefaultAsync(p => p.ProductName == "Lemonade");



                //get employee references 
                var jess = await context.Employees.FirstOrDefaultAsync(e => e.Fname == "Jessica");
                var mel = await context.Employees.FirstOrDefaultAsync(e => e.Fname == "Melody");

                var cartItems = new List<Cart>
                {
                    new Cart { ProductID = chocCroissant.ProductID, EmployeeID = jess.EmployeeID, Quantity = 2, PriceAtTime = chocCroissant.ProductPrice, AddedAt = DateTime.Now.AddHours(-1) },
                    new Cart { ProductID = bigCookie.ProductID, EmployeeID = mel.EmployeeID, Quantity = 1, PriceAtTime = bigCookie.ProductPrice, AddedAt = DateTime.Now.AddHours(-15) },
                    new Cart { ProductID = semolina.ProductID, EmployeeID = jess.EmployeeID, Quantity = 5, PriceAtTime = semolina.ProductPrice, AddedAt = DateTime.Now.AddHours(-17) },
                    new Cart { ProductID = lemonade.ProductID, EmployeeID = mel.EmployeeID, Quantity = 2, PriceAtTime = semolina.ProductPrice, AddedAt = DateTime.Now.AddHours(-22) }
                };

                await context.Cart.AddRangeAsync(cartItems);
                await context.SaveChangesAsync();
            }

            //=====================
            //Seed Data For Orders
            //=====================

            //check for existing orders
            if (!context.Orders.Any())
            {
                var jess = await context.Employees.FirstOrDefaultAsync(e => e.Fname == "Jessica");
                var mel = await context.Employees.FirstOrDefaultAsync(e => e.Fname == "Melody");

                var orders = new List<Orders>
                {
                    new Orders { OrderDate = DateTime.Now.AddDays(-1), EmployeeID = jess.EmployeeID, TotalPrice = 25.99m, PaymentType = "Credit" },
                    new Orders { OrderDate = DateTime.Now.AddDays(-2), EmployeeID = mel.EmployeeID, TotalPrice = 17.50m, PaymentType = "Cash" },
                    new Orders { OrderDate = DateTime.Now.AddDays(-3), EmployeeID = mel.EmployeeID, TotalPrice = 9.25m, PaymentType = "Credit" },
                    new Orders { OrderDate = DateTime.Now.AddDays(-3), EmployeeID = jess.EmployeeID, TotalPrice = 7.00m, PaymentType = "Credit" }

                };

                await context.Orders.AddRangeAsync(orders);
                await context.SaveChangesAsync();
            }

            //=======================
            //Seed Data For OrderItems
            //=======================

            //check for existing OrderItems
            var order1 = await context.Orders.FirstOrDefaultAsync(o => o.OrderID == 4);
            var order2 = await context.Orders.FirstOrDefaultAsync(o => o.OrderID == 3);
            var order3 = await context.Orders.FirstOrDefaultAsync(o => o.OrderID == 2);

            var miniCC = await context.Products.FirstOrDefaultAsync(p => p.ProductName == "Mini Cupcake");
            var sevenCake = await context.Products.FirstOrDefaultAsync(p => p.ProductName == "7\" Round Cake");
            var challah = await context.Products.FirstOrDefaultAsync(p => p.ProductName == "Challah Bread");
            var ccMuffin = await context.Products.FirstOrDefaultAsync(p => p.ProductName == "Chocolate Chip Muffin");

            if (order1 == null || order2 == null || order3 == null ||
                miniCC == null || sevenCake == null || challah == null || ccMuffin == null)
            {
                Console.WriteLine("🚨 Skipping OrderItems seeding due to missing dependencies:");
                if (order1 == null) Console.WriteLine("❌ OrderID 4 not found");
                if (order2 == null) Console.WriteLine("❌ OrderID 7 not found");
                if (order3 == null) Console.WriteLine("❌ OrderID 6 not found");
                if (miniCC == null) Console.WriteLine("❌ Mini Cupcake not found");
                if (sevenCake == null) Console.WriteLine("❌ 7\" Round Cake not found");
                if (challah == null) Console.WriteLine("❌ Challah Bread not found");
                if (ccMuffin == null) Console.WriteLine("❌ Chocolate Chip Muffin not found");
                return;
            }

            var orderItems = new List<OrderItems>
            {
                new OrderItems { OrderID = order3.OrderID, ProductID = miniCC.ProductID, Quantity = 2, PriceEach = miniCC.ProductPrice },
                new OrderItems { OrderID = order2.OrderID, ProductID = challah.ProductID, Quantity = 5, PriceEach = challah.ProductPrice },
                new OrderItems { OrderID = order1.OrderID, ProductID = sevenCake.ProductID, Quantity = 1, PriceEach = sevenCake.ProductPrice },
                new OrderItems { OrderID = order2.OrderID, ProductID = ccMuffin.ProductID, Quantity = 1, PriceEach = ccMuffin.ProductPrice }
            };

            await context.OrderItems.AddRangeAsync(orderItems);
            await context.SaveChangesAsync();


            //=====================
            //Seed Data for InventoryLog
            //=====================


            //check for existing InventoryLog
            if (!context.InventoryLog.Any())
            {
                var chocchipMuffin = await context.Products.FirstOrDefaultAsync(p => p.ProductName == "Chocolate Chip Muffin");
                var croissant = await context.Products.FirstOrDefaultAsync(p => p.ProductName == "Croissant");
                var bigCookie = await context.Products.FirstOrDefaultAsync(p => p.ProductName == "Big Cookie");
                var mft = await context.Products.FirstOrDefaultAsync(p => p.ProductName == "Mixed Fruit Tart");

                var inventory = new List<InventoryLog>
                {
                    new InventoryLog { ProductID = chocchipMuffin.ProductID, ChangeAmount = -7, TimeStamp = DateTime.Now.AddHours(-3), Reason = "Custtomer Purchase" },
                    new InventoryLog { ProductID = croissant.ProductID, ChangeAmount = 5, TimeStamp = DateTime.Now.AddHours(-1), Reason = "Restock" },
                    new InventoryLog { ProductID = mft.ProductID, ChangeAmount = 10, TimeStamp = DateTime.Now.AddMinutes(-30), Reason = "Restock" },
                    new InventoryLog { ProductID = bigCookie.ProductID, ChangeAmount = -3, TimeStamp = DateTime.Now.AddMinutes(-15), Reason = "Customer Purchase" }
                };

                await context.InventoryLog.AddRangeAsync(inventory);
                await context.SaveChangesAsync();
            }
        }
    }
}

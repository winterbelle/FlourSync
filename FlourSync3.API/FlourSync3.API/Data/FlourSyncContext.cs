//here i am immporting the necessary namespaces.
using Microsoft.EntityFrameworkCore; //This is for EF Core functionality
using FlourSync3.API.Models; //This is referencing to our models class. 

namespace FlourSync3.API.Data
{
    public class FlourSyncContext : DbContext //this class inherits from DbContext which is a part of EF Core.
    {
        public FlourSyncContext(DbContextOptions<FlourSyncContext> options) : base(options){ } //Constructor that takes DbContextOptions and passes it to the base class.
        // DbSet properties represent tables in the database. Each DbSet corresponds to a model class.
        //These properties allow us to query and save instances of these entities.
        public DbSet<Products> Products { get; set; } //maps to to the Products table in the database.
        public DbSet<Orders> Orders { get; set; } //maps to the Orders table in the database.
        public DbSet<OrderItems> OrderItems { get; set; } //maps to the OrderItems table in the database.
        public DbSet<Employees> Employees { get; set; } //maps to the Employees table in the database.
        public DbSet<InventoryLog> InventoryLogs { get; set; } //maps to the InventoryLogs table in the database.
    }
}

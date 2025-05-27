using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlourSync3.API.Models
{
    public class OrderItems
    {
        [Key]
        public int ItemID { get; set; } //Primary key for the order item entity.

        [ForeignKey("Orders")]
        public int OrderID { get; set; } //Foreign key to the Orders table.
        public Orders Orders { get; set; } //Navigation property to the Orders entity.

        [ForeignKey("Products")]
        public int ProductID { get; set; } //Foreign key to the Products table.
        public Products Products { get; set; } //Navigation property to the Products entity.

        public int Quantity { get; set; } //Quantity of the product in the order item.

        [Column(TypeName = "decimal(10, 2)")]
        public decimal PriceEach { get; set; } //Price of each product in the order item.

    }
}

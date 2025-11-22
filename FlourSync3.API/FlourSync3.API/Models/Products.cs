//Each model is the C# representation of a table in the database.

using System.ComponentModel.DataAnnotations; //This namespace is used for data annotations, which are attributes that can be applied to classes and properties to define metadata, such as validation rules or display names.
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema; //This namespace is used for collections, such as lists and dictionaries, which are commonly used to store and manage data in C# applications.

namespace FlourSync3.API.Models
{
    //this table represents products for sale. 
    public class Products
    {
        [Key] //This attribute indicates that this property is the primary key of the entity.
        public int ProductID { get; set; } //Primary key for the product entity.

        [Required(ErrorMessage = "Product name is required.")] //This attribute indicates that this property is required and cannot be null.
        [MaxLength(100)] //This attribute specifies the maximum length of the string for this property.
        public string? ProductName { get; set; } //Name of the product.

        [Required(ErrorMessage = "Product Category is required.")]
        public string ProductCategory { get; set; } //e.g. "bread", "pastry", etc.

        [Required]
        [Range(0.01, 999.99)]
        [Column(TypeName = "decimal(10, 2)")] //This attribute specifies the column type in the database for this property, allowing for two decimal places.
        public decimal ProductPrice { get; set; } //using decimal for currency values to avoid floating-point precision issues.
        public string? ImagePath { get; set; } //Path to the product image for UI.
        public int StockQty { get; set; } //Current stock quantity in inventory.

        //one product can appear in many order items.
        public ICollection<OrderItems>? OrderItems { get; set; } //Navigation property for related OrderItems. This allows us to access all order items associated with this product.

    }
}

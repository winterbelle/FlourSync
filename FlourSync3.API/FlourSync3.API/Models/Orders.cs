using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; //This namespace is used for data annotations that are specific to Entity Framework, such as [Key] and [ForeignKey].

namespace FlourSync3.API.Models
{
    //This table represents orders placed by customers.
    public class Orders
    {
        [Key]
        public int OrderID { get; set; } //Primary key for the order entity.
        public DateTime OrderDate { get; set; } = DateTime.Now; //Date and time when the order was placed. Includes a default value of the current date and time.
        
        [ForeignKey("Employees")] //This attribute indicates that the EmployeeID property is a foreign key to the Employees table.
        public int? EmployeeID { get; set; } //Foreign key to the Employee who processed the order.
        public Employees? Employees { get; set; } //Navigation property for the related Employee entity. This allows us to access the employee who processed the order.
        [Column(TypeName = "decimal(10, 2)")] //This attribute specifies the column type in the database for this property.
        public decimal TotalAmount { get; set; } //Total amount for the order.
        public string PaymentType { get; set; } //Payment method used for the order (e.g., "Credit Card", "Cash", etc.).

        public ICollection<OrderItems> OrderItems { get; set; } //Navigation property for related OrderItems. This allows us to access all order items associated with this order.


    }
}

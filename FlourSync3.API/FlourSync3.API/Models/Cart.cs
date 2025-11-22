using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace FlourSync3.API.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        [ForeignKey("Employees")]
        public int EmployeeID { get; set; }

        public Employees? Employees { get; set; }

        [ForeignKey("Products")]
        public int ProductID { get; set; }

        public Products? Product { get; set; }

        public int Quantity { get; set; }

        [Range(0.01, 999.99)]
        [Column(TypeName = "decimal(10,2)")]
        public decimal PriceAtTime { get; set; }

        public DateTime AddedAt { get; set; } = DateTime.Now;

    }
}

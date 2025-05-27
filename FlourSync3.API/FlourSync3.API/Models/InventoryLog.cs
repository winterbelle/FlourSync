using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace FlourSync3.API.Models
{
    public class InventoryLog
    {
        [Key]
        public int LogID { get; set; } //Primary key for the inventory log entry.

        [ForeignKey("Products")]
        public int ProductID { get; set; } //Foreign key to the Products table.
        public Products Products { get; set; } //Navigation property to the Products entity.
        public string ChangeAmount { get; set; } //Amount of change in stock (e.g., "+5" for addition, "-3" for removal).
        public DateTime Timestamp { get; set; } = DateTime.Now; //Timestamp of when the inventory change occurred. Defaults to the current date and time.
        public string Reason { get; set; } //Reason for the inventory change (e.g., "Restock", "Sale", "Adjustment").

    }
}

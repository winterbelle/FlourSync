using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text.Json.Serialization;

namespace FlourSync3.API.Models
{
    public class InventoryLog
    {
        [Key]
        public int LogID { get; set; } //Primary key for the inventory log entry.

        [ForeignKey("Products")]
        public int ProductID { get; set; } //Foreign key to the Products table.

        [JsonIgnore] // This attribute is used to prevent circular references during serialization.
        public Products? Products { get; set; } //Navigation property to the Products entity.

        [Range(-1000, 1000)]
        public int ChangeAmount { get; set; } //Amount of change in stock (e.g., "+5" for addition, "-3" for removal).
        public DateTime TimeStamp { get; set; } = DateTime.Now; //Timestamp of when the inventory change occurred. Defaults to the current date and time.
        public string? Reason { get; set; } //Reason for the inventory change (e.g., "Restock", "Sale", "Adjustment").

    }
}


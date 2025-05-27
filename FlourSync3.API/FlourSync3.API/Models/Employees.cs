using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace FlourSync3.API.Models
{
    public class Employees
    {
        [Key]
        public int EmployeeID { get; set; } //Primary key for the employee entity.

        [Required]
        [MaxLength(50)] //Maximum length for the first name.
        public string Fname { get; set; } //First name of the employee.

        [Required]
        [MaxLength(50)] //Maximum length for the last name.
        public string Lname { get; set; } //Last name of the employee.

        [Required]
        public string Role { get; set; } //Role of the employee (e.g., "Manager", "Cashier", etc.).

        [Required]
        [StringLength(4, MinimumLength = 4)]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "PIN must be exactly 4 digits")]
        public string PinCode { get; set; } //PIN code for the employee, used for authentication.

    }
}

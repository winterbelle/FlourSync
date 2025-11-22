using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlourSync.APP.Models
{
    public class CartItem
    {
        public int CartID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int EmployeeID { get; set; }
        public int Quantity { get; set; }
        public decimal PriceAtTime { get; set; }
        public DateTime AddedAt { get; set; }
    }
}

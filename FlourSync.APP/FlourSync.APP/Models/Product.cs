using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlourSync.APP.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? ProductCategory { get; set; }
        public decimal ProductPrice { get; set; }
        public string? ImagePath { get; set; }
        public int StockQty { get; set; }
    }
}

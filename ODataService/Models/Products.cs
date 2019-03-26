using System.Collections.Generic;

namespace ODataService.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } 
        public decimal? UnitPrice { get; set; }
        public byte[] Picture { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
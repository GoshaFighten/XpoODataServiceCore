using System.Collections.Generic;

namespace ODataService.Models
{
    public class Order : BaseDocument
    {
        public OrderStatus OrderStatus { get; set; }
        public Customer Customer { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
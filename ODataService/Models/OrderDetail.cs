namespace ODataService.Models
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
    }
}
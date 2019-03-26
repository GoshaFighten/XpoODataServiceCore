using System.Collections.Generic;

namespace ODataService.Models
{
    public class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public List<Order> Orders { get; set; }
        public List<Contract> Contracts { get; set; }
    }
}
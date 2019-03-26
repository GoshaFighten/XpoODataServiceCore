namespace ODataService.Models
{
    public class Contract : BaseDocument
    {
        public string Number { get; set; }
        public Customer Customer { get; set; }
    }
}
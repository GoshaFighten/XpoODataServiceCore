using System;
using System.Collections.Generic;

namespace ODataService.Models
{
    public abstract class BaseDocument
    {
        public int ID { get; set; }
        public DateTime? Date { get; set; }
        public List<BaseDocument> LinkedDocuments { get; set; }
        public BaseDocument ParentDocument { get; set; }
    }
}
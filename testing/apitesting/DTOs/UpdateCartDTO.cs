using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apitesting.DTOs
{
    public class UpdateCartDTO
    {
        public bool IsDigitalProduct { get; set; }
        public bool IsShippedProduct { get; set; }
        public int ProductId { get; set; }
        public int StyleId { get; set; }
        public string TaxCodeKey { get; set; }
        public bool AddQuantity { get; set; }
        public bool RemoveQuantity { get; set; }
    }
}

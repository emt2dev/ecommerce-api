using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apitesting.DTOs
{
    public class NewProductModelDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; } // Continuous string separated by commas
        public double Price { get; set; }
        public string TaxCodeKey { get; set; }
        public bool IsDigitalProduct { get; set; }
        public bool IsShippedProduct { get; set; }
    }
}

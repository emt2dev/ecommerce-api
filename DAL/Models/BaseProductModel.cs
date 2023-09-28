using api.DAL.Enumerables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace api.DAL.Models
{
    public abstract class BaseProductModel
    {
        // Starts at 0 when creating new
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; } // Continuous string separated by commas
        // Dates
        public DateTime DateCreated { get; set; }
        public DateTime? DateAvailableForShipping { get; set; }
        public DateTime? DateAvailableForDownload { get; set; }
        public DateTime? DateUnavailable { get; set; }
        // Boolean
        public bool IsAvailableForNewCarts { get; set; }
        public bool IsLimitedTimeOnly { get; set; }
        public bool IsPopular { get; set; }
        public bool IsComingSoon { get; set; }
        public bool IsDigitalProduct { get; set; }
        public bool IsShippedProduct { get; set; }
        // Discount
        public double? DiscountedRate { get; set; }
        // Tax Code
        public string TaxCode { get; set; }
        public string Category { get; set; }
    }
}

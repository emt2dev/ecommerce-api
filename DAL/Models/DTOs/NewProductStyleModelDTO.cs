using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.DAL.DTOs
{
    public class NewProductStyleModelDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public double CurrentPrice { get; set; }
        public IList<string>? ImageUrls { get; set; }
        // Packaged dimensions and weight
        public double? Weight { get; set; }
        public double? LengthInInches { get; set; }
        public double? WidthInInches { get; set; }
        public double? DepthInInches { get; set; }
        public bool IsDigitalOnly { get; set; }
    }
}

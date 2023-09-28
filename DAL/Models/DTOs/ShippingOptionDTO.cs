using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.DAL.DTOs
{
    public class ShippingOptionDTO
    {
        public string Name { get; set; }
        public string Carrier { get; set; }
        public double Cost { get; set; }
        public double Area { get; set; }
        public double MaxWeight { get; set; }
        public string DeliveryExpectation { get; set; }
        public bool IsFlatRate { get; set; }
        public bool IsWeighed { get; set; }
    }
}

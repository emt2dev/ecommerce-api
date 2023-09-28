using api.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apitesting.Models
{
    public class ShippingOptionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Carrier { get; set; }
        public double Cost { get; set; }
        public double Area { get; set; }
        public double MaxWeight { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsFlatRate { get; set; }
        public bool IsWeighed { get; set; }
        public bool IsDigital { get; set; }
        public string DeliveryExpectation { get; set; }

        public ShippingOptionModel(ShippingOptionDTO DTO)
        {
            // Defaults
            this.Id = 0;
            this.IsAvailable = true;

            // DTO
            this.Name = DTO.Name;
            this.Carrier = DTO.Carrier;
            this.Cost = DTO.Cost;
            this.Area = DTO.Area;
            this.MaxWeight = DTO.MaxWeight;
            this.DeliveryExpectation = DTO.DeliveryExpectation;
            this.IsFlatRate = DTO.IsFlatRate;
            this.IsWeighed = DTO.IsWeighed;
        }
    }
}

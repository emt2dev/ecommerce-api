using apitesting.DTOs;
using apitesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace api
{
    public class ShippingOptionModelTest
    {
        ShippingOptionDTO shippingOptionDto = new ShippingOptionDTO
        {
            Name = "Standard Shipping",
            Carrier = "Example Shipping Co.",
            Cost = 10.99,
            Area = 1500.0,
            MaxWeight = 5.0,
            DeliveryExpectation = "2-5 business days",
            IsFlatRate = true,
            IsWeighed = true
        };

        [Fact]
        public void TestConstructorSetsIsAvailableToTrue()
        {

            // Instantiate a ShippingOptionModel using the constructor
            ShippingOptionModel Obj = new ShippingOptionModel(shippingOptionDto);
            Assert.True(Obj.IsAvailable);
        }
    }
}

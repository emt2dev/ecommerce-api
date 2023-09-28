using apitesting.DTOs;
using apitesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api
{
    public class ShippedProductModelTest
    {
        NewProductModelDTO DTO = new NewProductModelDTO
        {
            Name = "Sample shipped Product",
            Description = "This is a sample shipped product description",
            Keywords = "sample, shipped, product"
        };

        [Fact]
        public void ConstructorSetsIdToZero()
        {
            // Instantiate a ShippedProductModel using the constructor
            ShippedProductModel Obj = new ShippedProductModel(DTO);

            Assert.Equal(0, Obj.Id);
        }

        [Fact]
        public void ConstructorSetsIsShippedProductToTrue()
        {
            // Instantiate a ShippedProductModel using the constructor
            ShippedProductModel Obj = new ShippedProductModel(DTO);

            Assert.True(Obj.IsShippedProduct);
        }

        [Fact]
        public void ConstructorSetsIsDigitalProductToFalse()
        {
            // Instantiate a ShippedProductModel using the constructor
            ShippedProductModel Obj = new ShippedProductModel(DTO);

            Assert.False(Obj.IsDigitalProduct);
        }
    }
}

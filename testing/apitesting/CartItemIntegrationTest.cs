using apitesting.DTOs;
using apitesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api
{
    public class CartItemIntegrationTest
    {
        NewProductModelDTO digitalProductDTO = new NewProductModelDTO
        {
            Name = "Sample Digital Product",
            Description = "This is a sample digital product description",
            Keywords = "sample, digital, product",
            IsDigitalProduct = true,
            IsShippedProduct = false,
        };

        NewProductModelDTO shippedProductDTO = new NewProductModelDTO
        {
            Name = "Sample shipped Product",
            Description = "This is a sample shipped product description",
            Keywords = "sample, shipped, product",
            IsDigitalProduct = false,
            IsShippedProduct = true,
        };

        NewProductStyleModelDTO shippedProductStyleDTO = new NewProductStyleModelDTO
        {
            ProductId = 0,
            Name = "Sample shipped Product Style",
            Keywords = "sample, shipped product style",
            Description = "This is a sample shipped product style description.",
            CurrentPrice = 9.99,
            ImageUrls = new List<string>
                {
                    "https://example.com/style-image1.jpg",
                    "https://example.com/style-image2.jpg"
                },
            Weight = 1.5,
            LengthInInches = 6.0,
            WidthInInches = 3.0,
            DepthInInches = 2.0
        };

        NewProductStyleModelDTO digitalProductStyleDTO = new NewProductStyleModelDTO
        {
            ProductId = 0,
            Name = "Sample digital Product Style",
            Keywords = "sample, digital product style",
            Description = "This is a sample digital product style description.",
            CurrentPrice = 7.99,
            ImageUrls = new List<string>
            {
                "https://example.com/style-image1.jpg",
                "https://example.com/style-image2.jpg"
            },
            Weight = 0.0,
            LengthInInches = 0.0,
            WidthInInches = 0.0,
            DepthInInches = 0.0
        };

        [Fact]
        public void ConstructorSetsIsDigitalProductToTrue()
        {
            // Instantiate a DigitalProductModel using the constructor and setting digital to true
            DigitalProductModel ProductObj = new DigitalProductModel(digitalProductDTO);
            ProductStylesModel StyleObj = new ProductStylesModel(digitalProductStyleDTO);

            CartItemModel Obj = new CartItemModel(ProductObj, StyleObj);
            Assert.True(Obj.IsDigital);
        }

        [Fact]
        public void ConstructorSetsIsDigitalProductToFalse()
        {
            // Instantiate a DigitalProductModel using the constructor
            ShippedProductModel ProductObj = new ShippedProductModel(shippedProductDTO);
            ProductStylesModel StyleObj = new ProductStylesModel(shippedProductStyleDTO);

            CartItemModel Obj = new CartItemModel(ProductObj, StyleObj);
            Assert.False(Obj.IsDigital);
        }
    }
}

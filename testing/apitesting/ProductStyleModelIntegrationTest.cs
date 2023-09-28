using apitesting.DTOs;
using apitesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api
{
    public class ProductStyleModelIntegrationTest
    {        
        [Fact]
        public void ConstructorMatchesProductIdToShippedProduct()
        {
            NewProductModelDTO spDTO = new NewProductModelDTO
            {
                Name = "Sample Digital Product",
                Description = "This is a sample digital product description",
                Keywords = "sample, digital, product"
            };

            ShippedProductModel spObj = new ShippedProductModel(spDTO);

            NewProductStyleModelDTO psDTO = new NewProductStyleModelDTO
            {
                ProductId = spObj.Id,
                Name = "Sample Product Style",
                Keywords = "sample, product style",
                Description = "This is a sample product style description.",
                CurrentPrice = 9.99,
                ImageUrls = new List<string>
                {
                    "https://example.com/style-image1.jpg",
                    "https://example.com/style-image2.jpg"
                },
                Weight = 1.5,
                LengthInInches = 6.0,
                WidthInInches = 3.0,
                DepthInInches = 2.0,
                IsPromotional = true,
                IsSeasonal = true,
                IsHoliday = true,
                IsService = false,
            };

            ProductStylesModel Obj = new ProductStylesModel(psDTO);

            Assert.Equal(psDTO.ProductId, Obj.ProductId);
        }

        [Fact]
        public void ConstructorCalculatesAreaInInches()
        {
            NewProductModelDTO spDTO = new NewProductModelDTO
            {
                Name = "Sample Digital Product",
                Description = "This is a sample digital product description",
                Keywords = "sample, digital, product"
            };

            ShippedProductModel spObj = new ShippedProductModel(spDTO);

            NewProductStyleModelDTO psDTO = new NewProductStyleModelDTO
            {
                ProductId = spObj.Id,
                Name = "Sample Product Style",
                Keywords = "sample, product style",
                Description = "This is a sample product style description.",
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

            ProductStylesModel Obj = new ProductStylesModel(psDTO);
            Assert.Equal(36.00, Obj.AreaInInches);
        }
    }
}

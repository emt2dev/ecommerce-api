using apitesting.DTOs;
using apitesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api
{
    public class CartModelIntegrationTest
    {
        string UserEmail = "user@user.com";

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

        ShippingOptionDTO shippingOptionDto = new ShippingOptionDTO
        {
            Name = "Standard Shipping",
            Carrier = "Example Shipping Co.",
            Cost = 10.99,
            Area = 35,
            MaxWeight = 5.0,
            DeliveryExpectation = "2-5 business days",
            IsFlatRate = true,
            IsWeighed = true
        };

        [Fact]
        public void ConstructorMatchesDefaultEmailTest()
        {
            CartModel Obj = new CartModel(UserEmail);
            Assert.True(Obj.Email == UserEmail);
        }

        [Fact]
        public void CartContainsDigitalProduct()
        {
            DigitalProductModel ProductObj = new DigitalProductModel(digitalProductDTO);
            ProductStylesModel StyleObj = new ProductStylesModel(digitalProductStyleDTO);

            CartModel Obj = new CartModel(UserEmail);
            CartItemModel ItemObj = new CartItemModel(ProductObj, StyleObj);

            Obj.AddItem(ItemObj);
            Assert.True(Obj.ContainsDigitalProduct);
        }

        [Fact]
        public void CartDigitalProductCountEqualsOne()
        {
            DigitalProductModel ProductObj = new DigitalProductModel(digitalProductDTO);
            ProductStylesModel StyleObj = new ProductStylesModel(digitalProductStyleDTO);

            CartModel Obj = new CartModel(UserEmail);
            CartItemModel ItemObj = new CartItemModel(ProductObj, StyleObj);

            Obj.AddItem(ItemObj);
            Assert.Equal(1, Obj.DigitalProductCount());
        }

        [Fact]
        public void CartShippedProductCountEqualsOne()
        {
            ShippedProductModel ProductObj = new ShippedProductModel(shippedProductDTO);
            ProductStylesModel StyleObj = new ProductStylesModel(digitalProductStyleDTO);

            CartModel Obj = new CartModel(UserEmail);
            CartItemModel ItemObj = new CartItemModel(ProductObj, StyleObj);

            Obj.AddItem(ItemObj);
            Assert.Equal(1, Obj.ShippedProductCount());
        }

        [Fact]
        public void CartContainsShippedProduct()
        {
            ShippedProductModel ProductObj = new ShippedProductModel(shippedProductDTO);
            ProductStylesModel StyleObj = new ProductStylesModel(shippedProductStyleDTO);

            CartModel Obj = new CartModel(UserEmail);
            CartItemModel ItemObj = new CartItemModel(ProductObj, StyleObj);

            Obj.AddItem(ItemObj);
            Assert.True(Obj.ContainsShippedProduct);
        }

        [Fact]
        public void CartCalculatesCostSeveteenNinetyEight()
        {
            ShippedProductModel ProductObj1 = new ShippedProductModel(shippedProductDTO);
            ProductStylesModel StyleObj1 = new ProductStylesModel(shippedProductStyleDTO);

            DigitalProductModel ProductObj2 = new DigitalProductModel(digitalProductDTO);
            ProductStylesModel StyleObj2 = new ProductStylesModel(digitalProductStyleDTO);

            CartModel Obj = new CartModel(UserEmail);

            CartItemModel ItemObj1 = new CartItemModel(ProductObj1, StyleObj1);
            CartItemModel ItemObj2 = new CartItemModel(ProductObj2, StyleObj2);

            Obj.AddItem(ItemObj1);
            Obj.AddItem(ItemObj2);

            Assert.Equal(17.98, Obj.Cost);
        }

        [Fact]
        public void CartSelectsShippingOptionForDigitalProductInMultiItemCart()
        {
            ShippedProductModel ProductObj1 = new ShippedProductModel(shippedProductDTO);
            ProductStylesModel StyleObj1 = new ProductStylesModel(shippedProductStyleDTO);

            DigitalProductModel ProductObj2 = new DigitalProductModel(digitalProductDTO);
            ProductStylesModel StyleObj2 = new ProductStylesModel(digitalProductStyleDTO);

            CartModel Obj = new CartModel(UserEmail);

            CartItemModel ItemObj1 = new CartItemModel(ProductObj1, StyleObj1);
            CartItemModel ItemObj2 = new CartItemModel(ProductObj2, StyleObj2);

            // Instantiate a ShippingOptionModel using the constructor
            ShippingOptionModel ShippingOptionObj = new ShippingOptionModel(shippingOptionDto);

            Obj.AvailableShippingOptions.Add(ShippingOptionObj);

            Obj.DetermineShippingOptions();

            Assert.Contains(ShippingOptionObj, Obj.AvailableShippingOptions);
        }
    }
}

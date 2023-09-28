using api.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.DAL.Models
{
    public class CartItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string TaxCode { get; set; }

        // Packaged weight for shipping options
        public double? Weight { get; set; }

        // Gets measurements for shipping options
        public double? LengthInInches { get; set; }
        public double? WidthInInches { get; set; }
        public double? DepthInInches { get; set; }
        public double? AreaInInches { get; set; }
        public string StyleName { get; set; }
        public int? Quantity { get; set; }
        public bool IsDigital { get; set; }
        public bool IsShipped { get; set; }
        // constructor allows us to construct using a digital product.
        public CartItemModel(DigitalProductModel ProductObj, ProductStylesModel StyleObj)
        {
            // DTOs
            this.Name = ProductObj.Name;
            this.StyleName = StyleObj.Name;
            this.Description = StyleObj.Name + StyleObj.Description;
            this.TaxCode = ProductObj.TaxCode;
            this.Price = StyleObj.CurrentPrice;
            this.Quantity = StyleObj.Quantity;
            this.Weight = 0;
            this.AreaInInches = 0;
            this.LengthInInches = 0;
            this.DepthInInches = 0;
            this.WidthInInches = 0;
            this.IsDigital = ProductObj.IsDigitalProduct;
            this.IsShipped = ProductObj.IsShippedProduct;
        }
        // Here we overload the constructor to construct from a shipped product
        public CartItemModel(ShippedProductModel ProductObj, ProductStylesModel StyleObj)
        {
            // DTOs
            this.Name = ProductObj.Name;
            this.StyleName = StyleObj.Name;
            this.Description = StyleObj.Name + StyleObj.Description;
            this.TaxCode = ProductObj.TaxCode;
            this.Price = StyleObj.CurrentPrice;
            this.Quantity = StyleObj.Quantity;
            this.IsDigital = ProductObj.IsDigitalProduct;
            this.IsShipped = ProductObj.IsShippedProduct;

            if (StyleObj.Weight is not null) this.Weight = StyleObj.Weight;
            if (StyleObj.LengthInInches is not null)
            {
                this.LengthInInches = StyleObj.LengthInInches;
                this.WidthInInches = StyleObj.WidthInInches;
                this.DepthInInches = StyleObj.DepthInInches;
                this.AreaInInches = StyleObj.LengthInInches * StyleObj.WidthInInches * StyleObj.DepthInInches;
            }
        }
    }
}

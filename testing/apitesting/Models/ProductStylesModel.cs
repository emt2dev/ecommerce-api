﻿using apitesting.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apitesting.Models
{
    internal class ProductStylesModel
    {
        public int Id { get; set; }
        [ForeignKey(nameof(ProductId))]
        public int ProductId { get; set; }
        public string Keywords { get; set; }
        // Base Quantity (for cart counting)
        public int Quantity { get; set; }
        public int CartCount { get; set; }
        public int OrderCount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Each Style has their own pricing
        public double CurrentPrice { get; set; }
        public double SalePrice { get; set; }

        [NotMapped]
        public IList<string>? ImageUrls { get; set; }

        // Packaged weight for shipping options
        public double? Weight { get; set; }

        // Gets measurements for shipping options
        public double? LengthInInches { get; set; }
        public double? WidthInInches { get; set; }
        public double? DepthInInches { get; set; }
        public double? AreaInInches { get; set; }
        // bools
        public bool IsAvailableForNewCarts { get; set; } // We don't delete products or styles, we mark them unavailable
        public bool IsPromotional { get; set; }
        public bool IsSeasonal { get; set; }
        public bool IsHoliday { get; set; }
        public bool IsService { get; set; }
        public bool IsDigital { get; set; } // polymorphic association

        // Methods
        public ProductStylesModel(NewProductStyleModelDTO DTO)
        {
            // Defaults
            this.Id = 0;
            this.Quantity = 1;
            this.SalePrice = 0;

            // DTO
            this.IsDigital = DTO.IsDigital;
            this.IsPromotional = DTO.IsPromotional;
            this.IsSeasonal = DTO.IsSeasonal;
            this.IsHoliday = DTO.IsHoliday;
            this.IsService = DTO.IsService;
            this.ProductId = DTO.ProductId;
            this.Name = DTO.Name;
            this.Description = DTO.Description;
            this.Keywords = DTO.Keywords;
            this.CurrentPrice = DTO.CurrentPrice;
            this.SalePrice = DTO.CurrentPrice;
            this.ImageUrls = new List<string>();

            /*
             * foreach method for IFormFile imageurls to be processed by cloudinary
             *
             */

            if(DTO.ImageUrls.Count > 0)
            {

                foreach (string Item in DTO.ImageUrls)
                {
                    this.ImageUrls.Add(Item);
                }
            }

            if(DTO.Weight is not null)
            {
                this.Weight = DTO.Weight;
            }

            if(DTO.LengthInInches is not null)
            {
                this.LengthInInches = DTO.LengthInInches;
                this.WidthInInches = DTO.WidthInInches;
                this.DepthInInches = DTO.DepthInInches;
                this.AreaInInches = DTO.LengthInInches * DTO.WidthInInches * DTO.DepthInInches;
            }
        }
    }
}

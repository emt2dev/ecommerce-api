using apitesting.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apitesting.Models
{
    internal class DigitalProductModel : BaseProductModel
    {        
        // Styles
        public IList<ProductStylesModel>? ProductStyles { get; set; }

        // Constructor
        public DigitalProductModel(NewProductModelDTO DTO)
        {
            // DTO Info
            this.Name = DTO.Name;
            this.Description = DTO.Description;
            this.Keywords = DTO.Keywords;
            this.ProductStyles = new List<ProductStylesModel>();
            this.TaxCode = DTO.TaxCodeKey;

            // Defaults
            this.Id = 0;
            this.DateCreated = DateTime.Now;
            this.IsAvailableForNewCarts = false;
            this.IsLimitedTimeOnly = false;
            this.IsPopular = false;
            this.IsComingSoon = true;
            this.IsDigitalProduct = true;
            this.IsShippedProduct = false;
        }

        // Methods
        public void AddStyle(ProductStylesModel Obj)
        {
            this.ProductStyles.Add(Obj);
        }
    }
}

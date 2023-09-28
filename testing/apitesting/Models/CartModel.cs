using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apitesting.Models
{
    internal class CartModel
    {
        public int Id { get; set; }
        [ForeignKey("Email")]
        public string Email { get; set; }
        public double Cost { get; set; }
        public double DiscountedRate { get; set; }
        public bool Submitted { get; set; }
        public bool Abandoned { get; set; }
        public double? AreaInInches { get; set; }
        public double? Weight { get; set; }
        
        public IList<CartItemModel>? Items { get; set; }
        public IList<ShippingOptionModel>? AvailableShippingOptions { get; set; }
        public ShippingOptionModel? SelectedOption { get; set; }
        public bool ContainsDigitalProduct { get; set; }
        public bool ContainsShippedProduct { get; set; }

        public CartModel(string UserEmail)
        {
            this.Id = 0;
            this.Email = UserEmail;
            this.Submitted = false;
            this.Abandoned = false;
            this.Items = new List<CartItemModel>();
            this.AvailableShippingOptions = new List<ShippingOptionModel>();
            this.ContainsDigitalProduct = false;
            this.ContainsShippedProduct = false;
            this.Weight = 0.00;
            this.AreaInInches = 0.00;
            this.DiscountedRate = 0.00;
            this.Cost = 0.00;
        }

        // Methods
        public double? CalculateWeight()
        {
            foreach (CartItemModel Item in Items)
            {
                this.Weight += Item.Weight;
            }

            return this.Weight;
        }
        public double? CalculateDimensions()
        {
            foreach (CartItemModel Item in Items)
            {
                this.AreaInInches += Item.AreaInInches;
            }

            return this.AreaInInches;
        }
        public int DigitalProductCount()
        {
            int Count = 0;
            foreach (CartItemModel Item in Items)
            {
                if (Item.IsDigital) Count++;
            }

            if(Count > 0) this.ContainsDigitalProduct = true;

            return Count;
        }
        public int ShippedProductCount()
        {
            int Count = 0;
            foreach (CartItemModel Item in Items)
            {
                if (Item.IsShipped) Count++;
            }

            if (Count > 0) this.ContainsShippedProduct = true;

            return Count;
        }
        public void AddItem(CartItemModel Obj)
        {
            // Ensure the List exists
            if(Items == null) Items = new List<CartItemModel>();

            // Determine if item already in cart
            var DesiredProduct = Items.FirstOrDefault(Product => Product.Id == Obj.Id);
            if (DesiredProduct is not null) DesiredProduct.Quantity += Obj.Quantity ?? 1; // If no quantity specified, add 1
            else Items.Add(Obj);

            this.Cost += Obj.Price;
            if (Obj.Weight > 0.00) this.Weight += Obj.Weight;
            if (Obj.AreaInInches > 0.00) this.AreaInInches += Obj.AreaInInches;

            this.ContainsDigitalProduct = Items.Any(item => item.IsDigital);
            this.ContainsShippedProduct = Items.Any(item => item.IsShipped);
        }
        public void RemoveItem(int itemId, int quantity = 1)
        {
            // Ensure the List exists
            if (Items == null) Items = new List<CartItemModel>();

            // Find the item by its Id
            var itemToRemove = Items.FirstOrDefault(item => item.Id == itemId);

            if (itemToRemove != null)
            {
                // If the item exists, reduce its quantity (or remove it if quantity becomes zero)
                itemToRemove.Quantity -= quantity;

                // If the quantity becomes zero or negative, remove the item from the cart
                if (itemToRemove.Quantity <= 0) Items.Remove(itemToRemove);
            }

            // Update cart properties
            this.Cost -= (itemToRemove?.Price ?? 0) * quantity; // Subtract the removed item's cost

            if (itemToRemove.Weight > 0.00) this.Weight -= itemToRemove.Weight;
            if (itemToRemove.AreaInInches > 0.00) this.AreaInInches -= itemToRemove.AreaInInches;

            this.ContainsDigitalProduct = Items.Any(item => item.IsDigital);
            this.ContainsShippedProduct = Items.Any(item => item.IsShipped);
        }

        public void DetermineShippingOptions()
        {
            if(this.AvailableShippingOptions is null) this.AvailableShippingOptions = new List<ShippingOptionModel>();

            if(this.AvailableShippingOptions.Count > 0)
            {
                IList<ShippingOptionModel> OptionsList = this.AvailableShippingOptions
                    .Where(option => option.Area >= this.AreaInInches)
                    .ToList();
                this.AvailableShippingOptions = OptionsList;
            }


        }

        public void SetSelectedOption(ShippingOptionModel SOObject)
        {
            this.SelectedOption = SOObject; 
        }
    }
}

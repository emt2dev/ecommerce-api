using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apitesting.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public CartModel Cart { get; set; }
        public bool IsDigitalOnly { get; set; }
        public bool IsShippedOnly { get; set; }
        public bool ContainsDigitalAndShippedProduct { get; set; }
        public bool HasBeenShipped { get; set; }
        public bool HasBeenPackaged { get; set; }
        public bool HasBeenDelivered { get; set; }
        public IList<TrackingInfoModel>? TrackingInfo { get; set; }
        public IList<NoteModel>? Notes { get; set; }
        public DateTime SubmittedOn { get; set; }
        public DateTime? DateShipped { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
        public double? ShippingCost { get; set; }
        public OrderModel(CartModel CartObj)
        {
            this.UserEmail = CartObj.Email;
            this.Cart = CartObj;

            /*
             * Determine if digital, mixed, or shipped only
             */
            this.IsDigitalOnly = false;
            this.IsShippedOnly = false;
            this.ContainsDigitalAndShippedProduct = false;

            if (this.Cart.ContainsShippedProduct && this.Cart.ContainsDigitalProduct) this.ContainsDigitalAndShippedProduct = true;
            else this.ContainsDigitalAndShippedProduct = false;

            if (this.Cart.ContainsDigitalProduct && !this.Cart.ContainsShippedProduct) this.IsDigitalOnly = true;
            else if (!this.Cart.ContainsDigitalProduct && this.Cart.ContainsShippedProduct) this.IsShippedOnly = true;

            this.HasBeenShipped = false;
            this.HasBeenPackaged = false;

            if (this.Cart.ContainsDigitalProduct) this.HasBeenDelivered = true;
            else this.HasBeenDelivered = false;

            this.TrackingInfo = new List<TrackingInfoModel>();
            TrackingInfoModel InitialInfo = new TrackingInfoModel(IsDigitalOnly, this.Cart.SelectedOption.DeliveryExpectation);
            this.TrackingInfo.Add(InitialInfo);

            this.Notes = new List<NoteModel>();
            NoteModel InitialNote = new NoteModel();
            this.Notes.Add(InitialNote);

            this.SubmittedOn = DateTime.Now;
            this.ShippingCost = this.Cart.SelectedOption.Cost;
            this.ExpectedDeliveryDate = DateTime.Now.AddDays(7);
        }
    }
}

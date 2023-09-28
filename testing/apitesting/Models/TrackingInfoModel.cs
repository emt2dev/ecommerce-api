using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apitesting.Models
{
    internal class TrackingInfoModel
    {
        public string TrackingNumber { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
        public TrackingInfoModel(bool IsDigitalOnly, string ExpectedDelivery)
        {
            if(IsDigitalOnly)
            {
                this.TrackingNumber = "Digital Only, please log into your account or check email for instructions";
                this.ExpectedDeliveryDate = DateTime.Now;
            } else
            {
                this.TrackingNumber = "Please check back within three business days for tracking number; expected delivery after shipment is: " + ExpectedDelivery;
                this.ExpectedDeliveryDate = DateTime.Now.AddDays(7);
            }
        }
    }
}

using System;
namespace CourierService.Models
{
    public class OfferCriteria
    {
        public int ID { get; set; }
        public string OfferCode { get; set; }
        public decimal Discount { get; set; }
        public double MinDistance { get; set; }
        public double MaxDistance { get; set; }
        public double MinWeight { get; set; }
        public double MaxWeight { get; set; }
        public bool IsOfferActive { get; set; }
    }
}

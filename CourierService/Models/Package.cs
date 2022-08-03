using System;
namespace CourierService.Models
{
    public class Package
    {
        public string PackageID { get; set; }
        public double Weight { get; set; }
        public double Distance { get; set; }
        public string OfferCode { get; set; }
    }
}

using System;
using System.Linq;
using CourierService.Models;

namespace CourierService
{
    public class Delivery : IDelivery
    {
        public double CalculateDeliveryCost(Package package, double baseDeliveryCost)
        {
            var deliveryCost = baseDeliveryCost + (package.Weight * 10) + (package.Distance * 5);

            return deliveryCost;
        }

        public decimal CalculateDiscount(double deliveryCost, Package package)
        {
            decimal calculatedDiscount = 0;

            //check if inputted offer code is valid and the package weight and distance meets the criteria before applying the discount
            OfferCriteria criteria = new OfferCriteria();
            if (OfferCodes.IsOfferCodeValid(package.OfferCode, ref criteria))
            {
                if ((criteria.MinWeight <= package.Weight && package.Weight <= criteria.MaxWeight)
                    && (criteria.MinDistance <= package.Distance && package.Distance <= criteria.MaxDistance))
                {
                    calculatedDiscount = (decimal)deliveryCost * (criteria.Discount / 100);
                }
             }

            return calculatedDiscount;
        }
    }
}

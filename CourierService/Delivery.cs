using System;
using CourierService.Models;

namespace CourierService
{
    public class Delivery : IDelivery
    {
        public void CalculateDeliveryCost(double baseDeliveryCost, Package package)
        {
            decimal calculatedDiscount = 0M;
            decimal totalDeliveryCost = 0M;

            //check if inputted offer code is valid and the package weight and distance meets the criteria before applying the discount
            OfferCriteria criteria = new OfferCriteria();
            if (OfferCodes.IsOfferCodeValid(package.OfferCode, ref criteria))
            {
                if ((criteria.MinWeight <= package.Weight && package.Weight <= criteria.MaxWeight)
                    && (criteria.MinDistance <= package.Distance && package.Distance <= criteria.MaxDistance))
                {
                    calculatedDiscount = (decimal)baseDeliveryCost * (criteria.Discount / 100m);
                    totalDeliveryCost = (decimal)baseDeliveryCost - calculatedDiscount;
                }

            }

            Console.WriteLine($"{package.PackageID} {String.Format("{0:0.00}", calculatedDiscount)} " +
                $"{String.Format("{0:0.00}", totalDeliveryCost > 0 ? totalDeliveryCost : (decimal)baseDeliveryCost)}");
        }
    }
}

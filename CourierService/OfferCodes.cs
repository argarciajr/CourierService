using System;
using System.Linq;
using CourierService.Models;

namespace CourierService
{
    public static class OfferCodes
    {
        public static bool IsOfferCodeValid(string offerCode, ref OfferCriteria offerCriteria)
        {
            bool isValid = false;
            try
            {
                using (var context = new OfferCriteriaContext())
                {
                    var offer = from oCriteria in context.OfferCriterias
                                where oCriteria.OfferCode == offerCode && oCriteria.IsOfferActive == true
                                select oCriteria;

                    if (offer.Count() > 0)
                    {
                        isValid = true;
                        offerCriteria = offer.FirstOrDefault();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
            }
            return isValid;
        }
    }
}

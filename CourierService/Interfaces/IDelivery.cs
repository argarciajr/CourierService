using CourierService.Models;

namespace CourierService
{
    public interface IDelivery
    {
        public double CalculateDeliveryCost(Package package, double baseDeliveryCost);

        public decimal CalculateDiscount(double baseDeliveryCost, Package package);
    }
}
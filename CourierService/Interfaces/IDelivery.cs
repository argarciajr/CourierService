using CourierService.Models;

namespace CourierService
{
    public interface IDelivery
    {
        void CalculateDeliveryCost(double baseDeliveryCost, Package package);
    }
}
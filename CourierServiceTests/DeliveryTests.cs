using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourierService;
using CourierService.Models;

namespace CourierServiceTests
{
    [TestClass]
    public class DeliveryTests
    {
        [TestMethod]
        public void CalculateDeliveryCost_WhenBaseCostWeightDistanceIsZero_DeliveryCostIsZero()
        {
            //Arrange
            double baseDeliveryCost = 0;
            Package package = new Package()
            {
                PackageID = "package1",
                Distance = 0,
                Weight = 0,
                OfferCode = ""
            };

            //Act
            Delivery delivery = new Delivery();
            var cost = delivery.CalculateDeliveryCost(package, baseDeliveryCost);

            //Assert
            Assert.AreEqual(0, cost);
        }

        [TestMethod]
        public void CalculateDeliveryCost_WhenBaseCostIsZeroButWeightAndDistanceNotZero_DeliveryCostNotZero()
        {
            //Arrange
            double baseDeliveryCost = 0;
            Package package = new Package()
            {
                PackageID = "package1",
                Distance = 100,
                Weight = 100,
                OfferCode = ""
            };

            //Act
            Delivery delivery = new Delivery();
            var cost = delivery.CalculateDeliveryCost(package, baseDeliveryCost);

            //Assert
            Assert.AreNotEqual(0, cost);
        }

        [TestMethod]
        public void CalculateDiscount_WithInvalidOfferCode_DiscountShouldbeZero()
        {
            //Arrange
            double deliveryCost = 100;
            Package package = new Package()
            {
                PackageID = "package1",
                Distance = 100,
                Weight = 100,
                OfferCode = "OFR123"
            };

            Delivery delivery = new Delivery();
            //Act
            var discount = delivery.CalculateDiscount(deliveryCost, package);

            //Assert
            Assert.AreEqual(0, discount);
        }

        [TestMethod]
        public void CalculateDiscount_WithValidOfferCode_MeetsCriteria_DiscountShouldNotBeZero()
        {
            //Arrange
            double deliveryCost = 500;
            Package package = new Package()
            {
                PackageID = "package1",
                Distance = 100,
                Weight = 100,
                OfferCode = "OFR001"
            };

            Delivery delivery = new Delivery();
            //Act
            //10% discount should be applied to delivery Cost 500
            var discount = delivery.CalculateDiscount(deliveryCost, package);

            //Assert
            Assert.AreEqual(50, discount);
        }

        [TestMethod]
        public void CalculateDiscount_MeetsCriteria_ButDiscountSettoZero_ReturnZeroDiscount()
        {
            //Arrange
            double deliveryCost = 500;
            Package package = new Package()
            {
                PackageID = "package1",
                Distance = 1,
                Weight = 1,
                OfferCode = "OFR100"
            };

            Delivery delivery = new Delivery();
            //Act
            var discount = delivery.CalculateDiscount(deliveryCost, package);

            //Assert
            Assert.AreEqual(0, discount);
        }
    }
}

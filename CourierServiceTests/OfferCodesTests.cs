using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourierService;
using CourierService.Models;

namespace CourierServiceTests
{
    [TestClass]
    public class OfferCodesTests
    {
        [TestMethod]
        public void IsOfferCodeValid_InputInvalidOfferCode_ShouldReturnFalse()
        {
            //Arrange
            bool valid;
            string invalidOfferCode = "OfferCode1";
            OfferCriteria offerCriteria = new OfferCriteria();

            //Act
            valid = OfferCodes.IsOfferCodeValid(invalidOfferCode, ref offerCriteria);

            //Assert
            Assert.AreEqual(false, valid);
        }

        [TestMethod]
        public void IsOfferCodeValid_InputValidOfferCode_ShouldReturnTrue()
        {
            //Arrange
            bool valid;
            string validOfferCode = "OFR001";
            OfferCriteria offerCriteria = new OfferCriteria();

            //Act
            valid = OfferCodes.IsOfferCodeValid(validOfferCode, ref offerCriteria);

            //Assert
            Assert.AreEqual(true, valid);

        }

        [TestMethod]
        public void IsOfferCodeValid_InputBlankOfferCode_ShouldReturnFalse ()
        {
            //Arrange
            bool valid;
            string validOfferCode = "";
            OfferCriteria offerCriteria = new OfferCriteria();

            //Act
            valid = OfferCodes.IsOfferCodeValid(validOfferCode, ref offerCriteria);

            //Assert
            Assert.AreEqual(false, valid);

        }
    }
}

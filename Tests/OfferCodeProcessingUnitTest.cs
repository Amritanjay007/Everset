using System;
using Xunit;
using EverestEngineering;

namespace EverestEngineeringUnitTest
{
    public class UnitTest
    {
        [Fact]
        public void Discount_should_be_zero_when_no_valid_offerCode_applied()
        {
            //Arrange
            var offerProcessing = new OfferCodeProcessing();

            //Act
            float discount = offerProcessing.CalculateCouponDiscountPercentage("NA",5,50);

            //Assert
            Assert.Equal(0,discount,1);
        }

        [Fact]
        public void Discount_should_not_be_zero_when_valid_offerCode_applied()
        {

            //Arrange
            var offerProcessing = new OfferCodeProcessing();

            //Act
            float discount = offerProcessing.CalculateCouponDiscountPercentage("OFR003", 100, 10);

            //Assert
            Assert.Equal(5,discount, 1);
        }

    }
}
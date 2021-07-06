using Xunit;
using EverestEngineering;
using Moq;
using System.IO;
using System;

namespace EverestEngineeringUnitTest
{
    public class DeliveryCostCalculationUnitTest
    {
        [Fact]
        public void CalculateEachPkgCost_should_give_valid_discount_and_totalCost()
        {
            //Arrange
            Mock<IOfferCode> mock = new Mock<IOfferCode>();
            mock.Setup(s => s.CalculateCouponDiscountPercentage(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(5);
            var deliveryCostCalculaton = new DeliveryCost(mock.Object);

            var packageDetails = new PackageDetails();
            packageDetails.Distance = 100;
            packageDetails.PkgWeight = 10;
            packageDetails.PkgID = "Package1";

            //Act
            deliveryCostCalculaton.CalculateEachPkgCost(100, packageDetails);

            //Assert
            Assert.Equal(35,packageDetails.Discount);
            Assert.Equal(665,packageDetails.TotalCost);
        }

        [Fact]
        public void should_take_input_and_process_the_input()
        {
            //Arrange
            var output = new StringWriter();
            Console.SetOut(output);
              var data = String.Join(Environment.NewLine, new[]
              {
              "100",
               "2",
               "5",
               "5",
               "OFR001",
               "15",
               "5",
               "OFR002"
              });
            Console.SetIn(new System.IO.StringReader(data));
            Mock<IOfferCode> mock = new Mock<IOfferCode>();
            var deliveryCostCalculaton = new DeliveryCost(mock.Object);

            //Act
            var items = deliveryCostCalculaton.TakePackageDetailForCostEstimation();
            var totalPckgCount = items.Item1.Count;

            //Assert
            string expectedValue = "base delivery cost:\r\nno of packges:\r\nPackage1 weight in kg:\r\nDistance in km:\r\nOffer code:\r\n-------------------------------\r\nPackage2 weight in kg:\r\nDistance in km:\r\nOffer code:\r\n-------------------------------\r\n";
            Assert.True(output.ToString().Equals(expectedValue));
            Assert.Equal(2,totalPckgCount);
        }

        [Fact]
        public void should_show_error_message_in_output_when_invalid_input()
        {
            //Arrange
            var output = new StringWriter();
            Console.SetOut(output);
              var data = String.Join(Environment.NewLine, new[]
              {
              "abc",
               "2",
               "5",
               "5",
               "OFR001",
               "15",
               "5",
               "OFR002"
              });
            Console.SetIn(new System.IO.StringReader(data));
            Mock<IOfferCode> mock = new Mock<IOfferCode>();
            var deliveryCostCalculaton = new DeliveryCost(mock.Object);

            //Act
            var items = deliveryCostCalculaton.TakePackageDetailForCostEstimation();
            var totalPckgCount = items.Item1.Count;

            //Assert
            string expectedValue = "Error in TakePackageDetailForCostEstimation";
            Assert.Contains(expectedValue,output.ToString());
            Assert.Equal(0, totalPckgCount);
        }
    }
}


using System;
using System.Collections.Generic;
using System.IO;
using EverestEngineering;
using EverestEngineeringUtilities;
using Xunit;

namespace EverestEngineeringUnitTest
{
    public class UtilitiesUnitTest
    {
        [Fact]
        public void should_not_return_null_when_valid_offer_code_given()
        {
           //Arrange
           string offerCode = "OFR002";

           //Act
           var index = Utilities.FindIndexInListByOfferCode(IOfferCode.OfferList,offerCode);

           //Assert
           Assert.NotNull(index);
           Assert.Equal(1,index.Value);
        }

        [Fact]
        public void should_return_null_when_invalid_offer_code_given()
        {
           //Arrange
           string offerCode = "NA";

           //Act
           var index = Utilities.FindIndexInListByOfferCode(IOfferCode.OfferList,offerCode);

           //Assert
           Assert.Null(index);
        }

        [Fact]
        public void should_print_four_column_in_output()
        {
            //Arrange
            List<PackageDetails> pckgList = new List<PackageDetails>();

            var pckg1 = new PackageDetails();
            pckg1.PkgID = "pckg1";
            pckg1.PkgWeight = 5;
            pckg1.Distance = 15;
            pckg1.OfferCode = "OFR001";
            pckg1.Discount = 35;
            pckg1.TotalCost = 665;
            pckg1.EstimatedDeliveryTime = 3.35f;

            pckgList.Add(pckg1);

            var output = new StringWriter();
            Console.SetOut(output);

            //Act
            Utilities.PrintOutPut(pckgList);

            //Assert
            string expectedValue = "pckg1  35  665  3.35\r\n";
            Assert.True(output.ToString().Equals(expectedValue));
        }

        [Fact]
        public void should_print_three_column_in_output()
        {
            //Arrange
            List<PackageDetails> pckgList = new List<PackageDetails>();

            var pckg1 = new PackageDetails();
            pckg1.PkgID = "pckg1";
            pckg1.PkgWeight = 5;
            pckg1.Distance = 15;
            pckg1.OfferCode = "OFR001";
            pckg1.Discount = 35;
            pckg1.TotalCost = 665;

            pckgList.Add(pckg1);

            var output = new StringWriter();
            Console.SetOut(output);

            //Act
            Utilities.PrintOutPut(pckgList);

            //Assert
            string expectedValue = "pckg1  35  665  \r\n";
            Assert.Contains(expectedValue, output.ToString());
        }
    }
}
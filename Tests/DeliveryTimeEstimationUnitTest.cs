using Xunit;
using EverestEngineering;
using Moq;
using System.IO;
using System;
using System.Collections.Generic;

namespace EverestEngineeringUnitTest
{
    public class DeliveryTimeEstimationUnitTest
    {
         List<PackageDetails> pckgList = new List<PackageDetails>();
        public DeliveryTimeEstimationUnitTest()
        {
            var pckg1 = new PackageDetails();
            pckg1.PkgID = "pckg1";
            pckg1.PkgWeight = 5;
            pckg1.Distance = 15;
            pckg1.OfferCode = "OFR001";

            var pckg2 = new PackageDetails();
            pckg2.PkgID = "pckg2";
            pckg2.PkgWeight = 15;
            pckg2.Distance = 18;
            pckg2.OfferCode = "OFR002";

            var pckg3 = new PackageDetails();
            pckg3.PkgID = "pckg3";
            pckg3.PkgWeight = 7;
            pckg3.Distance = 17;
            pckg3.OfferCode = "OFR003";

           
            pckgList.Add(pckg1);
            pckgList.Add(pckg2);
            pckgList.Add(pckg3);
        }

        [Fact]
        public void should_take_input_and_process_the_input()
        {
            //Arrange
            var output = new StringWriter();
            Console.SetOut(output);

            var data = String.Join(Environment.NewLine, new[]
            {
              "2",
              "70",
              "200",
              });

            Console.SetIn(new System.IO.StringReader(data));
            var deliveryTimeEstimation = new DeliveryTimeEstimation();

            //Act
            var items = deliveryTimeEstimation.TakeVechileDetailForTimeEstimation();

            //Assert
            string expectedValue = "Number of vehicles:\r\nMax speed:\r\nMax carriable Weight:\r\n";

            Assert.True(output.ToString().Equals(expectedValue));
            Assert.Equal(2,items.TotalNo);
            Assert.Equal(70,items.MaxSpeed);
            Assert.Equal(200,items.MaxWeight);
        }

        [Fact]
        public void should_return_all_subset_from_array()
        {
            //Arrange
             var deliveryTimeEstimation = new DeliveryTimeEstimation();

            //Act
            var result = deliveryTimeEstimation.GetAllSubset(pckgList);

            //Assert
            Assert.Equal(8,result.Count);
        }

        [Fact]
        public void should_return_all_the_valid__subset_based_on_maxWeight()
        {
            //Arrange
            var vd = new VehicleDetails();
            vd.TotalNo = 3;
            vd.MaxWeight = 30;
            vd.MaxSpeed = 70;

            var deliveryTimeEstimation = new DeliveryTimeEstimation();

            //Act
            deliveryTimeEstimation.GetAllPossibleComninationOfPackageByWeight(pckgList,vd);

            //Assert
            Assert.Equal(7,deliveryTimeEstimation.possibleCombination.Count);
        }
    }
}
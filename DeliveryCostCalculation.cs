using System;
using System.Collections.Generic;

namespace EverestEngineering
{
    public class DeliveryCost:IDeliveryCostEstimation
    {
        private readonly IOfferCode _customer;
        public DeliveryCost(IOfferCode customer){
              _customer = customer;
        }

        //calculate the cost of total package
        public void CalculateDeliveryCost(float BaseDeliveryCost,List<PackageDetails> PackageList)    
        {
            foreach(var pkgDetail in PackageList)
            {
                CalculateEachPkgCost(BaseDeliveryCost,pkgDetail);
            }
        }

        //calculate the cost of each package
        public void CalculateEachPkgCost(float BaseDeliveryCost, PackageDetails pkgDetail)
        {
           float DeliveryCost = BaseDeliveryCost + (pkgDetail.PkgWeight * 10) + (pkgDetail.Distance * 5);
           float DiscountPercentage = _customer
                                       .CalculateCouponDiscountPercentage(pkgDetail.OfferCode,pkgDetail.Distance,pkgDetail.PkgWeight);
           float TotalDiscount = (DiscountPercentage/100) * DeliveryCost;
           pkgDetail.Discount = TotalDiscount;
           float TotalCost = DeliveryCost - TotalDiscount;
           pkgDetail.TotalCost = TotalCost;
        }

        // Taking the input from user and processing the input
        public (List<PackageDetails>,float) TakePackageDetailForCostEstimation()
        {
          List<PackageDetails> packageList = new List<PackageDetails>();
          try
            {
                Console.WriteLine("base delivery cost:");
                float BaseDeliveryCost = float.Parse(Console.ReadLine());

                Console.WriteLine("no of packges:");
                int NoOfPackage = Int32.Parse(Console.ReadLine());

                for (int i = 1; i <= NoOfPackage; i++)
                {
                    var pkgDetail = new PackageDetails();
                    pkgDetail.PkgID = "Package" + i;

                    Console.WriteLine("Package" + i + " weight in kg:");
                    pkgDetail.PkgWeight = Int32.Parse(Console.ReadLine());

                    Console.WriteLine("Distance in km:");
                    pkgDetail.Distance = Int32.Parse(Console.ReadLine());

                    Console.WriteLine("Offer code:");
                    pkgDetail.OfferCode = Console.ReadLine();
                    Console.WriteLine("-------------------------------");

                    packageList.Add(pkgDetail);
                }

                packageList.Sort((a, b) => a.PkgWeight.CompareTo(b.PkgWeight));
                return (packageList,BaseDeliveryCost);
            }
            catch(Exception e){
                packageList.Clear();
                Console.WriteLine("Error in TakePackageDetailForCostEstimation:- " + e);
                return (packageList,0);
            }    
        }

    }
}
    
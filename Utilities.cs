using System;
using System.Collections.Generic;
using EverestEngineering;
using Microsoft.Extensions.DependencyInjection;

namespace EverestEngineeringUtilities
{
    public static class Utilities
    {
        public static ServiceProvider serviceProvider {get;set;}

        //find the index of the specified offer code
        public static int? FindIndexInListByOfferCode(IList<OfferDetails> OfferList, string OfferCode)
        {
            int? index = null;
            for (int i = 0; i < OfferList.Count; i++)
            {
                var a = OfferList[i].OfferCode;
                if (OfferList[i].OfferCode.ToLower() == OfferCode.ToLower())
                {
                    index = i;
                    break;
                }
            }

            return index;  
        }

        //use to print output
        public static void PrintOutPut(List<PackageDetails> packageList)
        {
            packageList.Sort((a, b) => a.PkgID.CompareTo(b.PkgID));

            foreach (var pkgDetail in packageList)
            {
                Console.WriteLine(String.Format("{0}  {1}  {2}  {3}", pkgDetail.PkgID, 
                                                                      pkgDetail.Discount, 
                                                                      pkgDetail.TotalCost, 
                                                                      (pkgDetail.EstimatedDeliveryTime == 0 ? "": pkgDetail.EstimatedDeliveryTime)
                                                                     ));
            }
        }

        //Display the warning message to go back to menu screen
        public static void DispalyShowMenuAgainPrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Click enter to dispaly menu again OR Press X twice to stop the application !!");
            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey(true);
                if (keyinfo.Key == ConsoleKey.Enter)//enter key pressed
                {
                    DisplayMenu.Display();
                }
            }
            while (keyinfo.Key != ConsoleKey.X);

            keyinfo = Console.ReadKey(true);
            if(keyinfo.Key == ConsoleKey.X)
            {
                Environment.Exit(1);
            }
        }

    }
}
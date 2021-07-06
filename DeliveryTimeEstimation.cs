using System;
using System.Collections.Generic;
using System.Linq;

namespace EverestEngineering
{
    class DeliveryTimeEstimation : IDeliveryTimeEstimation
    {
        //List of all possible subset
        List<List<PackageDetails>> result = new List<List<PackageDetails>>();
        //Filtered lsit based on the weight
        public List<List<PackageDetails>> possibleCombination = new List<List<PackageDetails>>();
        //List of all vechile.
        IDictionary<string, float> vechileList = new Dictionary<string, float>();

        //Find the all posible subset from the given array
        public void GetAllPossibleComninationOfPackageByWeight(List<PackageDetails> packageList, VehicleDetails vehicleDetails)
        {
            GetAllSubset(packageList);
            GetValidSubset(vehicleDetails.MaxWeight);
        }

        //Generate the vechile list base on number of vechile
        public void GenerateVechileList(int noOfVechile)
        {
            for (int i = 1; i <= noOfVechile; i++)
            {
                vechileList.Add("Vechile" + i, 0);
            }
        }

         // Taking the input from user and processing the input
        public VehicleDetails TakeVechileDetailForTimeEstimation()
        {
            var vehicleDetail = new VehicleDetails();

            try
            {
                Console.WriteLine("Number of vehicles:");
                vehicleDetail.TotalNo = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Max speed:");
                vehicleDetail.MaxSpeed = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Max carriable Weight:");
                vehicleDetail.MaxWeight = Int32.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in parsing vechile detail :-" + e.Message);
                Environment.Exit(0);

            }

            return vehicleDetail;
        }
         
        // calculate delivery time for each possible combination of package 
        public List<PackageDetails> CalculateDeliveryTime(int maxSpeed)
        {
            List<PackageDetails> pakageList = possibleCombination.FirstOrDefault();
            KeyValuePair<string, float> avilableTime = GetLatestAvilableVechileTime();
            foreach (var item in pakageList)
            {
                float value = (float)item.Distance / maxSpeed + (float)avilableTime.Value;
                item.EstimatedDeliveryTime = (float)Math.Round(value, 2, MidpointRounding.ToZero);
            }
            float nextAvilableTime = GetNextAvilableTime(pakageList);
            vechileList[avilableTime.Key] = nextAvilableTime;  //UPDATE VECHILE AVIBILITY TIME
            UpdatePossibleCombination(pakageList);
            if (possibleCombination.Count != 0)
            {
                CalculateDeliveryTime(maxSpeed);
            }

            return pakageList;
        }
        public List<List<PackageDetails>> GetAllSubset(List<PackageDetails> nums)
        {
            if (nums.Count == 0)
                return result;

            backtracking(0, new List<PackageDetails>(), nums);
            return result;
        }

        private void backtracking(int start, List<PackageDetails> curr, List<PackageDetails> nums)
        {
            result.Add(new List<PackageDetails>(curr));
            for (int i = start; i < nums.Count; i++)
            {
                curr.Add(nums[i]);
                backtracking(i + 1, curr, nums);
                curr.RemoveAt(curr.Count - 1);
            }
        }

        //Get vechile list based on max weight
        public void GetValidSubset(float maxWeight)
        {

            foreach (var list in result)
            {
                if (list.Count > 0)
                {
                    int packageTotalWeight = 0;
                    foreach (var sub in list)
                    {
                        packageTotalWeight = packageTotalWeight + sub.PkgWeight;
                    }
                    if (packageTotalWeight <= maxWeight)
                    {
                        possibleCombination.Add(list);
                    }
                }
            }
            possibleCombination = possibleCombination.OrderByDescending(i => i.Sum(x => x.PkgWeight))
                                                     .ThenBy(j => j.Sum(y => y.Distance))
                                                     .ToList();
        }

        //return the time of latest avilable vechile
        public KeyValuePair<string, float> GetLatestAvilableVechileTime()
        {
            KeyValuePair<string, float> avilableTime = vechileList.OrderBy(i => i.Value)
                                                                .ToDictionary(j => j.Key, j => j.Value)
                                                                .FirstOrDefault();
            return avilableTime;
        }

        //return the next avilable time of vechile after delivery
        public float GetNextAvilableTime(List<PackageDetails> pakageList)
        {
            float estimatedDeliveryTime = pakageList.OrderByDescending(i => i.EstimatedDeliveryTime)
                                               .FirstOrDefault().EstimatedDeliveryTime;
            return 2 * estimatedDeliveryTime;
        }

        //Removing the package which is schedule for delivery
        public void UpdatePossibleCombination(List<PackageDetails> pakageList)
        {
            foreach (var pakage in pakageList)
            {
                foreach (var list in possibleCombination.ToList())
                {
                    if (list.Contains(pakage))
                    {
                        possibleCombination.Remove(list);
                    }
                }
            }
        }
    }
}
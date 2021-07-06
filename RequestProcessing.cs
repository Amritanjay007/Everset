using EverestEngineeringUtilities;
using Microsoft.Extensions.DependencyInjection;

namespace EverestEngineering
{
    public static class ProcessRequest
    {
        
        //Calculate the delivery cost and print the output
        public static void ProcessDeliveryCostEstimation()
        {
            var deliveryCostEstimationObj = Utilities.serviceProvider.GetService<IDeliveryCostEstimation>();

            var PackageDetails = deliveryCostEstimationObj.TakePackageDetailForCostEstimation();

            deliveryCostEstimationObj.CalculateDeliveryCost(PackageDetails.Item2, PackageDetails.Item1);
            Utilities.PrintOutPut(PackageDetails.Item1);
    
            Utilities.DispalyShowMenuAgainPrompt(); //for dispalying menu again
        }

        //Calculate the cost and time for deleivery and print the output
        public static void ProcessDeliveryCostAndTimeEstimation()
        {
            var deliveryCostEstimationObj = Utilities.serviceProvider.GetService<IDeliveryCostEstimation>();

            var PackageDetails = deliveryCostEstimationObj.TakePackageDetailForCostEstimation();

            deliveryCostEstimationObj.CalculateDeliveryCost(PackageDetails.Item2, PackageDetails.Item1);

            var deliveryTimeEstimationObj = Utilities.serviceProvider.GetService<IDeliveryTimeEstimation>();

            VehicleDetails vehicleDetails = deliveryTimeEstimationObj.TakeVechileDetailForTimeEstimation();
            deliveryTimeEstimationObj.GetAllPossibleComninationOfPackageByWeight(PackageDetails.Item1, vehicleDetails);
            deliveryTimeEstimationObj.GenerateVechileList(vehicleDetails.TotalNo);
            deliveryTimeEstimationObj.CalculateDeliveryTime(vehicleDetails.MaxSpeed);
            Utilities.PrintOutPut(PackageDetails.Item1);

            Utilities.DispalyShowMenuAgainPrompt(); //for dispalying menu agains
        }
    }
}
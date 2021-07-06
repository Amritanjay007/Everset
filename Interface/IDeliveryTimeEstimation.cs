using System.Collections.Generic;

namespace EverestEngineering
{
    public interface IDeliveryTimeEstimation
    {
        public void GetAllPossibleComninationOfPackageByWeight(List<PackageDetails> packageList,VehicleDetails vehicleDetails);

        public List<PackageDetails> CalculateDeliveryTime(int maxSpeed);

        public void GenerateVechileList(int noOfVechile);
        public VehicleDetails TakeVechileDetailForTimeEstimation();
    }
}
using System.Collections.Generic;

namespace EverestEngineering
{
    public interface IDeliveryCostEstimation
    {
        public void CalculateDeliveryCost(float BaseDeliveryCost, List<PackageDetails> PackageList);
        public void CalculateEachPkgCost(float BaseDeliveryCost, PackageDetails pkgDetail);
        public (List<PackageDetails>,float) TakePackageDetailForCostEstimation();
    };
}
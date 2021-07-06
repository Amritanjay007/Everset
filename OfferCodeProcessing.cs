using System;
using System.Collections.Generic;
using EverestEngineeringUtilities;

namespace EverestEngineering
{
    public class OfferCodeProcessing : IOfferCode
    {
        //calculate the discount based on offercode, distance and weight
        public float CalculateCouponDiscountPercentage(string OfferCode, int Distance, int Weight)
        {
            int? index = Utilities.FindIndexInListByOfferCode(IOfferCode.OfferList, OfferCode);
            if(!index.HasValue)
            {
               return 0;
            }
            else
            {
               OfferDetails Offer = IOfferCode.OfferList[index.Value];
               if(Distance >= Offer.DistanceLowerLimit && Distance <= Offer.DistanceUpperLimit 
                   && Weight >= Offer.WeightLowerLimit && Weight <= Offer.WeightUpperLimit)
               {
                   return Offer.DiscountPercentage;
               }
               else
               {
                  return 0;
               }
            }
        }
    }
}
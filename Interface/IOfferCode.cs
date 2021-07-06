using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EverestEngineering
{
   public interface IOfferCode
   {  
         public static readonly IList<OfferDetails> OfferList = new ReadOnlyCollection<OfferDetails>
             (new List<OfferDetails> { 
                 new OfferDetails { OfferCode="OFR001",DiscountPercentage = 10, DistanceLowerLimit = 0,DistanceUpperLimit = 200,WeightLowerLimit = 70,WeightUpperLimit = 200}, 
                 new OfferDetails { OfferCode="OFR002",DiscountPercentage = 7, DistanceLowerLimit = 50,DistanceUpperLimit = 150,WeightLowerLimit = 100,WeightUpperLimit = 250},
                 new OfferDetails { OfferCode="OFR003",DiscountPercentage = 5, DistanceLowerLimit = 50,DistanceUpperLimit = 250,WeightLowerLimit = 10,WeightUpperLimit = 150}
          });
          public float CalculateCouponDiscountPercentage(string OfferCode,int Distance,int Weight);
   };
}
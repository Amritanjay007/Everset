using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EverestEngineering
{
    public interface IMenuOption
    {
        public static readonly IList<Option> MenuOptions = new ReadOnlyCollection<Option>
            (new List<Option> {
                 new Option {Name = "Delivery Cost Estimation",Selected = ()=>ProcessRequest.ProcessDeliveryCostEstimation()},
               new Option {Name="Delivery Cost And Time Estimation",Selected = ()=>ProcessRequest.ProcessDeliveryCostAndTimeEstimation()},
               new Option {Name="Exit",Selected = ()=>Environment.Exit(0)}
         });
    };
}
using System;
using System.Text;
using System.Collections.Generic;
using Brooming_pl.DBClasses;


namespace Brooming_pl.DBClasses
{

    public class OrderElements
    {
        public virtual double OrderId { get; set; }
        public virtual Orders Orders { get; set; }
        public virtual Cars Cars { get; set; }
        public virtual float? DailyPrice { get; set; }
        public virtual string TakeLocation { get; set; }
        public virtual string ReturnLocation { get; set; }
    }
}

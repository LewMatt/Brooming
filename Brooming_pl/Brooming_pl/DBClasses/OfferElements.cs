using System;
using System.Text;
using System.Collections.Generic;
using Brooming_pl.DBClasses;


namespace Brooming_pl.DBClasses
{
    
    public class OfferElements {
        public virtual double OfferId { get; set; }
        public virtual Offers Offers { get; set; }
        public virtual Cars Cars { get; set; }
        public virtual string TakeLocation { get; set; }
        public virtual string ReturnLocation { get; set; }
        public virtual float? DailyPrice { get; set; }
        public virtual DateTime? StartTime { get; set; }
        public virtual DateTime? EndTime { get; set; }
        public virtual string AdditionalInfo { get; set; }
    }
}

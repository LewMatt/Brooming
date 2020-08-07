using System;
using System.Text;
using System.Collections.Generic;
using Brooming_pl.DBClasses;

namespace Brooming_pl.DBClasses
{
    
    public class Offers {
        public Offers() { }
        public virtual double OfferId { get; set; }
        public virtual Users Users { get; set; }
        public virtual string OfferDetail { get; set; }
        public virtual float? DailyPrice { get; set; }
        public virtual string AdditionalInfo { get; set; }
    }
}

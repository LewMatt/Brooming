using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brooming_pl.Model
{
    public class OfferDTO
    {
        public virtual string OfferDetail { get; set; }
        public virtual float DailyPrice { get; set; }
        public virtual string AdditionalInfo { get; set; }
    }
}

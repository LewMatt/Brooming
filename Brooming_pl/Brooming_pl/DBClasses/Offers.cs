using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brooming_pl.DBClasses
{
    public class Offers
    {
        public virtual int Offer_id { get; set; }
        public virtual int User_id { get; set; }
        public virtual String Offer_details { get; set; }
        public virtual float Daily_price { get; set; }
        public virtual String Additional_info { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brooming_pl.DBClasses
{
    public class Orders
    {
        public virtual int Id { get; set; }
        public virtual int Offer_id { get; set; }
        public virtual int User_id { get; set; }
        public virtual int Company_id { get; set; }
        public virtual DateTime Date_of_order { get; set; }
        public virtual string Order_number { get; set; }
        public virtual string Order_details { get; set; }
        public virtual float Price { get; set; }
        public virtual string Additional_info { get; set; }
        public virtual int State_of_order { get; set; }
    }
}

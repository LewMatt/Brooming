using System;

namespace Brooming_pl.DBClasses
{
    public class History_of_orders
    {
        public virtual int Order_id { get; set; }

        public virtual int Company_id { get; set; }

        public virtual int Taker_id { get; set; }

        public virtual int Invoice_id { get; set; }

        public virtual float Price { get; set; }
    }
}
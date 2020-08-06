﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brooming_pl.DBClasses
{
    public class Invoice_elements
    {
        public virtual int Invoice_id { get; set; }
        public virtual int Car_id { get; set; }
        public virtual float Daily_price { get; set; }
        public virtual string Take_location { get; set; }
        public virtual string Return_location { get; set; }
        public virtual DateTime Start_time { get; set; }
        public virtual DateTime End_time { get; set; }
        public virtual String Additional_info { get; set; }
    }
}

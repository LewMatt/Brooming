using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brooming_pl.DBClasses
{
    public class Payments
    {
        public virtual int Invoice_id { get; set; }
        public virtual DateTime Payment_date { get; set; }
        public virtual string Payment_type { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brooming_pl.DBClasses
{
    public class Ratings
    {
        public virtual int Comment_id { get; set; }
        public virtual int Company_id { get; set; }
        public virtual int Rater_id { get; set; }
        public virtual int Rating { get; set; }
        public virtual String Comment { get; set; }

    }
}

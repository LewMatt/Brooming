
using System;

namespace Brooming_pl.DBClasses
{
    public class Company
    {
        public virtual int Company_id { get; set; }
        public virtual string Company_name { get; set; }
        public virtual int Company_admin { get; set; }
        public virtual int Company_agent { get; set; }
        public virtual string Adress { get; set; }
        public virtual float Average_rating { get; set; }
        public virtual int Number_of_ratings { get; set; }
        public virtual int Sum_of_ratings { get; set; }
        public virtual string Tax_number { get; set; }
    }
}

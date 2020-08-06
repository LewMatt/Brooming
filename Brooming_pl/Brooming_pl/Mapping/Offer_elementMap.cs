using Brooming_pl.DBClasses;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brooming_pl.Mapping
{
    public class Offer_elementMap : ClassMapping<Offer_elements>
    {
        public Offer_elementMap()
        {
            Schema("CDN");
            Table("Offer_elements");
            Id(x => x.Offer_id);
            Property(x => x.Car_id);
            Property(x => x.Take_location);
            Property(x => x.Return_location);
            Property(x => x.Daily_price);
            Property(x => x.Start_time);
            Property(x => x.End_time);
            Property(x => x.Additional_info);
        }
    }
}

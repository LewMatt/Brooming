using Brooming_pl.DBClasses;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brooming_pl.Mapping
{
    public class OrdersMap : ClassMapping<Orders>
    {
        public OrdersMap()
        {
            Schema("CDN");
            Table("Orders");
            Id(x => x.Id);
            Property(x => x.Offer_id);
            Property(x => x.User_id);
            Property(x => x.Company_id);

            Set(x => x.ElementsOfOrder, x =>
            {
                x.Key(k => k.Column("Id"));
                x.Inverse(true);
            }, map => map.OneToMany(r => r.Class(typeof(Order_elements))));

            Property(x => x.Date_of_order);
            Property(x => x.Order_number);
            Property(x => x.Order_details);
            Property(x => x.Price);
            Property(x => x.Additional_info);
            Property(x => x.State_of_order);
        }
    }
}

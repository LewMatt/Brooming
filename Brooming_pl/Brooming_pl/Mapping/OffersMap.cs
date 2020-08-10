using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Brooming_pl.DBClasses;


namespace Brooming_pl.mapping
{

    public class OffersMap : ClassMapping<Offers>
    {

        public OffersMap()
        {
            Schema("dbo");
            Lazy(true);
            Id(x => x.OfferId, map => { map.Column("offer_id"); map.Generator(Generators.Assigned); });
            Property(x => x.OfferDetail, map => map.Column("offer_detail"));
            Property(x => x.DailyPrice, map => map.Column("daily_price"));
            Property(x => x.AdditionalInfo, map => map.Column("additional_info"));
            ManyToOne(x => x.Users, map =>
            {
                map.Column("user_id");
                map.NotNullable(true);
                map.Cascade(Cascade.None);
            });

            Bag(x => x.OfferElements, colmap => { colmap.Key(x => x.Column("offer_id")); colmap.Inverse(true); }, map => { map.OneToMany(); });
            Bag(x => x.Orders, colmap => { colmap.Key(x => x.Column("offer_id")); colmap.Inverse(true); }, map => { map.OneToMany(); });
        }
    }
}

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Brooming_pl.DBClasses;
using FluentNHibernate.Automapping.Steps;
using NHibernate.Mapping;

namespace Brooming_pl.mapping
{


    public class OfferElementsMap : ClassMapping<OfferElements>
    {

        public OfferElementsMap()
        {
            Table("offer_elements");
            Schema("dbo");
            Lazy(true);
            Id(x => x.OfferId, map => { map.Column("offer_id"); map.Generator(Generators.Assigned); });
            Property(x => x.TakeLocation, map => map.Column("take_location"));
            Property(x => x.ReturnLocation, map => map.Column("return_location"));
            Property(x => x.StartTime, map => map.Column("start_time"));
            Property(x => x.EndTime, map => map.Column("end_time"));
            Property(x => x.AdditionalInfo, map => map.Column("additional_info"));
            Property(x => x.DailyPrice, map => map.Column("daily_price"));

            OneToMany();

            //ManyToOne(x => x.Offers, map =>
            //{
            //    map.Column("offer_id");
            //    map.PropertyRef("OfferId");
            //    map.Cascade(Cascade.None);
            //});

            //ManyToOne(x => x.Cars, map =>
            //{
            //    map.Column("car_id");
            //    map.PropertyRef("CarId");
            //    map.NotNullable(true);
            //    map.Cascade(Cascade.None);
            //});

        }
    }
}

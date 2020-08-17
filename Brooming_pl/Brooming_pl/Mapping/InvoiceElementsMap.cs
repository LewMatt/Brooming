using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Brooming_pl.DBClasses;


namespace Brooming_pl.mapping
{


    public class InvoiceElementsMap : ClassMapping<InvoiceElements>
    {

        public InvoiceElementsMap()
        {
            Table("invoice_elements");
            Schema("dbo");
            Lazy(true);
            Id(x => x.InvoiceId, map => { map.Column("invoice_id"); map.Generator(Generators.Assigned); });
            Property(x => x.DailyPrice, map => map.Column("daily_price"));
            Property(x => x.TakeLocation, map => map.Column("take_location"));
            Property(x => x.ReturnLocation, map => map.Column("return_location"));
            Property(x => x.StartTime, map => map.Column("start_time"));
            Property(x => x.EndTime, map => map.Column("end_time"));
            Property(x => x.AdditionalInfo, map => map.Column("additional_info"));
            ManyToOne(x => x.Cars, map =>
            {
                map.Column("car_id");
                map.PropertyRef("CarId");
                map.NotNullable(true);
                map.Cascade(Cascade.None);
            });

            //Bag(x => x.Invoices, colmap => { colmap.Key(x => x.Column("invoice_id")); colmap.Inverse(true); }, map => { map.OneToMany(typeo); });

            //ManyToOne(x => x.Invoices, map =>
            //{
            //    map.Column("invoice_id");
            //    map.PropertyRef("InvoiceId");
            //    map.NotNullable(true);
            //    map.Cascade(Cascade.None);
            //});

        }
    }
}

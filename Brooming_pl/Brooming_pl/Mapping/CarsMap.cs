using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Brooming_pl.DBClasses;


namespace Brooming_pl.mapping
{


    public class CarsMap : ClassMapping<Cars>
    {

        public CarsMap()
        {
            Schema("dbo");
            Lazy(true);
            Id(x => x.CarId, map => { map.Column("car_id"); map.Generator(Generators.Assigned); });
            Property(x => x.RegistrationNumber, map => map.Column("registration_number"));
            Property(x => x.YearOfProduction, map => map.Column("year_of_production"));
            Property(x => x.Description);
            Property(x => x.LinkToPhoto, map => map.Column("link_to_photo"));
            Property(x => x.Availability);
            ManyToOne(x => x.Users, map =>
            {
                map.Column("user_id");
                map.NotNullable(true);
                map.Cascade(Cascade.None);
            });

            ManyToOne(x => x.Company, map =>
            {
                map.Column("company_id");
                map.PropertyRef("CompanyId");
                map.Cascade(Cascade.None);
            });

            ManyToOne(x => x.CarType, map =>
            {
                map.Column("type_id");
                map.NotNullable(true);
                map.Cascade(Cascade.None);
            });

            Bag(x => x.InvoiceElements, colmap => { colmap.Key(x => x.Column("car_id")); colmap.Inverse(true); }, map => { map.OneToMany(); });
            Bag(x => x.OfferElements, colmap => { colmap.Key(x => x.Column("car_id")); colmap.Inverse(true); }, map => { map.OneToMany(); });
            Bag(x => x.OrderElements, colmap => { colmap.Key(x => x.Column("car_id")); colmap.Inverse(true); }, map => { map.OneToMany(); });
        }
    }
}

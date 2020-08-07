using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Brooming_pl.DBClasses;


namespace Brooming_pl.mapping
{

        public class CompanyMap : ClassMapping<Company>
        {

            public CompanyMap()
            {
                Schema("dbo");
                Lazy(true);
                Id(x => x.CompanyId, map => { map.Column("company_id"); map.Generator(Generators.Assigned); });
                Property(x => x.CompanyName, map => map.Column("company_name"));
                Property(x => x.Adress);
                Property(x => x.AverageRating, map => map.Column("average_rating"));
                Property(x => x.NumberOfRatings, map => map.Column("number_of_ratings"));
                Property(x => x.SumOfRatings, map => map.Column("sum_of_ratings"));
                Property(x => x.TaxNumber, map => map.Column("tax_number"));
                ManyToOne(x => x.CompanyAdmin, map =>
                {
                    map.Column("company_admin");
                    map.NotNullable(true);
                    map.Cascade(Cascade.None);
                });

                Bag(x => x.CompanyAgents, colmap => { colmap.Key(x => x.Column("company_id")); colmap.Inverse(true); }, map => { map.OneToMany(); });
                Bag(x => x.Cars, colmap => { colmap.Key(x => x.Column("company_id")); colmap.Inverse(true); }, map => { map.OneToMany(); });
                Bag(x => x.HistoryOfOrders, colmap => { colmap.Key(x => x.Column("company_id")); colmap.Inverse(true); }, map => { map.OneToMany(); });
                Bag(x => x.Invoices, colmap => { colmap.Key(x => x.Column("company_id")); colmap.Inverse(true); }, map => { map.OneToMany(); });
                Bag(x => x.Orders, colmap => { colmap.Key(x => x.Column("company_id")); colmap.Inverse(true); }, map => { map.OneToMany(); });
                Bag(x => x.Ratings, colmap => { colmap.Key(x => x.Column("company_id")); colmap.Inverse(true); }, map => { map.OneToMany(); });
            }
        }
}

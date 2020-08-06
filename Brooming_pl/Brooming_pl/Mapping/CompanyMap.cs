using Brooming_pl.DBClasses;
using NHibernate.Mapping;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brooming_pl.Mapping
{
    public class CompanyMap : ClassMapping<Company>
    {
        public CompanyMap()
        {
            Schema("CDN");
            Table("Company");
            Id(x => x.Id);
            Property(x => x.Company_name);
            Property(x => x.Adress);
            Property(x => x.Average_rating);
            Property(x => x.Number_of_ratings);
            Property(x => x.Tax_number);
            Set(x => x.CompanyAgents, x =>
            {
                x.Key(k => k.Column("Id"));
                x.Inverse(true);
            }, map => map.OneToMany(r => r.Class(typeof(Users))));

            Set(x => x.Ratings, x =>
            {
                x.Key(k => k.Column("Company_id"));
                x.Inverse(true);
            }, map => map.OneToMany(r => r.Class(typeof(Ratings))));

            Set(x => x.OrderHistory, x =>
            {
                x.Key(k => k.Column("Company_id"));
                x.Inverse(true);
            }, map => map.OneToMany(r => r.Class(typeof(History_of_orders))));
        }
    }
}

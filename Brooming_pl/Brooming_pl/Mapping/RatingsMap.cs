using Brooming_pl.DBClasses;
using NHibernate.Mapping;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Brooming_pl.Mapping
{
    public class RatingsMap : ClassMapping<Ratings>
    {
        public RatingsMap()
        {
            Table("Ratings");
            Id(x => x.Comment_id);

            /*

            Set(x => x.Company_id, x =>
            {
                x.Key(k => k.Column("Id"));
                x.Inverse(true);
            }, map => map.OneToMany(r => r.Class(typeof(Company))));

            */
            //OneToOne();

        }
    }
}

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
            Schema("CDN");
            Table("Ratings");
            Id(x => x.Comment_id);
            Property(x => x.Company_id);
            Property(x => x.Rater_id);
            Property(x => x.Rating);
            Property(x => x.Comment);
        }
    }
}

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Brooming_pl.DBClasses;


namespace Brooming_pl.mapping
{


    public class RatingsMap : ClassMapping<Ratings>
    {

        public RatingsMap()
        {
            Schema("dbo");
            Lazy(true);
            Id(x => x.CommentId, map => { map.Column("comment_id"); map.Generator(Generators.Assigned); });
            Property(x => x.Rating);
            Property(x => x.Comment);
            //ManyToOne(x => x.Company, map =>
            //{
            //    map.Column("company_id");
            //    map.PropertyRef("CompanyId");
            //    map.NotNullable(true);
            //    map.Cascade(Cascade.None);
            //});

            //ManyToOne(x => x.Users, map =>
            //{
            //    map.Column("rater_id");
            //    map.NotNullable(true);
            //    map.Cascade(Cascade.None);
            //});

        }
    }
}

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Brooming_pl.DBClasses;


namespace Brooming_pl.mapping {


    public class UsersMap : ClassMapping<Users>
    {

        public UsersMap()
        {
            Schema("dbo");
            Lazy(true);
            Id(x => x.UserId, map => { map.Column("user_id"); map.Generator(Generators.Assigned); });
            Property(x => x.Login);
            Property(x => x.Password);
            Property(x => x.FirstName, map => map.Column("first_name"));
            Property(x => x.Surname);
            Property(x => x.Adress);
            Property(x => x.DateOfBirth, map => map.Column("date_of_birth"));
            Property(x => x.PhoneNumber, map => map.Column("phone_number"));
            Property(x => x.EMail, map => map.Column("e_mail"));
            Property(x => x.LinkToAvatar, map => map.Column("link_to_avatar"));
            Property(x => x.Role);
            Bag(x => x.Cars, colmap => { colmap.Key(x => x.Column("user_id")); colmap.Inverse(true); }, map => { map.OneToMany(); });
            Bag(x => x.HistoryOfOrders, colmap => { colmap.Key(x => x.Column("taker_id")); colmap.Inverse(true); }, map => { map.OneToMany(); });
            Bag(x => x.Invoices, colmap => { colmap.Key(x => x.Column("taker_id")); colmap.Inverse(true); }, map => { map.OneToMany(); });
            Bag(x => x.Offers, colmap => { colmap.Key(x => x.Column("user_id")); colmap.Inverse(true); }, map => { map.OneToMany(); });
            Bag(x => x.Orders, colmap => { colmap.Key(x => x.Column("user_id")); colmap.Inverse(true); }, map => { map.OneToMany(); });
            Bag(x => x.Ratings, colmap => { colmap.Key(x => x.Column("rater_id")); colmap.Inverse(true); }, map => { map.OneToMany(); });
        }
    }
}

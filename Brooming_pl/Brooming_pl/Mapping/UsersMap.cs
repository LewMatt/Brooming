using Brooming_pl.DBClasses;
using NHibernate.Mapping.ByCode.Conformist;
using System;
namespace Brooming_pl.Mapping 
{ 
    public class UsersMap : ClassMapping<Users>
    {
        public UsersMap()
        {
            Schema("CDN");
            Table("Users");
            Id(x => x.User_id);
            Property(x => x.Login);
            Property(x => x.First_name);
            Property(x => x.Surname);
            Property(x => x.Adress);
            Property(x => x.Date_of_birth);
            Property(x => x.Phone_number);
            Property(x => x.E_mail);
            Property(x => x.Link_to_avatar);
            Property(x => x.Role);
        }
    }
}

using Brooming_pl.DBClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Brooming_pl.Model
{
    public class LoginDTO
    {
        public virtual double UserId { get; set; }
        public virtual string Login { get; set; }
        public virtual string Password { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Adress { get; set; }
        public virtual DateTime? DateOfBirth { get; set; }
        public virtual double? PhoneNumber { get; set; }
        public virtual string EMail { get; set; }
        public virtual string LinkToAvatar { get; set; }
        public virtual string Role { get; set; }
        
    }
}

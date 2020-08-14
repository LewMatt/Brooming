using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Brooming_pl.Model
{
    [DataContract]
    public class RegisterDTO
    {
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public string Adress { get; set; }
        [DataMember]
        public string DateOfBirth { get; set; }
        [DataMember]
        public int PhoneNumber { get; set; }
        [DataMember]
        public string EMail { get; set; }
        [DataMember]
        public string LinkToAvatar { get; set; }
    }
}

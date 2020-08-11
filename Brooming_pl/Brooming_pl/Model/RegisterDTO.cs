using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brooming_pl.Model
{
    public class RegisterDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Adress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int PhoneNumber { get; set; }
        public string EMail { get; set; }
        public string LinkToAvatar { get; set; }
    }
}

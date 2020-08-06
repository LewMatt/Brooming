using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Brooming_pl.DBClasses
{
    public class Users
    {
        public virtual int Id { get; set; }
        public virtual string Login { get; set; }
        public virtual string Password { get; set; }
        public virtual string First_name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Adress { get; set; }
        public virtual DateTime Date_of_birth { get; set; }
        public virtual int Phone_number { get; set; }
        public virtual string E_mail { get; set; }
        public virtual string Link_to_avatar { get; set; }
        public virtual string Role { get; set; }
        
        public virtual HashSet<Cars> CarsList { get; set; }
        public virtual HashSet<Offers> OffersList { get; set; }
        public virtual HashSet<History_of_orders> OrdersListHistory { get; set; }
    }
}



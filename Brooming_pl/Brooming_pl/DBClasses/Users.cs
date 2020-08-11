using System;
using System.Text;
using System.Collections.Generic;
using Brooming_pl.DBClasses;


namespace Brooming_pl.DBClasses
{

    public class Users
    {
        public Users()
        {
            Cars = new List<Cars>();
            HistoryOfOrders = new List<HistoryOfOrders>();
            Invoices = new List<Invoices>();
            Offers = new List<Offers>();
            Orders = new List<Orders>();
            Ratings = new List<Ratings>();
        }
        public virtual int UserId { get; set; }
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
        public virtual IList<Cars> Cars { get; set; }
        public virtual IList<HistoryOfOrders> HistoryOfOrders { get; set; }
        public virtual IList<Invoices> Invoices { get; set; }
        public virtual IList<Offers> Offers { get; set; }
        public virtual IList<Orders> Orders { get; set; }
        public virtual IList<Ratings> Ratings { get; set; }
    }
}

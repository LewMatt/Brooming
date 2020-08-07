using System;
using System.Text;
using System.Collections.Generic;
using Brooming_pl.DBClasses;


namespace Brooming_pl.DBClasses
{
    
    public class Company {
        public Company() {
			Cars = new List<Cars>();
			HistoryOfOrders = new List<HistoryOfOrders>();
			Invoices = new List<Invoices>();
			Orders = new List<Orders>();
			Ratings = new List<Ratings>();
        }
        public virtual double CompanyId { get; set; }
        public virtual Users Users { get; set; }
        public virtual Users CompanyAdmin { get; set; }
        public virtual Users CompanyAgent { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual string Adress { get; set; }
        public virtual float? AverageRating { get; set; }
        public virtual double? NumberOfRatings { get; set; }
        public virtual double? SumOfRatings { get; set; }
        public virtual string TaxNumber { get; set; }
        public virtual IList<Cars> Cars { get; set; }
        public virtual IList<HistoryOfOrders> HistoryOfOrders { get; set; }
        public virtual IList<Invoices> Invoices { get; set; }
        public virtual IList<Orders> Orders { get; set; }
        public virtual IList<Ratings> Ratings { get; set; }
    }
}

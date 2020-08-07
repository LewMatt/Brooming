using System;
using System.Text;
using System.Collections.Generic;
using Brooming_pl.DBClasses;

namespace Brooming_pl.DBClasses
{
    
    public class Company {
        public Company() { }
        public virtual double CompanyId { get; set; }
        public virtual Users Users { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual string Adress { get; set; }
        public virtual float? AverageRating { get; set; }
        public virtual double? NumberOfRatings { get; set; }
        public virtual double? SumOfRatings { get; set; }
        public virtual string TaxNumber { get; set; }
    }
}

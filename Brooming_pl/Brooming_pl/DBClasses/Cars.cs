using System;
using System.Text;
using System.Collections.Generic;
using Brooming_pl.DBClasses;

namespace Brooming_pl.DBClasses
{
    
    public class Cars {
        public Cars() { }
        public virtual double CarId { get; set; }
        public virtual Users Users { get; set; }
        public virtual Company Company { get; set; }
        public virtual CarType CarType { get; set; }
        public virtual string RegistrationNumber { get; set; }
        public virtual int? YearOfProduction { get; set; }
        public virtual string Description { get; set; }
        public virtual string LinkToPhoto { get; set; }
        public virtual int? Availability { get; set; }
    }
}

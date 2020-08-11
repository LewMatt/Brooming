using System;
using System.Text;
using System.Collections.Generic;
using Brooming_pl.DBClasses;


namespace Brooming_pl.DBClasses
{

    public class Payments
    {
        public virtual int PaymentId { get; set; }
        public virtual Invoices Invoices { get; set; }
        public virtual DateTime? PaymentDate { get; set; }
        public virtual string PaymentType { get; set; }
    }
}

using System;
using System.Text;
using System.Collections.Generic;
using Brooming_pl.DBClasses;


namespace Brooming_pl.DBClasses
{
    
    public class Payments {
        public Payments() {
			Invoices = new List<Invoices>();
        }
        public virtual int InvoiceId { get; set; }
        public virtual DateTime? PaymentDate { get; set; }
        public virtual string PaymentType { get; set; }
        public virtual IList<Invoices> Invoices { get; set; }
    }
}

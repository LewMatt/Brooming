using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brooming_pl.DBClasses
{
    public class Invoices
    {
        public virtual int Invoice_id { get; set; }
        public virtual int Taker_id { get; set; }
        public virtual int Company_id { get; set; }
        public virtual DateTime Date_of_issue { get; set; }
        public virtual DateTime Deadline_of_payment { get; set; }
        public virtual DateTime Date_of_invoicing { get; set; }
        public virtual float Unit_price { get; set; }
        public virtual String Taker_tax_number { get; set; }
        public virtual float Discounts { get; set; }
        public virtual int VAT { get; set; }
    }
}

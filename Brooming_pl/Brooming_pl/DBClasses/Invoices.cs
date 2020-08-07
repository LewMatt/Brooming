using System;
using System.Text;
using System.Collections.Generic;
using Brooming_pl.DBClasses;


namespace Brooming_pl.DBClasses
{
    
    public class Invoices {
        public Invoices() {
			HistoryOfOrders = new List<HistoryOfOrders>();
        }
        public virtual int InvoiceId { get; set; }
        public virtual InvoiceElements InvoiceElements { get; set; }
        public virtual Payments Payments { get; set; }
        public virtual Users Users { get; set; }
        public virtual Company Company { get; set; }
        public virtual DateTime? DateOfIssue { get; set; }
        public virtual DateTime? DeadlineOfPayment { get; set; }
        public virtual DateTime? DateOfInvoicing { get; set; }
        public virtual float? UnitPrice { get; set; }
        public virtual string TakerTaxNumber { get; set; }
        public virtual float? Discounts { get; set; }
        public virtual int? Vat { get; set; }
        public virtual IList<HistoryOfOrders> HistoryOfOrders { get; set; }
    }
}

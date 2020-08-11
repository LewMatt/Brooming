using System;
using System.Text;
using System.Collections.Generic;
using Brooming_pl.DBClasses;


namespace Brooming_pl.DBClasses
{
    public class HistoryOfOrders
    {
        public virtual int HistoryOrderId { get; set; }
        public virtual Orders Orders { get; set; }
        public virtual Company Company { get; set; }
        public virtual Users Users { get; set; }
        public virtual Invoices Invoices { get; set; }
        public virtual int? PaymentId { get; set; }
        public virtual float? Price { get; set; }
    }
}

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Brooming_pl.DBClasses;


namespace Brooming_pl.mapping
{
    
    
    public class PaymentsMap : ClassMapping<Payments> {
        
        public PaymentsMap() {
			Schema("dbo");
			Lazy(true);
			Id(x => x.InvoiceId, map => { map.Column("invoice_id"); map.Generator(Generators.Assigned); });
			Property(x => x.PaymentDate, map => map.Column("payment_date"));
			Property(x => x.PaymentType, map => map.Column("payment_type"));
			Bag(x => x.Invoices, colmap =>  { colmap.Key(x => x.Column("invoice_id")); colmap.Inverse(true); }, map => { map.OneToMany(); });
        }
    }
}

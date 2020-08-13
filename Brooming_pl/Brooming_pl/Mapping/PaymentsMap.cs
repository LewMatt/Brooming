using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Brooming_pl.DBClasses;


namespace Brooming_pl.mapping
{


    public class PaymentsMap : ClassMapping<Payments>
    {

        public PaymentsMap()
        {
            Schema("dbo");
            Lazy(true);
            Id(x => x.PaymentId, map => { map.Column("payment_id"); map.Generator(Generators.Identity); });
            Property(x => x.PaymentDate, map => map.Column("payment_date"));
            Property(x => x.PaymentType, map => map.Column("payment_type"));
            ManyToOne(x => x.Invoices, map =>
            {
                map.Column("invoice_id");
                map.PropertyRef("InvoiceId");
                map.Cascade(Cascade.None);
            });

        }
    }
}

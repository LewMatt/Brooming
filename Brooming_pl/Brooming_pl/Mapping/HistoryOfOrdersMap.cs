using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Brooming_pl.DBClasses;


namespace Brooming_pl.mapping
{
    public class HistoryOfOrdersMap : ClassMapping<HistoryOfOrders>
    {

        public HistoryOfOrdersMap()
        {
            Table("history_of_orders");
            Schema("dbo");
            Lazy(true);
            Id(x => x.HistoryOrderId, map => { map.Column("history_order_id"); map.Generator(Generators.Identity); });
            Property(x => x.PaymentId, map => map.Column("payment_id"));
            Property(x => x.Price);
            ManyToOne(x => x.Orders, map =>
            {
                map.Column("order_id");
                map.PropertyRef("OrderId");
                map.Cascade(Cascade.None);
            });

            ManyToOne(x => x.Company, map =>
            {
                map.Column("company_id");
                map.PropertyRef("CompanyId");
                map.NotNullable(true);
                map.Cascade(Cascade.None);
            });

            ManyToOne(x => x.Users, map =>
            {
                map.Column("taker_id");
                map.NotNullable(true);
                map.Cascade(Cascade.None);
            });

            ManyToOne(x => x.Invoices, map =>
            {
                map.Column("invoice_id");
                map.PropertyRef("InvoiceId");
                map.NotNullable(true);
                map.Cascade(Cascade.None);
            });

        }
    }
}

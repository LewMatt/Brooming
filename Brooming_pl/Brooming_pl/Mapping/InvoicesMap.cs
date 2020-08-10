using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Brooming_pl.DBClasses;
using NHibernate.Mapping;

namespace Brooming_pl.mapping
{


    public class InvoicesMap : ClassMapping<Invoices>
    {

        public InvoicesMap()
        {
            Schema("dbo");
            Lazy(true);
            Id(x => x.InvoiceId, map => { map.Column("invoice_id"); map.Generator(Generators.Increment); });
            Property(x => x.DateOfIssue, map => map.Column("date_of_issue"));
            Property(x => x.DeadlineOfPayment, map => map.Column("deadline_of_payment"));
            Property(x => x.DateOfInvoicing, map => map.Column("date_of_invoicing"));
            Property(x => x.UnitPrice, map => map.Column("unit_price"));
            Property(x => x.TakerTaxNumber, map => map.Column("taker_tax_number"));
            Property(x => x.Discounts);
            Property(x => x.Vat);

            //ManyToOne(x => x.InvoiceElements, map =>
            //{
            //    map.Column("invoice_id");
            //    map.PropertyRef("InvoiceId");
            //    map.Cascade(Cascade.None);
            //});

            ManyToOne(x => x.Users, map =>
            {
                map.Column("taker_id");
                map.NotNullable(true);
                map.Cascade(Cascade.None);
            });

            ManyToOne(x => x.Company, map =>
            {
                map.Column("company_id");
                map.PropertyRef("CompanyId");
                map.NotNullable(true);
                map.Cascade(Cascade.None);
            });

            Bag(x => x.HistoryOfOrders, colmap => { colmap.Key(x => x.Column("invoice_id")); colmap.Inverse(true); }, map => { map.OneToMany(); });
            Bag(x => x.Payments, colmap => { colmap.Key(x => x.Column("invoice_id")); colmap.Inverse(true); }, map => { map.OneToMany(); });
        }
    }
}

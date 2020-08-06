using Brooming_pl.DBClasses;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Brooming_pl.Mapping
{
    public class PaymentsMapping : ClassMapping<Payments>
    {
        public PaymentsMapping()
        {
            Id(x => x.Invoice_id);
            Property(x => x.Payment_date);
            Property(x => x.Payment_type);
        }
    }
}

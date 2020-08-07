using Brooming_pl.mapping;
using Brooming_pl.DBClasses;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brooming_pl
{
    public class NH
    {
        private static ISessionFactory SessionFactory;

        private static List<Type> typeMappings = new List<Type>()
        {
            typeof(CarsMap),
            typeof(CarTypeMap),
            typeof(CompanyMap),
            typeof(HistoryOfOrdersMap),
            typeof(InvoiceElementsMap),
            typeof(InvoicesMap),
            typeof(OfferElementsMap),
            typeof(OffersMap),
            typeof(OrderElementsMap),
            typeof(OrdersMap),
            typeof(PaymentsMap),
            typeof(RatingsMap),
            typeof(UsersMap)

        };

        public static void Init(string connectionString, List<Type> customTypes = null)
        {
            if (SessionFactory != null)
                return;

            Configuration config = new Configuration().DataBaseIntegration(db =>
            {
                db.Timeout = byte.MaxValue;
                db.Dialect<MsSql2008Dialect>();
                db.Driver<SqlClientDriver>();
                db.ConnectionString = connectionString;
                //db.Batcher<BatcherFactory>();
            });

            ModelMapper mapper = new ModelMapper();
            mapper.AddMappings(typeMappings);


            try
            {

                config.AddDeserializedMapping(mapper.CompileMappingForAllExplicitlyAddedEntities(), null);


                SessionFactory = config.BuildSessionFactory();
            }
            catch
            {
                throw;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

    }
}
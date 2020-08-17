using Brooming_pl.DBClasses;
using Brooming_pl.Model;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brooming_pl.BusinessLogic
{
    public class SearchEngine
    {
        public static List<Offers> Search(SearchOptionsDTO searchOptions) //nie skończone
        {
            try
            {
                List<Offers> result = new List<Offers>();

                using (var session = NH.OpenSession())
                {
                    var results = session.Query<OfferElements>().Where(x=>x.TakeLocation==searchOptions.TakeLocation).Fetch(x=>x.Cars).ThenFetch(x=>x.CarType).ToFuture();
                    if (!String.IsNullOrEmpty(searchOptions.CarType))
                    {
                        results= session.Query<OfferElements>().Where(x => x.Cars.CarType.Type == searchOptions.CarType).ToFuture();
                    }
                    var offers = results.ToList();
                }



                return result;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}

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
        public static List<Offers> Search(SearchOptionsDTO searchOptions) 
        {
            try
            {
                List<Offers> offers = new List<Offers>();
                List<OfferElements> elems = new List<OfferElements>();
                using (var session = NH.OpenSession())
                {
                    var results = session.Query<OfferElements>().Where(x=>x.TakeLocation==searchOptions.TakeLocation).Fetch(x=>x.Cars).ThenFetch(x=>x.CarType).ToFuture();
                    if (!String.IsNullOrEmpty(searchOptions.CarType))
                    {
                        results= session.Query<OfferElements>().Where(x => x.Cars.CarType.Type == searchOptions.CarType).ToFuture();
                    }
                    if (!String.IsNullOrEmpty(searchOptions.CarBrand))
                    {
                        results = session.Query<OfferElements>().Where(x => x.Cars.CarType.Brand == searchOptions.CarBrand).ToFuture();
                    }
                    if (!String.IsNullOrEmpty(searchOptions.CarModel))
                    {
                        results = session.Query<OfferElements>().Where(x => x.Cars.CarType.Model == searchOptions.CarModel).ToFuture();
                    }
                    if (!String.IsNullOrEmpty(searchOptions.CarColor))
                    {
                        results = session.Query<OfferElements>().Where(x => x.Cars.CarType.Color == searchOptions.CarColor).ToFuture();
                    }
                    if (!String.IsNullOrEmpty(searchOptions.CarTransmission))
                    {
                        results = session.Query<OfferElements>().Where(x => x.Cars.CarType.Transmission == searchOptions.CarTransmission).ToFuture();
                    }
                    if (!String.IsNullOrEmpty(searchOptions.CarFuel))
                    {
                        results = session.Query<OfferElements>().Where(x => x.Cars.CarType.Fuel == searchOptions.CarFuel).ToFuture();
                    }
                    if (!String.IsNullOrEmpty(searchOptions.CarPower))
                    {
                        results = session.Query<OfferElements>().Where(x => x.Cars.CarType.Power == searchOptions.CarPower).ToFuture();
                    }
                    if (null != searchOptions.CarCapacity)
                    {
                        results = session.Query<OfferElements>().Where(x => x.Cars.CarType.Capacity == searchOptions.CarCapacity).ToFuture();
                    }
                    if (null != searchOptions.CarDoorQuantity)
                    {
                        results = session.Query<OfferElements>().Where(x => x.Cars.CarType.DoorQuantity == searchOptions.CarDoorQuantity).ToFuture();
                    }
                    if (null != searchOptions.CarSeatQuantity)
                    {
                        results = session.Query<OfferElements>().Where(x => x.Cars.CarType.SeatQuantity == searchOptions.CarSeatQuantity).ToFuture();
                    }
                    if (!String.IsNullOrEmpty(searchOptions.ReturnLocation))
                    {
                        results = session.Query<OfferElements>().Where(x => x.ReturnLocation == searchOptions.ReturnLocation).ToFuture();
                    }
                    if (null != searchOptions.StartTime)
                    {
                        results = session.Query<OfferElements>().Where(x => x.StartTime >= searchOptions.StartTime).ToFuture();
                    }
                    if (null != searchOptions.EndTime)
                    {
                        results = session.Query<OfferElements>().Where(x => x.EndTime >= searchOptions.EndTime).ToFuture();
                    }
                    if (null != searchOptions.DailyPrice)
                    {
                        results = session.Query<OfferElements>().Where(x => x.DailyPrice < searchOptions.DailyPrice).ToFuture();
                    }
                    elems = results.Skip((searchOptions.Page-1) * 10).Take(10).ToList();
                    var a = elems.Select(x => x.OfferId).ToList();

                    offers = session.Query<Offers>().Where(x => elems.Select(y => y.Offers).Contains(x)).ToList();
                }
                return offers;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}

using Brooming_pl.DBClasses;
using Brooming_pl.Model;
using Brooming_pl.Tools;
using NHibernate.Linq;
using NHibernate.Linq.ExpressionTransformers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brooming_pl.BusinessLogic
{
    public class UserOptions
    {
        public static List<Cars> MyCars(Users user) {
            try
            {
                List<Cars> carList = new List<Cars>();
                using (var session = NH.OpenSession())
                {
                    carList = session.Query<Cars>().Where(x => x.Users == user).ToList();
                    if (carList == null)
                    {
                        throw new UsersExceptions("This user have no cars");
                    }
                }
                return carList;
            }
            catch (Exception)
            {
                throw new System.Exception("Unknown exception");
            }
        }
        public static void AddCar(Users user, CarDTO carDTO)
        {
            try
            {
                using (var session = NH.OpenSession())
                {
                    if (null != session.Query<Cars>().Where(x => x.RegistrationNumber == carDTO.RegistrationNumber).FirstOrDefault())
                    {
                        throw new UsersExceptions("Car with this registration number already exists");
                    }
                }
                CarType carType = new CarType();
                carType.Type = carDTO.CarType.Type;
                carType.Brand = carDTO.CarType.Brand;
                carType.Model = carDTO.CarType.Model;
                carType.Color = carDTO.CarType.Color;
                carType.Transmission = carDTO.CarType.Transmission;
                carType.Fuel = carDTO.CarType.Fuel;
                carType.FuelUsage = carDTO.CarType.FuelUsage;
                carType.Power = carDTO.CarType.Power;
                carType.Capacity = carDTO.CarType.Capacity;
                carType.DoorQuantity = carDTO.CarType.DoorQuantity;
                carType.SeatQuantity = carDTO.CarType.SeatQuantity;
                CarType existing = new CarType();

                Company company = new Company();
                using (var session = NH.OpenSession())
                {
                    company = session.Query<Company>().Where(x => x.CompanyAgents.Contains(user)).FirstOrDefault();
                }

                Cars car = new Cars();
                car.Users = user;
                car.Company = company;
                car.RegistrationNumber = carDTO.RegistrationNumber;
                car.YearOfProduction = carDTO.YearOfProduction;
                car.Description = carDTO.Description;
                car.LinkToPhoto = carDTO.LinkToPhoto;
                car.Availability = 1;

                using (var session = NH.OpenSession())
                {
                    if (null != (existing = session.Query<CarType>().Where(x => x.Type == carType.Type).Where(x => x.Brand == carType.Brand).Where(x => x.Model == carType.Model)
                                .Where(x => x.Color == carType.Color).Where(x => x.Transmission == carType.Transmission).Where(x => x.Fuel == carType.Fuel)
                                .Where(x => x.FuelUsage == carType.FuelUsage).Where(x => x.Power == carType.Power).Where(x => x.Capacity == carType.Capacity)
                                .Where(x => x.DoorQuantity == carType.DoorQuantity).Where(x => x.SeatQuantity == carType.SeatQuantity).FirstOrDefault()))
                    {
                        car.CarType = existing;
                        session.Save(car);
                    }
                    else
                    {
                        session.Save(carType);
                        car.CarType = carType;
                        session.Save(car);
                    }
                }
            }
            catch (Exception)
            {
                throw new System.Exception("Unknown exception");
            }
        }
        //public static void RegisterCompany(AddCompanyDTO addCompanyDTO)
        //{
        //    try
        //    {
        //        Company company = new Company();
        //        company.CompanyName = addCompanyDTO.companyDTO.CompanyName;
        //        company.CompanyAdmin = addCompanyDTO.user;
        //        company.Adress = addCompanyDTO.companyDTO.Adress;
        //        company.TaxNumber = addCompanyDTO.companyDTO.TaxNumber;
        //        using (var session = NH.OpenSession())
        //        {
        //            if (null != session.Query<Company>().Where(x => x.CompanyName == company.CompanyName).FirstOrDefault())
        //            {
        //                throw new UsersExceptions("This company already exists");
        //            }
        //            else
        //            {
        //                session.Save(company);

        //                using (var transaction = session.BeginTransaction())
        //                {
        //                    transaction.Commit();
        //                }
        //            }
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        throw new System.Exception("Unknown exception");
        //    }
        //}

        public static void RegisterCompany(CompanyDTO companyDTO)
        {
            try
            {
                Company company = new Company();
                company.CompanyName = companyDTO.CompanyName;
                company.CompanyAdmin = companyDTO.User;
                company.Adress = companyDTO.Adress;
                company.TaxNumber = companyDTO.TaxNumber;
                using (var session = NH.OpenSession())
                {
                    if (null != session.Query<Company>().Where(x => x.CompanyName == company.CompanyName).FirstOrDefault())
                    {
                        throw new UsersExceptions("This company already exists");
                    }
                    else
                    {
                        session.Save(company);

                        using (var transaction = session.BeginTransaction())
                        {
                            transaction.Commit();
                        }
                    }
                }

            }
            catch (Exception)
            {
                throw new System.Exception("Unknown exception");
            }
        }

        public static void RemoveCar(Users user, Cars car)
        {
            try
            {
                using (var session = NH.OpenSession())
                {
                    session.Delete(session.Query<Cars>().Where(x => x.CarId == car.CarId).FirstOrDefault()); 
                }
            }
            catch (Exception)
            {
                throw new System.Exception("Unknown exception");
            }
        }
        //public static void DeleteUser(Users user)
        //{

        //}
        public static void AddOffer(List<OfferElements> listOfElements, Users user, OfferDTO offerDTO)
        {
            try
            {
                Offers offer = new Offers();
                offer.Users = user;
                offer.OfferDetail = offerDTO.OfferDetail;
                offer.DailyPrice = offerDTO.DailyPrice;
                offer.AdditionalInfo = offerDTO.AdditionalInfo;
                offer.OfferElements = listOfElements;

                using (var session = NH.OpenSession())
                {
                    session.Save(offer);
                    using (var transaction = session.BeginTransaction())
                    {
                        transaction.Commit();
                    }
                }
            }
            catch (Exception)
            {
                throw new System.Exception("Unknown exception");
            }
        }
    }
}


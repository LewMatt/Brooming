using Brooming_pl.DBClasses;
using Brooming_pl.Model;
using Brooming_pl.Tools;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using NHibernate.Linq;
using NHibernate.Linq.ExpressionTransformers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Brooming_pl.BusinessLogic
{
    public class UserOptions
    {
        public static Users GetUsers(int userId) 
        {
            try
            {
                Users user = new Users();
                using (var session = NH.OpenSession())
                {
                    user = session.Query<Users>().Where(x => x.UserId == userId).FirstOrDefault();
                }
                return user;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static List<Cars> GetMyCarsUser(int userId) {
            try
            {
                List<Cars> carList = new List<Cars>();
                using (var session = NH.OpenSession())
                {
                    carList = session.Query<Cars>().Where(x => x.Users.UserId == userId).ToList();
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
        public static List<Cars> GetMyCarsCompany(Company company) 
        {
            try
            {
                List<Cars> carList = new List<Cars>();
                using (var session = NH.OpenSession())
                {
                    carList = session.Query<Cars>().Where(x => x.Company == company).ToList();
                    if (carList == null)
                    {
                        throw new UsersExceptions("This company have no cars");
                    }
                }
                return carList;
            }
            catch (Exception)
            {
                throw new System.Exception("Unknown exception");
            }
        }
        public static void AddCar(int userId, CarDTO carDTO)
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
                carType.Type = carDTO.Type;
                carType.Brand = carDTO.Brand;
                carType.Model = carDTO.Model;
                carType.Color = carDTO.Color;
                carType.Transmission = carDTO.Transmission;
                carType.Fuel = carDTO.Fuel;
                carType.FuelUsage = carDTO.FuelUsage;
                carType.Power = carDTO.Power;
                carType.Capacity = carDTO.Capacity;
                carType.DoorQuantity = carDTO.DoorQuantity;
                carType.SeatQuantity = carDTO.SeatQuantity;
                CarType existing = new CarType();

                Company company = new Company();
                Users user = new Users();
                using (var session = NH.OpenSession())
                {
                    company = session.Query<Company>().Where(x => x.CompanyAgents.Contains(user)).FirstOrDefault();
                    user = session.Query<Users>().Where(x => x.UserId == userId).FirstOrDefault();
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
                    if (null != (existing = session.Query<CarType>().Where(x => x.Type == carType.Type)                 .Where(x => x.Brand == carType.Brand)
                                                                    .Where(x => x.Model == carType.Model)               .Where(x => x.Color == carType.Color)
                                                                    .Where(x => x.Transmission == carType.Transmission) .Where(x => x.Fuel == carType.Fuel)
                                                                    .Where(x => x.FuelUsage == carType.FuelUsage)       .Where(x => x.Power == carType.Power)
                                                                    .Where(x => x.Capacity == carType.Capacity)         .Where(x => x.DoorQuantity == carType.DoorQuantity)
                                                                    .Where(x => x.SeatQuantity == carType.SeatQuantity) .FirstOrDefault()))
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
        public static CompanyDTO RegisterCompany(CompanyDTO companyDTO) 
        {
            try
            {
                Users user = GetUsers(companyDTO.UserId);
                Company company = new Company();
                company.CompanyName = companyDTO.CompanyName;
                company.CompanyAdmin = user;
                company.Adress = companyDTO.Adress;
                company.TaxNumber = companyDTO.TaxNumber;
                using (var session = NH.OpenSession())
                {
                    if (null != session.Query<Company>().Where(x => x.CompanyName == companyDTO.CompanyName).FirstOrDefault())
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
                return companyDTO;
            }
            catch (Exception ex)
            {
                companyDTO.CompanyName = "This company already exists";
                return companyDTO;
            }
        }
        public static void RemoveCar( Cars car)
        {
            try
            {
                using (var session = NH.OpenSession())
                {
                    if(null == session.Query<Cars>().Where(x => x.CarId == car.CarId).FirstOrDefault())
                    {
                        throw new UsersExceptions("Car does not exist");
                    }
                    session.Delete(session.Query<Cars>().Where(x => x.CarId == car.CarId).FirstOrDefault()); 
                }
            }
            catch (Exception)
            {
                throw new System.Exception("Unknown exception");
            }
        }
        //public static void DeleteUser(Users user){}
        public static void AddRating(int userId, int companyId, RatingDTO rating)
        {
            try
            {
                Users user = new Users();
                using (var session = NH.OpenSession())
                {
                    user = session.Query<Users>().Where(x => x.UserId == userId).FirstOrDefault();
                }
                Ratings rate = new Ratings();
                Company company = new Company();
                using (var session = NH.OpenSession())
                {
                    company = session.Query<Company>().Where(x => x.CompanyId == companyId).FirstOrDefault();
                }
                rate.Comment = rating.Comment;
                rate.Company = company;
                rate.Rating = rating.Rating;
                rate.Users = user;
                using (var session = NH.OpenSession())
                {
                    if (null != session.Query<Ratings>().Where(x => x.Users == user).Where(x => x.Company == company))
                    {
                        throw new UsersExceptions("This user already rated this company");
                    }
                    else
                    {
                        session.Save(rate);
                        using (var transaction = session.BeginTransaction())
                        {
                            transaction.Commit();
                        }
                    }
                }
                company.SumOfRatings += rate.Rating;
                company.NumberOfRatings += 1;
                company.AverageRating = (float)(company.SumOfRatings / company.NumberOfRatings);
                using (var session = NH.OpenSession())
                {
                    session.Save(company);
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
        public static OfferElements AddOfferElement(OfferElementsDTO offerElementsDTO, int Id) 
        {
            try
            {
                Cars car = new Cars();
                using (var session = NH.OpenSession())
                {
                    car = session.Query<Cars>().Where(x => x.CarId == offerElementsDTO.CarId).FirstOrDefault();

                }
                OfferElements offerElement = new OfferElements();
                offerElement.Cars = car;
                offerElement.DailyPrice = offerElementsDTO.DailyPrice;
                offerElement.StartTime = offerElementsDTO.StartTime;
                offerElement.EndTime = offerElementsDTO.EndTime;
                offerElement.DailyPrice = offerElementsDTO.DailyPrice;
                offerElement.TakeLocation = offerElementsDTO.TakeLocation;
                offerElement.ReturnLocation = offerElementsDTO.TakeLocation;
                offerElement.AdditionalInfo = offerElementsDTO.AdditionalInfo;

                using (var session = NH.OpenSession())
                {
                    if (null != session.Query<Cars>().Where(x => x.CarId == offerElementsDTO.CarId).Where(x => x.Availability == 0))
                    {
                        throw new UsersExceptions("This car is not avalible");
                    }
                    else
                    {
                        car.Availability = 0;
                        session.Save(car);
                    }
                }
                using (var session = NH.OpenSession())
                {
                    session.Save(offerElement);
                    using (var transaction = session.BeginTransaction())
                    {
                        transaction.Commit();
                    }
                }
                return offerElement;
            }
            catch (Exception)
            {
                throw new System.Exception("Unknown exception");
            }
        }
        public static void AddOffer(List<OfferElementsDTO> listOfElements, int userId, OfferDTO offerDTO)
        {
            try
            {
                Users user = GetUsers(userId);
                Offers offer = new Offers();
                offer.Users = user;
                offer.OfferDetail = offerDTO.OfferDetail;
                offer.DailyPrice = offerDTO.DailyPrice;
                offer.AdditionalInfo = offerDTO.AdditionalInfo;

                using (var session = NH.OpenSession())
                {
                    session.Save(offer);
                    using (var transaction = session.BeginTransaction())
                    {
                        transaction.Commit();
                    }
                }
                foreach(OfferElementsDTO i in listOfElements)
                {
                    offer.OfferElements.Append(AddOfferElement(i, offer.OfferId));
                }
                

            }
            catch (Exception)
            {
                throw new System.Exception("Unknown exception");
            }
        }   
        public static List<Ratings> GetMyRatingsCompany(Company company)
        {
            try
            {
                List<Ratings> ratingsList = new List<Ratings>();
                using (var session = NH.OpenSession())
                {
                    ratingsList = session.Query<Ratings>().Where(x => x.Company == company).ToList();
                    if (ratingsList == null)
                    {
                        throw new UsersExceptions("This company have no ratings");
                    }
                }
                return ratingsList;
            }
            catch (Exception)
            {
                throw new System.Exception("Unknown exception");
            }
        }
        public static List<Offers> GetMyOffersUser(int userId)
        {
            try
            {
                List<Offers> offersList = new List<Offers>();
                using (var session = NH.OpenSession())
                {
                    offersList = session.Query<Offers>().Where(x => x.Users.UserId == userId).ToList();
                    if (offersList == null)
                    {
                        throw new UsersExceptions("This user have no offers");
                    }
                }
                return offersList;
            }
            catch (Exception)
            {
                throw new System.Exception("Unknown exception");
            }
        }
        public static RatingSummaryDTO GetMyRating(RatingSummaryDTO ratingSummary) 
        {
            try
            {
                using (var session = NH.OpenSession())
                {
                    ratingSummary.AverageRating = session.Query<Company>().Where(x => x.CompanyId == ratingSummary.CompanyID).FirstOrDefault().AverageRating;
                    if (ratingSummary.AverageRating == null)
                    {
                        throw new UsersExceptions("This company have no ratings");
                    }
                }
                return ratingSummary;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

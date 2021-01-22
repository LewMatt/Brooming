using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brooming_pl.BusinessLogic;
using Brooming_pl.DBClasses;
using Brooming_pl.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brooming_pl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        UserOptions _userOptions;
        public MenuController()
        {
            _userOptions = new UserOptions();
        }

        [HttpPost("AddCompany")]
        public CompanyDTO AddCompany([FromBody] CompanyDTO companyDTO)
        {
            return UserOptions.RegisterCompany(companyDTO);
        }

        [HttpPost("AddCar")]
        public ActionResult AddCar([FromBody] CarRegisterDTO carRegisterDTO)
        {
            try
            {
                //UserOptions.AddCar(carRegisterDTO);
                _userOptions.AddCar(carRegisterDTO);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            
            
        }

        [HttpPost("AddRating")]
        public void AddRating([FromBody] AddRatingDTO addRatingDTO)
        {
            UserOptions.AddRating(addRatingDTO);
        }

        [HttpGet("GetUser")]
        public Users GetUser([FromBody] GetUserDTO getUserDTO)
        {
            return UserOptions.GetUsers(getUserDTO.UserId);
        }

        [HttpGet("GetMyCars")]
        public List<Cars> GetMyCars([FromBody] GetUserDTO getUserDTO)
        {
            return UserOptions.GetMyCarsUser(getUserDTO.UserId);
        }

        [HttpGet("GetMyCompanyCars")]
        public List<Cars> GetMyCompanyCars([FromBody] CompanyIdDTO companyIdDTO)
        {
            return UserOptions.GetMyCarsCompany(companyIdDTO.CompanyId);
        }

        [HttpGet("GetMyCompanyRatings")]
        public List<Ratings> GetMyCompanyRatings([FromBody] CompanyIdDTO companyIdDTO)
        {
            return UserOptions.GetMyRatingsCompany(companyIdDTO);
        }

        [HttpGet("GetMyOffers")]
        public List<Offers> GetMyOffers([FromBody] GetUserDTO getUserDTO)
        {
            return UserOptions.GetMyOffersUser(getUserDTO);
        }

        [HttpGet("GetMyRating")]
        public RatingSummaryDTO GetMyRating([FromBody] RatingSummaryDTO ratingSummaryDTO)
        {
            return UserOptions.GetMyRating(ratingSummaryDTO);
        }

        [HttpPost("RemoveCar")]
        public void RemoveCar([FromBody] CarIdDTO carIdDTO)
        {
            UserOptions.RemoveCar(carIdDTO);
        }

        //[HttpPost("GetMyCarss")]
        //public List<Cars> GetMyCarss([FromBody] GetUserDTO getUserDTO)
        //{
        //    return UserOptions.GetMyCarsUserr(getUserDTO.UserId);
        //}

    }
}

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
        [HttpPost("AddCompany")]
        public CompanyDTO AddCompany([FromBody] CompanyDTO companyDTO)
        {
            return UserOptions.RegisterCompany(companyDTO);
        }
        
        [HttpPost("AddCar")]
        public void AddCar([FromBody] CarRegisterDTO carRegisterDTO)
        {
            UserOptions.AddCar(carRegisterDTO);
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
    }
}

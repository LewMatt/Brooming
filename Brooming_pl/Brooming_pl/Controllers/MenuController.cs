using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brooming_pl.BusinessLogic;
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
        

    }
}

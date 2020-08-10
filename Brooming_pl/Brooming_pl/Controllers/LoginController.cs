using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brooming_pl.DBClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brooming_pl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    { 
        [HttpGet("GetLogin")]
        public IActionResult GetLogin()
        {
            try
            {
                Users user = new Users();
                using(var session = NH.OpenSession())
                {
                    user = session.Query<Users>().Where(x => x.UserId == 1).FirstOrDefault();
                }
                return Ok(user);

            }
            catch(Exception)
            {
                return Ok();

            }
        }
        

    }
}

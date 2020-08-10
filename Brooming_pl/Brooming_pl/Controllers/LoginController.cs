using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        public IActionResult GetLogin(string login, string password)
        {
            try
            {
                Users user = new Users();
                using(var session = NH.OpenSession())
                {

                    user = session.Query<Users>().Where(x => x.Login == login).Where(x => x.Password == password).FirstOrDefault();
                    if (user == null) {
                        return Ok("Wrong password or login");
                    }
                }
                return Ok(user.Role);

            }
            catch(Exception e)
            {
                return Ok("");
            }
        }
        public IActionResult GetRegister(string login, string password, string firstName, string surmane, string address, 
                                         DateTime dateOfBirth, int phoneNumber, string email, string linkToAvatar) 
        {


            return Ok();
        }

    }
}

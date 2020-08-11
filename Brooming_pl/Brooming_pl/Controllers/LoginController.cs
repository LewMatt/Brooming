using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Brooming_pl.DBClasses;
using Brooming_pl.Model;
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
                using (var session = NH.OpenSession())
                {

                    user = session.Query<Users>().Where(x => x.Login == login).Where(x => x.Password == password).FirstOrDefault();
                    if (user == null) {
                        return Ok("Wrong password or login");
                    }
                }
                return Ok(user.FirstName);

            }
            catch (Exception)
            {
                return Ok("Nie dziala.");
            }
        }

        [HttpGet("test")]
        public string Test()
        {
            try
            {
                string test = "dziala";
                return test;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
        
        [HttpPost("Login")]
        public LoginDTO Login([FromBody]LoginDTO loginDTO) 
        {
            try
            {

                Users user = new Users();

                using (var session = NH.OpenSession())
                {

                    user = session.Query<Users>().Where(x => x.Login == loginDTO.Login).Where(x => x.Password == loginDTO.Password).FirstOrDefault();

                    if (user == null)
                    {
                        return null;
                    }
                }
                user.Password = "";

                LoginDTO test = new LoginDTO()
                {
                    Login = user.Login,
                    Password = user.Password
                };

                return test;
            }

            catch(Exception ex)
            {
                throw ex;
            }
        }

        
    }
}

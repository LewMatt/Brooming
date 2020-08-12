using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    public class LoginController : ControllerBase
    {
        //[HttpGet("GetLogin")]
        //public IActionResult GetLogin(string login, string password)
        //{
        //    try
        //    {
        //        Users user = new Users();
        //        using (var session = NH.OpenSession())
        //        {

        //            user = session.Query<Users>().Where(x => x.Login == login).Where(x => x.Password == password).FirstOrDefault();
        //            if (user == null) {
        //                return Ok("Wrong password or login");
        //            }
        //        }
        //        return Ok(user);

        //    }
        //    catch (Exception)
        //    {
        //        return Ok("Nie dziala.");
        //    }
        //}

        //[HttpGet("test")]
        //public string Test()
        //{
        //    try
        //    {
        //        string test = "dziala";
        //        return test;
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        
        
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

                LoginDTO dtoObj = new LoginDTO()
                {
                    UserId = user.UserId,
                    Login = user.Login,
                    Password = user.Password,
                    FirstName = user.FirstName,
                    Surname = user.Surname,
                    Adress = user.Adress,
                    DateOfBirth = user.DateOfBirth,
                    PhoneNumber = user.PhoneNumber,
                    EMail = user.EMail,
                    LinkToAvatar = user.LinkToAvatar,
                    Role = user.Role

                };

                return dtoObj;
            }

            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Register")]
        public RegisterDTO Register([FromBody] RegisterDTO registerDTO)
        {
            try
            {
                using(var session = NH.OpenSession())
                {
                    int res = session.Query<Users>().Where(x => x.Login == registerDTO.Login).Count();
                    if(res == 1)
                    {
                        return null;
                    }
                }

                if((DateTime.TryParse(registerDTO.DateOfBirth,out DateTime date) == false))
                {
                    return null;
                }
                DateTime dat = DateTime.Parse(registerDTO.DateOfBirth);

                Users user = new Users()
                {
                    Login = registerDTO.Login,
                    Password = registerDTO.Password,
                    FirstName = registerDTO.FirstName,
                    Surname = registerDTO.Surname,
                    Adress = registerDTO.Adress,
                    DateOfBirth = dat,
                    PhoneNumber = registerDTO.PhoneNumber,
                    EMail = registerDTO.EMail,
                    LinkToAvatar = registerDTO.LinkToAvatar,
                    Role = "User"
                };
                
                using (var session = NH.OpenSession())
                {

                    session.Save(user);

                    using (var transaction = session.BeginTransaction())
                    {
                        transaction.Commit();
                    }
                }

                return registerDTO;


            }
            catch(Exception ex)
            {
               throw ex;
            }
        }
        
    }
}

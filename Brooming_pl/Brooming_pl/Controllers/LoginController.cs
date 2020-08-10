﻿using System;
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
                using(var session = NH.OpenSession())
                {

                    user = session.Query<Users>().Where(x => x.Login == login).Where(x => x.Password == password).FirstOrDefault();
                    if (user == null) {
                        return Ok("Wrong password or login");
                    }
                }
                return Ok(user.Role);

            }
            catch(Exception)
            {
                return Ok("");
            }
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody]LoginDTO loginDTO) 
        {
            //loginDTO.Login;
            return Ok();
        }


    }
}

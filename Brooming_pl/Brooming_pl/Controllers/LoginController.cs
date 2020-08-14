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

        [HttpPost("Login")]
        public LoginDTO Login([FromBody] LoginDTO loginDTO)
        {
            return LoginOptions.Login(loginDTO);
        }

        [HttpPost("Register")]
        public RegisterDTO Register([FromBody] RegisterDTO registerDTO)
        {
            return LoginOptions.Register(registerDTO);
        }
 
    }
}

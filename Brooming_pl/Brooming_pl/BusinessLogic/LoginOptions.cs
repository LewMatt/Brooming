using Brooming_pl.DBClasses;
using Brooming_pl.Model;
using Brooming_pl.Tools;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Linq;
using NHibernate.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brooming_pl.BusinessLogic
{
    public class LoginOptions
    {
 
        public static LoginDTO Login(LoginDTO loginDTO)
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
                    Role = user.Role,
                    


                };

                return dtoObj;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static RegisterDTO Register(RegisterDTO registerDTO)
        {
            try
            {
                using (var session = NH.OpenSession())
                {
                    int res = session.Query<Users>().Where(x => x.Login == registerDTO.Login).Count();
                    if (res == 1)
                    {
                        return null;
                    }
                }

                if ((DateTime.TryParse(registerDTO.DateOfBirth, out DateTime date) == false))
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using Brooming_pl.DBClasses;
using Brooming_pl.Model;
using Brooming_pl.Tools;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brooming_pl.BusinessLogic
{
    public class LoginOptions
    {
        public static Users LogIn(LoginDTO loginDTO)
        {
            try
            {
                Users user = new Users();
                using (var session = NH.OpenSession())
                {

                    user = session.Query<Users>().Where(x => x.Login == loginDTO.Login).Where(x => x.Password == loginDTO.Password).FirstOrDefault();
                    if (user == null)
                    {
                        throw new UsersExceptions("User not found");
                    }
                }
                return user;
            }
            catch (Exception)
            {
                throw new System.Exception("Unknown exception");
            }
        }

        //public static Users RegisterIn(RegisterDTO registerDTO) 
        //{
        //    try
        //    {
        //        using (var session = NH.OpenSession())
        //        {
        //            if (null != session.Query<Users>().Where(x => x.Login == registerDTO.Login).FirstOrDefault())
        //            {
        //                throw new UsersExceptions("User with that Login already exists");
        //            }
        //        }

        //        Users user = new Users();

        //        user.Login = registerDTO.Login;
        //        user.Password = registerDTO.Password;
        //        user.FirstName = registerDTO.FirstName;
        //        user.Surname = registerDTO.Surname;
        //        user.Adress = registerDTO.Adress;
        //        //user.DateOfBirth = registerDTO.DateOfBirth;
        //        user.PhoneNumber = registerDTO.PhoneNumber;
        //        user.EMail = registerDTO.EMail;
        //        user.LinkToAvatar = registerDTO.LinkToAvatar;
        //        user.Login = registerDTO.Login;
        //        user.Role = "User";

        //        using (var session = NH.OpenSession())
        //        {

        //            session.Save(user);

        //            using (var transaction = session.BeginTransaction())
        //            {
        //                transaction.Commit();
        //            }
        //        }
        //        return user;
        //    }
        //    catch (Exception)
        //    {
        //        throw new System.Exception("Unknown exception");
        //    }
        //}

        public RegisterDTO Register(RegisterDTO registerDTO)
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

using Business.FormModel;
using Database.DatabaseConnection;
using Microsoft.AspNetCore.Identity;
using Database.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class UserService
    {
        BuyingHouseDB buyingHouseDB = new BuyingHouseDB();

        public Result Registration(UserForm user)
        {
            bool x = buyingHouseDB.UserInfo.Any(
                x => x.UserEmail == user.UserEmail);
            if (x) return new Result(false,
                "Email Already registered!");

            UserInfo userInfo = new UserInfo();
            userInfo.UserName = user.UserName;
            userInfo.UserEmail = user.UserEmail;

            userInfo.UserPasswordHash = new PasswordHasher<
                UserInfo>().HashPassword(userInfo, user.UserPassword);
            userInfo.IsActive = true;
            buyingHouseDB.UserInfo.Add(userInfo);

            try
            {
                buyingHouseDB.SaveChanges();
                return new Result(true,
                "Registered Succefully!",null);
            }
            catch (Exception ex) 
                {
                    return new Result(false, ex.Message);
                }
        }
    }
}

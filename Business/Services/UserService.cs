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

        public Result Registration(UserRegister user)
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
                return new Result().DBCommit(buyingHouseDB,
                "Registered Succefully!",null,user);
            }
            catch (Exception ex) 
                {
                    return new Result(false, ex.Message);  
                }
        }

        public Result Login(UserLogin user)
        {
            UserInfo? userInfo = buyingHouseDB.UserInfo.Where(
                x => x.UserEmail == user.UserEmail).FirstOrDefault();

            if (userInfo == null) return new Result(false, "Register First");

            PasswordVerificationResult HashResult = new PasswordHasher<
                UserInfo>().VerifyHashedPassword(userInfo,
                userInfo.UserPasswordHash, user.UserPassword);

            if(HashResult!=PasswordVerificationResult.Failed)
            {
                return new Result(true, $"{userInfo.UserName} successfully logged in!");

            }
            else
            {
                return new Result(false, "Incorrect Password!");
            }
        }

        public Result AdminLogin(UserLogin user)
        {
            bool x = false;
            if(user.UserEmail == "admin@gmail.com") { x = true; }

            UserInfo userInfo = new UserInfo();

            PasswordVerificationResult HashResult = new PasswordHasher<
                UserInfo>().VerifyHashedPassword(userInfo,
                userInfo.UserPasswordHash, user.UserPassword);

            if(HashResult != PasswordVerificationResult.Failed && x==true)
            {
                return new Result(true, $"{userInfo.UserName} successfully logged in!");
            }
            else
            {
                return new Result(false, "Invalid Input!");
            }
        }
    }
}

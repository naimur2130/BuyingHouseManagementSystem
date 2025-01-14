using Database.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Result
    {
        public bool Success { get; set; }
        public string Message { get; set; } = "Hello Successful";
        public object? Data { get; set; }
        public Result() { }
        public Result(bool success, string message, object? Data = null)
        {
            this.Success = Success;
            this.Message = Message;
            this.Data = Data;
        }

        //public Result DBCommit(BuyingHouseDB buyingHouseDB,
        //    string Message, string? FailedMessage = null,
        //    object? Data = null)
        //{
        //    try
        //    {
        //        buyingHouseDB.SaveChanges();
        //        return new Result(true, Message, Data);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new Result(false, FailedMessage ?? ex.Message);
        //    }
        //}


    }
}

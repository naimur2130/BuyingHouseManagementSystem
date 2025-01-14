using Database.DatabaseConnection;
using Database.TableModel;
using System.Data;
// See https://aka.ms/new-console-template for more information

var db = new BuyingHouseDB();
try
{
    if (db.UserInfo != null)
    {
        for (int i = 0; i < 50; i++)
        {
            db.UserInfo.Add(new UserInfo
            {
                UserName = "User-" + i,
                UserEmail = "User" + i + "@user.user",
                UserPasswordHash = "Hash" + i,
                IsActive = i % 2 == 0,
            });
        }
        db.SaveChanges();
    }

    db.SaveChanges();

}


catch (Exception ex)
{
    Console.WriteLine("An error occurred: " + ex.Message);
    if (ex.InnerException != null)
    {
        Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
    }
}

Console.WriteLine(DateTime.Now);



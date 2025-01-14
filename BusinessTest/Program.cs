// See https://aka.ms/new-console-template for more information
using Business;
using Business.FormModel;
using Business.Services;
using Microsoft.AspNetCore.Identity;

Console.WriteLine("Hello, World!");

Registration();
static void Registration()
{
    UserForm userForm = new UserForm();
    Console.WriteLine("Enter the name :");
    userForm.UserName = Console.ReadLine();
    Console.WriteLine("Enter a valid email Address : ");
    userForm.UserEmail = Console.ReadLine();
    Console.WriteLine("Enter the password : ");
    userForm.UserPassword = Console.ReadLine();
    Result result = new UserService().Registration(userForm);
    Console.WriteLine(result.Message);
}

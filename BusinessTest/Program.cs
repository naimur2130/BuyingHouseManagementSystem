// See https://aka.ms/new-console-template for more information
using Business;
using Business.FormModel;
using Business.Services;
using Microsoft.AspNetCore.Identity;

Console.WriteLine("Hello, World!");

//Registration();
///login();
addProduct();
//deleteProduct();
//updateProduct();
static void Registration()
{
    UserRegister userForm = new UserRegister();
    Console.WriteLine("Enter the name :");
    userForm.UserName = Console.ReadLine();
    Console.WriteLine("Enter a valid email Address : ");
    userForm.UserEmail = Console.ReadLine();
    Console.WriteLine("Enter the password : ");
    userForm.UserPassword = Console.ReadLine();
    Result result = new UserService().Registration(userForm);
    Console.WriteLine(result.Message);
}

static void login()
{
    UserLogin userLogin = new UserLogin();
    Console.WriteLine("Enter the email");
    userLogin.UserEmail = Console.ReadLine();
    Console.WriteLine("Enter the password");
    userLogin.UserPassword = Console.ReadLine();

    Result result = new UserService().Login(userLogin);
    Console.WriteLine(result.Message);
}

static void addProduct()
{
    
    ProductForm productForm = new ProductForm();
    Console.WriteLine("Enter the Admin Email: ");
    String AdminEmail = Console.ReadLine();
    Console.WriteLine("Enter the Product Name: ");
    productForm.ProductName = Console.ReadLine();
    Console.WriteLine("Enter the Size ID: ");
    productForm.SizeId = int.Parse(Console.ReadLine());
    Console.WriteLine("Enter the Category ID: ");
    productForm.CategoryId = int.Parse(Console.ReadLine());
    Console.WriteLine("Enter the Brand ID: ");
    productForm.BrandId = int.Parse(Console.ReadLine());
    Console.WriteLine("Enter the Latest Price of the product: ");
    productForm.LatestPrice = float.Parse(Console.ReadLine());

    Console.WriteLine("Enter the quantity of the product: ");
    productForm.ProductQuantity = int.Parse(Console.ReadLine());


    Result result =  new ProductService().AddProduct(productForm,AdminEmail);
    Console.WriteLine(result.Message);

}

static void deleteProduct()
{
    ProductForm pro = new ProductForm();
    Console.WriteLine("Enter the Category Id: ");
    pro.CategoryId = int.Parse(Console.ReadLine());
    Console.WriteLine("Enter the Size Id: ");
    pro.SizeId = int.Parse(Console.ReadLine());
    Console.WriteLine("Enter the Brand Id: ");
    pro.BrandId = int.Parse(Console.ReadLine());

    Result result = new ProductService().DeleteProduct(pro);
    Console.WriteLine(result.Message);
}

static void updateProduct()
{
    ProductForm pro = new ProductForm();
    Console.WriteLine("Enter the Product Name: ");
    pro.ProductName = Console.ReadLine();
    Console.WriteLine("Enter the Category Id: ");
    pro.CategoryId = int.Parse(Console.ReadLine());
    Console.WriteLine("Enter the Size Id: ");
    pro.SizeId = int.Parse(Console.ReadLine());
    Console.WriteLine("Enter the Brand Id: ");
    pro.BrandId = int.Parse(Console.ReadLine());

    Console.WriteLine("Enter the new quantity!");
    pro.ProductQuantity = int.Parse(Console.ReadLine());
    Console.WriteLine("Enter the new Price: ");
    pro.LatestPrice = double.Parse(Console.ReadLine());

    Result result = new ProductService().UpdateProduct(pro);
    Console.WriteLine(result.Message);

}
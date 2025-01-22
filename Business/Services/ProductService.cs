using Database.DatabaseConnection;
using Database.TableModel;
using Business.FormModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class ProductService
    {
        BuyingHouseDB buyingHouseDB = new BuyingHouseDB();

        public Result AddProduct(ProductForm p, string AdminEmail,string imageUrl)
        {
            Product product = new Product();

            if (AdminEmail == "admin@gmail.com")
            {
                var result = buyingHouseDB.Product.FirstOrDefault(x => x.ProductName == p.ProductName && x.CategoryId == p.CategoryId
                && x.SizeId == p.SizeId && x.BrandId == p.BrandId);

                if (result != null)
                {
                    UpdateProduct(p);
                    return new Result(true, "Updated Successfully!");
                }
                else
                {
                    product.ProductName = p.ProductName;
                    product.CategoryId = p.CategoryId;
                    product.SizeId = p.SizeId;
                    product.BrandId = p.BrandId;
                    product.LatestPrice = p.LatestPrice;
                    product.ProductQuantity = p.ProductQuantity;
                    product.IsAvailable = true;

                    if (!string.IsNullOrEmpty(imageUrl))
                    {
                        product.ImageUrl = imageUrl; // Save the URL string to the database
                    }
                }
            }

            buyingHouseDB.Product.Add(product);

            try
            {
                buyingHouseDB.SaveChanges();
                return new Result().DBCommit(buyingHouseDB,
                "Product Added Successfully!", null, p);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        public Result DeleteProduct(ProductForm x)
        {

            var product = buyingHouseDB.Product.FirstOrDefault(p => p.SizeId == x.SizeId
            && p.BrandId == x.BrandId && p.CategoryId == x.CategoryId);

            if (product == null)
                return new Result(false, "Product cannot be found!");

            buyingHouseDB.Product.Remove(product);
            buyingHouseDB.SaveChanges();
            return new Result(true, "Product Deleted successfully!");
        }

        public Result UpdateProduct(ProductForm p)
        {
            try
            {
                var product = buyingHouseDB.Product.FirstOrDefault(x => x.ProductName == p.ProductName
                && x.CategoryId == p.CategoryId && x.SizeId == p.SizeId && x.BrandId == p.BrandId);

                if (product == null)
                {
                    return new Result(false, "Product not found");
                }

                product.LatestPrice += p.LatestPrice;
                product.ProductQuantity += p.ProductQuantity;

                buyingHouseDB.SaveChanges();

                return new Result(true, "Updated Successfuly");
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        public Result List()
        {
            try
            {
                var products = buyingHouseDB.Product.ToList();
                return new Result(true, "Successful", products);
            }
            catch (Exception ex)
            {
                return new Result(false,"Error");
            }
        }
        

        public async Task<List<Product>> GetProductsAsync()
        {
            return await buyingHouseDB.Product.ToListAsync();
        }
    }
}

        
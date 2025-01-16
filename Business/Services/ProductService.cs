using Database.DatabaseConnection;
using Database.TableModel;
using Business.FormModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ProductService
    {
        BuyingHouseDB buyingHouseDB = new BuyingHouseDB();

        public Result AddProduct(ProductForm p)
        {
            Product product = new Product();

            product.ProductName = p.ProductName;
            product.CategoryId = p.CategoryId;
            product.SizeId = p.SizeId;
            product.BrandId = p.BrandId;
            product.LatestPrice = p.LatestPrice;
            product.ProductQuantity = p.ProductQuantity;
            product.IsAvailable = true;

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

        public Result DeleteProduct(int sizeId, int categoryId, int brandId)
        {
            var product = buyingHouseDB.Product.FirstOrDefault(p => p.SizeId == sizeId
            && p.BrandId == brandId && p.CategoryId == categoryId);

            if (product == null)
                return new Result(false, "Product cannot be found!");

            buyingHouseDB.Product.Remove(product);
            buyingHouseDB.SaveChanges();
            return new Result(true, "Product Deleted successfully!");
        }

    }
}

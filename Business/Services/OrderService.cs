using Business.FormModel;
using Database.DatabaseConnection;
using Database.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class OrderService
    {
        BuyingHouseDB buyingHouseDB = new BuyingHouseDB();

        public Result AddOrderCart(OrderForm order)
        {

            var product = buyingHouseDB.Product.FirstOrDefault(p=> p.ProductId==order.ProductId
            && p.CategoryId==order.CategoryId && p.SizeId==order.SizeId && p.BrandId==order.BrandId);

            if(product==null)
            {
                return new Result(false, "Product not found");
            }

            if(product.ProductQuantity<order.OrderAmount)
            {
                return new Result(false,"Insufficient product.");
            }

            OrderCart addOrder = new OrderCart
            {
                ProductId = order.ProductId,
                SizeId = order.SizeId,
                BrandId = order.BrandId,
                CategoryId = order.CategoryId,
                OrderAmount = order.OrderAmount,
                TotalPrice = order.OrderAmount * product.LatestPrice,
                IsProcessed = false
            };

            product.ProductQuantity -= order.OrderAmount;
            buyingHouseDB.OrderCart.Add(addOrder);

            try
            {
                buyingHouseDB.SaveChanges();
                return new Result(true, "Order placed successfully!");
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        public Result OrderList()
        {
            try
            {
                var products = buyingHouseDB.OrderCart.ToList();
                return new Result(true, "Successful", products);
            }
            catch (Exception ex)
            {
                return new Result(false, "Error");
            }
        }

        public Result DeleteOrder(string tempId)
        {
            var order = buyingHouseDB.OrderCart.FirstOrDefault(x => x.TempOrderID == tempId);
            if(order == null)
            {
                return new Result(false,"Cart Not found");
            }
            buyingHouseDB.OrderCart.Remove(order);
            buyingHouseDB.SaveChanges();

            return new Result(true,"Successfully deleted card");
        }
    }
}

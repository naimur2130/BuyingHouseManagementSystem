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

        public Result AddOrder(OrderForm order)
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

            Order addOrder = new Order
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
            buyingHouseDB.Order.Add(addOrder);

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
    }
}

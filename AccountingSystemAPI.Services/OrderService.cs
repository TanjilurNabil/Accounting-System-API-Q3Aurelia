using AccountingSystemAPI.DataAccess;
using AccountingSystemAPI.Interfaces;
using AccountingSystemAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystemAPI.Services
{
    public class OrderService : IOrder
    {
        private readonly ApplicationDbContext _db;
        public OrderService(ApplicationDbContext db)
        {
                _db = db;
        }
        public async Task<Order> AddNewOrder(Order order)
        {
            await _db.AddAsync(order);
            await _db.SaveChangesAsync();
            return order;
        }

        public async Task DeleteOrder(int orderId)
        {
            var data = await _db.Orders.FirstOrDefaultAsync(x => x.OrderId == orderId);
            if (data != null)
            {
                 _db.Orders.Remove(data);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<Order> EditOrder(int orderId, Order updateBody)
        {
            var data = await _db.Orders.FirstOrDefaultAsync(x=>x.OrderId == orderId);
            if (data != null)
            {
                data.ProductId = updateBody.ProductId;
                data.SellingPrice = updateBody.SellingPrice;
                data.SellingUnit = updateBody.SellingUnit;
                if (_db.Entry(updateBody).State != EntityState.Unchanged)
                {
                    _db.Update(updateBody);
                    await _db.SaveChangesAsync();
                }
                return updateBody;
            }
            return null;
        }

        public Task<List<Order>> GetAllOrder()
        {
            return  _db.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            return await _db.Orders.FindAsync(orderId);
        }
    }
}

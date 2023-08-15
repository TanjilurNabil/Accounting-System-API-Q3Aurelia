using AccountingSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystemAPI.Interfaces
{
    public interface IOrder
    {
        Task<Order> AddNewOrder(Order order);
        Task<List<Order>> GetAllOrder();
        Task<Order> EditOrder(int orderId, Order updateBody);
        Task<Order> GetOrderById(int orderId);
        Task DeleteOrder(int orderId);
    }
}

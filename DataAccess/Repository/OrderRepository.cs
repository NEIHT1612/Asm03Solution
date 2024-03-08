using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void DeleteOrder(int OrderId) => OrderDAO.Instance.Remove(OrderId);

        public Order GetOrderByID(int OrderId) => OrderDAO.Instance.GetOrderByID(OrderId);

        public IEnumerable<Order> GetOrders() => OrderDAO.Instance.GetOrderList();

        public void InsertOrder(Order order) => OrderDAO.Instance.AddNew(order);

        public void UpdateOrder(Order order) => OrderDAO.Instance.Update(order);
    }
}

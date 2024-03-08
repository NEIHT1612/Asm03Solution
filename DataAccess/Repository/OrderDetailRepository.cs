using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void DeleteOrderDetail(int OrderId) => OrderDetailDAO.Instance.Remove(OrderId);

        public OrderDetail GetOrderDetailByID(int OrderId) => OrderDetailDAO.Instance.GetOrderDetailByID(OrderId);

        public IEnumerable<OrderDetail> GetOrderDetails() => OrderDetailDAO.Instance.GetOrderDetailList();

        public void InsertOrderDetail(OrderDetail orderdetail) => OrderDetailDAO.Instance.AddNew(orderdetail);

        public void UpdateOrderDetail(OrderDetail orderdetail) => OrderDetailDAO.Instance.Update(orderdetail);
    }
}

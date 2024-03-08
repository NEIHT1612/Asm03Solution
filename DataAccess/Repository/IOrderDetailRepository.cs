using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetOrderDetails();
        OrderDetail GetOrderDetailByID(int OrderId);
        void InsertOrderDetail(OrderDetail orderdetail);
        void DeleteOrderDetail(int OrderId);
        void UpdateOrderDetail(OrderDetail orderdetail);
    }
}

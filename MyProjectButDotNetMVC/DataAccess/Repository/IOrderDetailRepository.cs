using MyProjectButDotNetMVC.Models;

namespace MyProjectButDotNetMVC.DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetByOrderId(int orderId);
        OrderDetail? GetById(int orderId, int productId);
        IEnumerable<OrderDetail> GetBetweenDays(DateTime from, DateTime to);
        void Insert(OrderDetail member);
        void Update(OrderDetail member);
        void Remove(int orderId, int productId);
    }

}

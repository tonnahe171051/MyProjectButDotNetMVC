using MyProjectButDotNetMVC.Models;

namespace MyProjectButDotNetMVC.DataAccess.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Order? GetById(int id);
        IEnumerable<Order> GetByMemberId(int id);
        void Insert(Order member);
        void Update(Order member);
        void Remove(int id);
    }

}

using MyProjectButDotNetMVC.Models;

namespace MyProjectButDotNetMVC.DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public IEnumerable<Order> GetAll() => OrderDAO.Instance.GetAll();

        public Order? GetById(int id) => OrderDAO.Instance.GetById(id);

        public IEnumerable<Order> GetByMemberId(int id) => OrderDAO.Instance.GetByMemberId(id);

        public void Insert(Order member) => OrderDAO.Instance.Add(member);

        public void Remove(int id) => OrderDAO.Instance.Remove(id);

        public void Update(Order member) => OrderDAO.Instance.Update(member);
    }

}

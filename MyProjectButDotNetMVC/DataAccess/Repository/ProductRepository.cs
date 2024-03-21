using MyProjectButDotNetMVC.Models;

namespace MyProjectButDotNetMVC.DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetAll() => ProductDAO.Instance.GetAll();

        public Product? GetById(int id) => ProductDAO.Instance.GetById(id);

        public void Insert(Product member) => ProductDAO.Instance.Add(member);

        public void Remove(int id) => ProductDAO.Instance.Remove(id);

        public void Update(Product member) => ProductDAO.Instance.Update(member);
    }

}

using EShoppingAPI.Interface;
using EShoppingAPI.Model;

namespace EShoppingAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext dbContext;
        public ProductRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool CreateItem(Product item)
        {
            this.dbContext.Product.Add(item);
            this.dbContext.SaveChanges();
            return true;
        }

        public bool DeleteItem(int id)
        {
            var obj = this.dbContext.Product.FirstOrDefault(item => item.Id == id);
            if(obj != null)
            {
                this.dbContext.Remove(obj);
                this.dbContext.SaveChanges();
            }
            return obj != null;
        }

        public List<Product> GetAllItems()
        {
            return this.dbContext.Product.ToList();
        }

        public Product GetItemById(int id)
        {
            return this.dbContext.Product.FirstOrDefault(item => item.Id == id);
        }

        public Product UpdateItem(Product item)
        {
            var exists = this.dbContext.Product.Any(p => p.Id == item.Id);
            if (exists == true)
            {
                this.dbContext.Product.Update(item);
                this.dbContext.SaveChanges();
                return item;
            }
            return null;
        }
    }
}

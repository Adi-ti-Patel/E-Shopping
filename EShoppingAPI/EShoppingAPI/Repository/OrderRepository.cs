using EShoppingAPI.Interface;
using EShoppingAPI.Model;

namespace EShoppingAPI.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext dbContext;
        public OrderRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool CreateItem(Order item)
        {
            this.dbContext.Order.Add(item);
            this.dbContext.SaveChanges();
            return true;
        }

        public bool DeleteItem(int id)
        {
            var obj = this.dbContext.Order.FirstOrDefault(item => item.Id == id);
            if (obj != null)
            {
                this.dbContext.Remove(obj);
                this.dbContext.SaveChanges();
            }
            return obj != null;
        }

        public List<Order> GetAllItems()
        {
            return this.dbContext.Order.ToList();
        }

        public Order GetItemById(int id)
        {
            return this.dbContext.Order.FirstOrDefault(item => item.Id == id);
        }

        public Order UpdateItem(Order item)
        {
            var exists = this.dbContext.Order.Any(p => p.Id == item.Id);
            if (exists == true)
            {
                this.dbContext.Order.Update(item);
                this.dbContext.SaveChanges();
                return item;
            }
            return null;
        }
    }
}

using EShoppingAPI.Interface;
using EShoppingAPI.Model;

namespace EShoppingAPI.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly ApplicationDbContext dbContext;
        public InventoryRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool CreateItem(Inventory item)
        {
            this.dbContext.Inventory.Add(item);
            this.dbContext.SaveChanges();
            return true;
        }

        public bool DeleteItem(int id)
        {
            var obj = this.dbContext.Inventory.FirstOrDefault(item => item.Id == id);
            if (obj != null)
            {
                this.dbContext.Remove(obj);
                this.dbContext.SaveChanges();
            }
            return obj != null;
        }

        public List<Inventory> GetAllItems()
        {
            return this.dbContext.Inventory.ToList();
        }

        public Inventory GetItemById(int id)
        {
            return this.dbContext.Inventory.FirstOrDefault(item => item.Id == id);
        }

        public Inventory UpdateItem(Inventory item)
        {
            var exists = this.dbContext.Inventory.Any(p => p.Id == item.Id);
            if (exists == true)
            {
                this.dbContext.Inventory.Update(item);
                this.dbContext.SaveChanges();
                return item;
            }
            return null;
        }
    }
}

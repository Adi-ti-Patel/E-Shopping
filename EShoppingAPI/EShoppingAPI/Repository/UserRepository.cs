using EShoppingAPI.Interface;
using EShoppingAPI.Model;

namespace EShoppingAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext dbContext;
        public UserRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool CreateItem(User item)
        {
            this.dbContext.User.Add(item);
            this.dbContext.SaveChanges();
            return true;
        }

        public bool DeleteItem(int id)
        {
            var obj = this.dbContext.User.FirstOrDefault(item => item.Id == id);
            if (obj != null)
            {
                this.dbContext.Remove(obj);
                this.dbContext.SaveChanges();
            }
            return obj != null;
        }

        public List<User> GetAllItems()
        {
            return this.dbContext.User.ToList();
        }

        public User GetItemById(int id)
        {
            return this.dbContext.User.FirstOrDefault(item => item.Id == id);
        }

        public User UpdateItem(User item)
        {
            var exists = this.dbContext.User.Any(p => p.Id == item.Id);
            if (exists == true)
            {
                this.dbContext.User.Update(item);
                this.dbContext.SaveChanges();
                return item;
            }
            return null;
        }
    }
}

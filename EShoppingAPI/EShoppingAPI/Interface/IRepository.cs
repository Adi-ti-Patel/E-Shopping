namespace EShoppingAPI.Interface
{
    public interface IRepository<T>
    {
        List<T> GetAllItems();

        T GetItemById(int id);

        bool CreateItem(T item);

        T UpdateItem(T item);

        bool DeleteItem(int id);
    }
}

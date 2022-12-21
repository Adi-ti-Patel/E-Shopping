namespace EShoppingAPI.Model
{
    public class Order
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public DateTime OrderedDate { get; set; }

        public string Status { get; set; }

        public int UserId { get; set; }
    }
}

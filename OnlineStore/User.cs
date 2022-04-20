namespace OnlineFruitStore
{
    public class User
    {
        public string UserName { get; set; }
        private readonly List<Order> ListOrders;

        public User(string name)
        {
            UserName = name;
            ListOrders = new List<Order>();
        }
    }
}
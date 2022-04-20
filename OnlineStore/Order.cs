namespace OnlineFruitStore
{
    public class Order
    {
        private readonly List<Product> Products;
        public decimal FullPrice { get; set; }
        public Order(List<Product> products)
        {
            Products = products;

            foreach(var product in products)
            {
                FullPrice += product.Price;
            }    
        }
    }
}
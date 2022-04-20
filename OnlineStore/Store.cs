namespace OnlineFruitStore
{
    public class Store
    {
        private readonly List<Product> Products;
        private readonly List<Product> Basket;
        private readonly List<Order> Orders;

        public Store()
        {
            Products = new List<Product>
            {
            new Product("Banana", 4),
            new Product("Lemon", 3),
            new Product("Melon", 5),
            new Product("Apple", 7),
            new Product("Strawberry", 6),
            new Product("Orange", 5),
            };

            Basket = new List<Product>();
            Orders = new List<Order>();
        }
        public void ShowCatalog()
        {
            Console.WriteLine("\nThis is our catalog:\n");
            Console.WriteLine("{0,-10} {1,11}", "Product name", "Price");

            ShowProducts(Products);
        }
        public void LeaveStore()
        {
            string keyWord = "0";
            string enterWord;

            Console.WriteLine("\nAre you sure?");
            Console.WriteLine("Press \"0\" to quit or any other key to continue");
            enterWord = Console.ReadLine();

            if (keyWord == enterWord)
            {
                Environment.Exit(0);
            }
        }

        public void ShowProducts(List<Product> products)
        {
            int number = 1;
            foreach (Product product in products)
            {
                Console.Write(number + ". ");
                product.Print();
                number++;
            }
        }

        public void AddToBasket(int numberProduct)
        {
            Basket.Add(Products[numberProduct - 1]);
            Console.WriteLine($"Product {Products[numberProduct - 1].Name} added succesfully");

            if (Basket.Count == 1)
            {
                Console.WriteLine($"Basket contains {Basket.Count} product");
            }
            else
            {
                Console.WriteLine($"Basket contains {Basket.Count} products");
            }
        }

        public void ShowBasket()
        {
            if (Basket.Count == 0)
            {
                Console.WriteLine($"Your basket is empty");
            }
            else
            {
                Console.WriteLine("Your basket contains:");
                ShowProducts(Basket);
            }
        }

        public void ClearBasket()
        {
            Basket.Clear();
            Console.WriteLine($"\nYour previous order was closed successfully. You can start creating a new order. ");
        }
    }
}
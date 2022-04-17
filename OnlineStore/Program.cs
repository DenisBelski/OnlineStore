using System;

namespace OnlineFruitStore
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public void Print()
        {
            Console.WriteLine($"{Name, -10} {Price, 10:c}");
        }
    }
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

        public void CreateOrder()
        {
            Order order = new Order(Basket);
            Orders.Add(order);

            Basket.Clear();
        }
    }
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
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to our online fruit store.\nDear customer, please select an option:\n");
            Console.WriteLine("1. Show the catalog of our online store.");
            Console.WriteLine("2. Exit the online store.");
            Console.Write("\nType a number, and then press Enter: ");

            Store onlineStore = new Store();
            bool endApp = false;

            while (!endApp)
            {
                int inputNumber = GetInputNumber();

                if (inputNumber <= 0 || inputNumber > 2 )
                {
                    Console.Write("This is not valid input. Please enter a number from the list above: ");
                    continue;
                }

                switch (inputNumber)
                {
                    case 1:
                        onlineStore.ShowCatalog();
                        break;
                    case 2:
                        onlineStore.LeaveStore();
                        break;
                    default:
                        break;
                }

                AddProduct(onlineStore); // TODO

                bool answer;
                Console.WriteLine("\nDo you want to see the basket? Enter 'yes' to add the product or or any other key to continue:");
                answer = CheckAnswer(Console.ReadLine());
                if (answer)
                {
                    onlineStore.ShowBasket();
                }

                Console.WriteLine("\nDo you want to create a new order? Enter 'yes' to create a new order or or any other key to continue:");
                answer = CheckAnswer(Console.ReadLine());
                if (answer)
                {
                    onlineStore.CreateOrder();
                }
            }
        }

        public static void AddProduct(Store onlineStore)
        {
            bool answer;

            do
            {
                Console.WriteLine("\nDo you want to add a product? Enter 'yes' to add a product or any other key to continue:");
                answer = CheckAnswer(Console.ReadLine());

                if (answer)
                {
                    onlineStore.ShowCatalog();
                    Console.WriteLine("\nChoose number of product which you want to add:");

                    int productNumber = GetInputNumber();
                    //CheckNumber(productNumber);

                    if (productNumber <= 0 || productNumber > 6) // TODO
                    {
                        Console.Write("This is not valid input. Please enter a number from the list above: ");
                    }
                    else
                    {
                        CheckAnswer(Console.ReadLine());
                        onlineStore.AddToBasket(productNumber);
                    }
                }
            }
            while (answer);
        }

        //private static int CheckNumber(int productNumber)
        //{
        //    if (productNumber <= 0 || productNumber > 6) // TODO
        //    {
        //        Console.Write("This is not valid input. Please enter a number from the list above: ");
        //    }

        //    return productNumber;
        //}

        public static int GetCorrectNumber()
        {
            string currentInput = Console.ReadLine();
            int inputNumber = 0;

            while (!int.TryParse(currentInput, out inputNumber))
            {
                Console.Write("This is not valid input. Please enter a number from the list above: ");
                currentInput = Console.ReadLine();
            }

            return inputNumber;
        }

        public static int GetInputNumber()
        {
            string currentInput = Console.ReadLine();
            int inputNumber = 0;

            while (!int.TryParse(currentInput, out inputNumber))
            {
                Console.Write("This is not valid input. Please enter a number from the list above: ");
                currentInput = Console.ReadLine();
            }

            return inputNumber;
        }

        static bool CheckAnswer(string answer)
        {
            return answer.ToLower() == "yes";
        }
    }
}
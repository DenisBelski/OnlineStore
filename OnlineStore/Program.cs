using System;

namespace OnlineFruitStore
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to our online fruit store.");
            AskCustomer();

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

                AddProduct(onlineStore);

                bool answer;
                Console.WriteLine("\nDo you want to see the basket? Enter 'yes' to add the product or any other key to continue:");
                answer = CheckAnswer(Console.ReadLine());
                if (answer)
                {
                    onlineStore.ShowBasket();
                }

                Console.WriteLine("\nWould you like to empty the basket? Enter 'yes' to empty the basket or any other key to continue:");
                answer = CheckAnswer(Console.ReadLine());
                if (answer)
                {
                    onlineStore.ClearBasket();
                }

                TryExit();
                AskCustomer();
            }
        }

        static void AskCustomer()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Dear customer, please select an option:\n");
            Console.WriteLine("1. Show the catalog of our online store.");
            Console.WriteLine("2. Exit the online store.");
            Console.Write("\nType a number, and then press Enter: ");
        }

        static void AddProduct(Store onlineStore)
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

                    if (productNumber <= 0 || productNumber > 14)
                    {
                        Console.Write("\nThis is not valid input. Please use only available numbers. ");
                        onlineStore.ShowCatalog();
                    }
                    else
                    {
                        onlineStore.AddToBasket(productNumber);
                    }
                }
            }
            while (answer);
        }

        static int GetCorrectNumber()
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

        static int GetInputNumber()
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

        static void TryExit()
        {
            string keyWord = "0";
            string enterWord;

            Console.WriteLine("\nDo you want to quit?");
            Console.WriteLine("Press \"0\" to quit or any other key to continue");
            enterWord = Console.ReadLine();

            if (keyWord == enterWord)
            {
                Environment.Exit(0);
            }
        }
    }
}
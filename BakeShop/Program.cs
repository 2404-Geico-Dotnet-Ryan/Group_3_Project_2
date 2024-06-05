using System;
class Program
{
    static FoodService? fs;
    static UserService? us;
    static User? currentUser = null;

    static void Main(string[] args)
    {
        public static void Welcome()
        {
            Console.WriteLine("<><><><><><><><><><><><><><><><><><>");
            Console.WriteLine("<><><>Welcome to the Bake Shop<><><>");
            Console.WriteLine("<><><><><><><><><><><><><><><><><><>");
            Console.WriteLine();

            bool keepGoing = true;
            while (keepGoing)
            {
                Console.WriteLine("What would you like to do today?");
                Console.WriteLine("<><><><><><><><><><><><><><><><><>");
                Console.WriteLine();
                Console.WriteLine("[1] Login");
                Console.WriteLine("[2] Register");
                Console.WriteLine("[0] Exit Application");

                int gInput = int.Parse(Console.ReadLine() ?? "0");
                gInput = ValidateCmd(gInput, 2);
                keepGoing = GeneralNextSteps(gInput);
            }
        }
        public static bool GeneralNextSteps(int gInput)
        {
            switch (gInput)
            {
                case 1:
                    {
                        Login();
                        break;
                    }
                case 2:
                    {
                        Register();
                        break;
                    }
                case 0:
                default:
                    return false;
            }
            return true;
        }
        public static void Register()
        {
            Console.WriteLine("Please enter a user name: ");
            string userName = Console.ReadLine() ?? "";

            Console.WriteLine("Please enter a password: ");
            string password = Console.ReadLine() ?? "";

            User? newUser = new(0, userName, password, "user");
            newUser = us.Register(newUser);
            if (newUser != null)
            {
                Console.WriteLine("Your user name, " + userName + " has been created!");
            }
            else
            {
                Console.WriteLine("Registration was not successful, try again.");
                Welcome();
            }
            MainMenu();
        }
        public static void Login()
        {

            while (currentUser == null)
            {
                Console.WriteLine("Please enter your user name: ");
                string userName = Console.ReadLine() ?? "";

                Console.WriteLine("Please enter your password: ");
                string password = Console.ReadLine() ?? "";

                currentUser = us.Login(userName, password);

                if (currentUser == null)
                    Console.WriteLine("Login was not successful, try again.");
            }
            MainMenu();
        }
        public static void MainMenu()
        {
            Console.WriteLine("Welcome, " + currentUser?.UserName);
            bool keepGoing = true;
            while (keepGoing)
            {
                Console.WriteLine("<><><><><><><><><><><><><><><><><>");
                Console.WriteLine("What would you like to do today?");
                Console.WriteLine("<><><><><><><><><><><><><><><><><>");
                Console.WriteLine();
                Console.WriteLine("[1] View Menu");
                Console.WriteLine("[2] Buy Bakery Item");
                Console.WriteLine("[3] View Last Purchased");
                Console.WriteLine("[0] Log Out");


                int cInput = int.Parse(Console.ReadLine() ?? "0");
                cInput = ValidateCmd(cInput, 3);
                keepGoing = NextSteps(cInput);
            }
            currentUser = null;

        }
        public static bool NextSteps(int cInput)
        {
            switch (cInput)
            {
                case 1:
                    {
                        ViewMenu();
                        break;
                    }
                case 2:
                    {
                        Buy();
                        break;
                    }
                case 3:
                    {
                        LastPurchased(currentUser);
                        break;
                    }
                case 0:
                default:
                    {
                        return false;
                    }
            }
            return true;
        }

        public static void ViewMenu()
        {
            List<Food> bakeryItems = fs.ViewMenu();
            Console.WriteLine("Available Baked Goods:");
            foreach (Food b in bakeryItems)
            {
                Console.WriteLine(b);
            }

        }
        public static void Buy()
        {
            while (true)
            {   //Pick an item:
                Food? bakeryItem = PromptUser();
                if (bakeryItem == null) return;
                bakeryItem = fs.BuyItem(bakeryItem);
                if (bakeryItem != null)
                {
                    Console.WriteLine("Added to your cart: " + bakeryItem);
                    break;
                }
            }
        }

        public static void LastPurchased(User? currentUser)
        {
            List<Food> purchase = fs.ViewLast(currentUser);
            foreach (Food a in purchase)
            {
                Console.WriteLine(a);
            }
        }

        // //Helper:
        public static Food PromptUser()
        {
            Food? retrievedFood = null;
            while (retrievedFood == null)
            {
                Console.WriteLine("Enter bakery item ID: ");
                int input = int.Parse(Console.ReadLine() ?? "0");
                retrievedFood = fs.ViewItem(input);
            }
            return retrievedFood;
        }
        public static int ValidateCmd(int cmd, int maxOption)
        {
            while (cmd < 0 || cmd > maxOption)
            {
                System.Console.WriteLine("Invalid Command - Please Enter a command 1-" + maxOption + "; or 0 to Quit");
                cmd = int.Parse(Console.ReadLine() ?? "0");
            }
            return cmd;






        }



    }
}

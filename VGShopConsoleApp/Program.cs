using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace ShopConsoleApp
{
    class Program
    { 
        static void Main(string[] args)
        {
            //Main Menu

            Store s = new Store();
            Console.WriteLine("******************************************************************************************");
            Console.WriteLine("Welcome to Darik's Video Game Library and Storefront!");
            Console.WriteLine("First input the video game Console you're selling.");
            Console.WriteLine("Fill out the correct system type and sale cost. Then checkout!");
            Console.WriteLine("Also yout can add an item to your wishlist or access your current collection from pastebin");
            Console.WriteLine("You can even randomly be suggested a game to play from me collection");
            Console.WriteLine("******************************************************************************************");
            Console.WriteLine("Main Menu");
            Console.WriteLine("*********");

            int action = chooseAction();

            //beginning of the master loop requirement. 
            while (action != 9)
            {
                Console.WriteLine("Function " + action + " recieved good job!");
                Console.WriteLine("******************************************");
                switch (action)

                {
                    //first option, allows you to add consoles, type and price. Unlimited amounts can be added!

                    case 1:

                        Console.WriteLine("You chose to purchase/sell a system");

                        String gameMake = "";
                        String gameModel = "";
                        Decimal gamePrice = 0;

                        Console.WriteLine("Who is the console manufactuer (Sony, Nintendo, Etc.)?");
                        gameMake = Console.ReadLine();

                        Console.WriteLine("What is the game system?");
                        gameModel = Console.ReadLine();

                        Console.WriteLine("What is the cost?");
                        gamePrice = int.Parse(Console.ReadLine());

                        Cart newGame = new Cart(gameMake, gameModel, gamePrice);
                        s.GameList.Add(newGame);

                        printInventory(s);
                        break;

                        //this section allows you add items to your cart. 

                    case 2:

                        Console.WriteLine("You chose to add game system to your shopping cart");
                        printInventory(s);

                        Console.WriteLine("Which many would you like to buy? (amount)");
                        int gameChosen = int.Parse(Console.ReadLine());

                        s.ShoppingList.Add(s.GameList[gameChosen]);

                        printShoppingCart(s);

                        break;
                    //this selection allows you to get the final cost of your consoles/items for sale and checkout.

                    case 3:

                        printShoppingCart(s);
                        Console.WriteLine("The total cost of these systems is : " + s.Checkout());
                        break;

                    //This prints it out

                    case 4:
                        printBackOrder(s);
                        break;

                    //This option allows you to add items to your wishlist. Saved in .bin file.
                    //User can add and read from a .csv file - one of the option requirements.
                    //This ection also counts the amount of game in the wishlst after one is added. 

                    case 5:

                        try
                        {
                            Console.WriteLine("What System?");
                            var input = Console.ReadLine();
                            Console.WriteLine("What game?");
                            var input2 = Console.ReadLine();
                            TextWriter tw = new StreamWriter("wishlist.csv", true);
                            tw.WriteLine(input + "," + input2);
                            tw.Close();
                            Console.WriteLine("Info saved");
                            var lineCount = File.ReadLines(@"wishlist.csv").Count();
                            Console.WriteLine("There are " + lineCount + " in your wishlist");
                            Console.WriteLine("Hit enter to continue");

                        }

                        catch (Exception e)
                        {
                            Console.Write(e);
                        }

                        Console.Read();

                        break;

                    //This option current queries and external file and prints it to the console.
                    //This reads data from an external source one of the optional requirements.

                    case 6:
                        
                        {
                            DownloadString("https://pastebin.com/raw/Lzs7gJfc");
                        }
                         static void DownloadString(string address)
                        {
                            WebClient client = new WebClient();
                            string reply = client.DownloadString(address);
                            Console.WriteLine(reply);
                            Console.WriteLine("Pretty Cool huh?");
                            
                            //int newLineCount = reply.Count(c => c.Equals("\r\n"));
                            //Console.WriteLine("There are " + newLineCount + " games in your collection");

                            Console.WriteLine("Press enter to continue.");
                            Console.ReadLine();
                        }
                        break;

                    //This randomly selects a game from an said external source
                    //This retrieves a single value from a list that displays a random game from collection to play

                    case 7:
                        
                        try
                        {
                            WebClient client = new WebClient();
                            string reply = client.DownloadString("https://pastebin.com/raw/Lzs7gJfc");
                            String pwd = null;
                            string[] line = reply.Split("\r\n");
                            Random rn = new Random();
                            int rnum = rn.Next(line.Length-1);
                            pwd = line[rnum].ToString();
                            Console.WriteLine(pwd);
                            Console.WriteLine("Press Enter to contine");

                        }
                        catch (Exception e)
                        {
                            Console.Write(e);
                        }

                        Console.Read();
                        break;

                    default:

                        break;

                }
                action = chooseAction();
            }

        }

        //this interacts with Store.cs also uses Linq throughout the following 3 code blocks
        //User can add information and cost of a system and 'checkout' with final price - one of the optionl requirements.

        private static void printBackOrder(Store s)
        {
            string filePath = @"wishlist.csv";

            List<string> lines = File.ReadAllLines(filePath).ToList();

            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }

            lines.Add("");

            File.WriteAllLines(filePath, lines);

            Console.WriteLine("Above is your current video game wishlist. ");
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }

        private static void printShoppingCart(Store s)
        {
            Console.WriteLine("Games you have chosen to buy");
            for (int i = 0; i < s.ShoppingList.Count; i++)
            {
                Console.WriteLine("Game # " + i + " " + s.ShoppingList[i]);
            }
        }

        private static void printInventory(Store s)
        {
            for (int i = 0; i < s.GameList.Count; i++)
            {
                Console.WriteLine("Game # " + i + " " + s.GameList[i]);
            }
        }

        //this is the the interactive menu for the program. 
        static public int chooseAction()
        {
            int choice = 0;
            Console.WriteLine("Press (1) to add a System Manufactuer.");
            Console.WriteLine("Press (2) to add System item to your cart.");
            Console.WriteLine("Press (3) to checkout.");
            Console.WriteLine("Press (4) to view wishlist.");
            Console.WriteLine("Press (5) to add game to wishlist.");
            Console.WriteLine("Press (6) to access collection file");
            Console.WriteLine("Press (7) to randomly suggest a video game from your collection to play");
            Console.WriteLine("Press (9) to quit");
            choice = int.Parse(Console.ReadLine());
            return choice;
        }
    }
}

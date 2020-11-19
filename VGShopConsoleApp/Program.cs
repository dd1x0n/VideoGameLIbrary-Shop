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
            Console.WriteLine("Welcome to Darik's Video Game Library and Storefront! First input the video game Console you're selling. Fill out the correct system type and sale cost. Then checkout! Also add an item to your wishlist or acess your current collection from pastebin");

            int action = chooseAction();

            while (action != 9)
            {
                Console.WriteLine("You chose " + action);

                switch (action)

                {
                    //first option, allows you to add consoles, type and price. Unlimted amounts can be added! 
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

                        //this selection allows you add items to your cart. 

                    case 2:

                        Console.WriteLine("You chose to add game to your shopping cart");
                        printInventory(s);

                        Console.WriteLine("Which item would you like to buy? (amount )");
                        int gameChosen = int.Parse(Console.ReadLine());

                        s.ShoppingList.Add(s.GameList[gameChosen]);

                        printShoppingCart(s);

                        break;
                    //this selection allows you to get the final cost of your consoles/items for sale and checkout.
                    case 3:

                        printShoppingCart(s);
                        Console.WriteLine("The total cost of these systems is : " + s.Checkout());
                        break;

                    //This prints out
                    case 4:
                        printBackOrder(s);
                        break;

                    //This option allows you to add items to your wishlist. Saved in .bin file. 
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
                            Console.WriteLine("Hit enter to continue");

                        }

                        catch (Exception e)
                        {
                            Console.Write(e);
                        }

                        Console.Read();

                        break;
                    //This option current quiers the raw pasebin file I use for back currently owned Video Game List and prints it to the console. 
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
                            Console.WriteLine("Press enter to continue.");
                            Console.ReadLine();

                            
                        }
                        break;

                    //This randomly selects a game from an external source 
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

        //this interacts with Store.cs

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
        //this is the interactive comman menu for the program. 
        static public int chooseAction()
        {
            int choice = 0;
            Console.WriteLine("Enter (1) to add a System Manufactuer. Enter (2) to add System Type. Enter (3) to checkout. Enter (4) to view wishlist. Enter (5) to add game to file. Enter (6) to access outside collection file. Enter (9) to quit ");

         

            choice = int.Parse(Console.ReadLine());
            return choice;
        }
    }
}

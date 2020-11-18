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
         
            Store s = new Store();
            Console.WriteLine("Welcome to Darik's Video Game Library and (pseudo) Storefront! First input the video game Console you're selling. Fill out the correct system type and sale cost. Then checkout!");

            int action = chooseAction();

            while (action != 9)
            {
                Console.WriteLine("You chose " + action);

                switch (action)

                {
                    //first option, allows you to add consoles, type and price. Unlimted amounts can be added! 
                    case 1:

                        Console.WriteLine("You chose or add a new game");

                        String gameMake = "";
                        String gameModel = "";
                        Decimal gamePrice = 0;

                        Console.WriteLine("What is the game make?");
                        gameMake = Console.ReadLine();

                        Console.WriteLine("What is the game model?");
                        gameModel = Console.ReadLine();

                        Console.WriteLine("What is the cost?");
                        gamePrice = int.Parse(Console.ReadLine());

                        Cart newGame = new Cart(gameMake, gameModel, gamePrice);
                        s.GameList.Add(newGame);

                        printInventory(s);
                        break;


                    case 2:

                        Console.WriteLine("You chose to add game to your shopping cart");
                        printInventory(s);

                        Console.WriteLine("Which item would you like to buy? (amount )");
                        int gameChosen = int.Parse(Console.ReadLine());

                        s.ShoppingList.Add(s.GameList[gameChosen]);

                        printShoppingCart(s);

                        break;

                    case 3:

                        printShoppingCart(s);
                        Console.WriteLine("The total cost of these systems is : " + s.Checkout());
                        break;

                    case 4:
                        printBackOrder(s);
                        break;

                    case 5:

                        try
                        {
                            Console.WriteLine("What System?");
                            var input = Console.ReadLine();
                            Console.WriteLine("What game?");
                            var input2 = Console.ReadLine();
                            TextWriter tw = new StreamWriter("supernes.csv", true);
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

                    case 6:
                        
                        {
                            DownloadString("https://pastebin.com/raw/Lzs7gJfc");
                        }
                         static void DownloadString(string address)
                        {
                            WebClient client = new WebClient();
                            string reply = client.DownloadString(address);
                            
                          
                      


                            Console.WriteLine(reply);

                            
                           
                            Console.WriteLine("Pretty Coool huh? Press enter to continue.");
                            Console.ReadLine();

                            
                        }
                        break;


                        // case 7:
                        //    //location of an error when trying to putput a radom line from a file. 
                        //    try
                        //    {
                        //        StreamReader sr = new StreamReader("supernes.csv");

                        //        String pwd = null;

                        //        string[] line = new string[10];

                        //        for (int i = 0; i < 10; i++)

                        //        {

                        //            line[i] = sr.ReadLine();

                        //        }

                        //        Random rn = new Random();

                        //        int rnum = rn.Next(10);

                        //        pwd = line[rnum].ToString();

                        //        sr.Close();
                        //    }
                        //    catch (Exception e)
                        //    {
                        //        Console.Write(e);
                        //    }

                        //    Console.Read();
                        //break;

                       

                        //public string[] lines = File.ReadAllLines(...); //i hope that the file is not too big
                        //Random rand = new Random();
                        //return lines[rand.Next(lines.Length)];




                    default:

                        break;

                }
                action = chooseAction();
            }

        }

        

        private static void printBackOrder(Store s)
        {
            string filePath = @"supernes.csv";

            List<string> lines = File.ReadAllLines(filePath).ToList();

            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }

            lines.Add("");

            File.WriteAllLines(filePath, lines);

            Console.WriteLine("Would you like to add a videogame to the master list? ");
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

        static public int chooseAction()
        {
            int choice = 0;
            Console.WriteLine("Enter (1) to add a System Brand. Enter (2) to add System Type. Enter (3) to checkout. Enter (4) to current game collection. Enter (5) to add game to file. Enter (6) to acess outside collection file. Enter (9) to quit ");

            //fix crash with a try/catch
            choice = int.Parse(Console.ReadLine());
            return choice;
        }
    }
}

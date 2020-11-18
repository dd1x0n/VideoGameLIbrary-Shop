using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Cart
    {
        public string Maker { get; set; }
        public string GameSystem { get; set; }
        public decimal Price { get; set; }

        public Cart()
        {
            Maker = "nothing yet";
            GameSystem = "nothing yet";
            Price = 0.00M;
        }

        public Cart(string a, string b, decimal c)
        {
            Maker = a;
            GameSystem = b;
            Price = c;
        }

        override public string ToString()
        {
            return "Maker: " + Maker + " GameSystem " + GameSystem + " Price: $" + Price;
        }
    }
}

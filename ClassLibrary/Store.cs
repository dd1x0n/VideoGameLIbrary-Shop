using System;
using System.Text;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class Store
    {
        public List<Cart> GameList { get; set; }
        public List<Cart> ShoppingList { get; set; }

        public Store()
        {
            GameList = new List<Cart>();
            ShoppingList = new List<Cart>();
        }

        public decimal Checkout()
        {
            decimal totalCost = 0;

            foreach (var c in ShoppingList)
            {
                totalCost += c.Price;
            }

            ShoppingList.Clear();
            return totalCost;
        }
    }
}

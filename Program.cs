using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var costs = new List<double>();
            costs.Add(CheckOut(new string[] { })); //empty test
            costs.Add(CheckOut(new[] { "Apple", "Orange" })); //basic test
            costs.Add(CheckOut(new[] { "Apple", "Orange", "Apple", "Apple" })); //example given by prompt
            costs.Add(CheckOut(new[] { "Apple", "Orange", "Apple", "Orange", "Apple", "Apple", "Orange", "Apple", "Apple", "Orange", "Orange", "Apple", })); //larger scale test

            foreach (var example in costs)
                Console.WriteLine(example);
        }

        //Initial Checkout Method
        //Apple: 45c, Orange: 65c
        //At this point, my store ONLY sells apples and oranges, so every item Will be either an apple or orange
        public static double CheckOut(string[] pCart)
        {
            if(!(pCart.Length >= 1))
                return 0;
            
            int apples = 0;
            int oranges = 0;
            foreach (var fruit in pCart)
            {
                if (fruit == "Apple")
                    apples++;
                else
                    oranges++;
            }

            return (apples * .45) + (oranges * .65);
        }
    }
}

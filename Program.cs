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

        //Step 1
        //Initial Checkout Method
        //Apple: 45c, Orange: 65c
        //At this point, my store ONLY sells apples and oranges, so every item Will be either an apple or orange
        //
        //Step 2
        //Simple offers
        //Adding buy 1 get 1 apples
        //3 for price of 2 oranges
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

            return (ApplesCost(apples)) + (OrangesCost(oranges));
        }

        //Current deal for apples is buy one get one
        public static double ApplesCost(int pApples)
        {
            return pApples % 2 == 0 ?          //Chcek if odd or even
                    (pApples / 2) * .45 :      //Even number cost 
                    (pApples / 2) * .45 + .45; //Odd number cost
        }

        //Current deal for oranges is buy 3 for 2
        public static double OrangesCost(int pOranges)
        {
            return (pOranges / 3) * 1.30 +
                ((pOranges % 3) * .65);
                
        }
    }
}

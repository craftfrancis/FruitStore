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
            costs.Add(CheckOut(new[] { "Apple", "Orange", "Apple", "Orange", "Apple", "Apple", "Orange", "Apple", "Apple", "Orange", "Orange", "Apple", "Banana", "Banana", "Banana", "Melon", "Apple", "Orange", "Apple", "Orange", "Apple", "Apple", "Orange", "Apple", "Apple", "Orange", "Orange", "Apple", "Banana", "Banana", "Banana", "Melon", "Apple", "Orange", "Apple", "Orange", "Apple", "Apple", "Orange", "Apple", "Apple", "Orange", "Orange", "Apple", "Banana", "Banana", "Banana", "Melon", "Apple", "Orange", "Apple", "Orange", "Apple", "Apple", "Orange", "Apple", "Apple", "Orange", "Orange", "Apple", "Banana", "Banana", "Banana", "Melon" }));

            foreach (var example in costs)
                Console.WriteLine("Your total comes to " + example);
        }

        /*Step 1
        Initial Checkout Method
        Apple: 45c, Orange: 65c
        
        Step 2
        Simple offers
        Adding buy 1 get 1 apples
        3 for price of 2 oranges
        
        Step 3
        More Complicated Offers
        Bananas: 60c
        Also buy one get one like apples
        Cheapest item should be free
        When comparing the value of multiple items the lowest is removed. 
        The example given compares multiple bananas to multiple apples. The lower of those two is removed even with no oranges.
        So lowest Non zero option is removed as long as its not Only option


        Step 4:
        Even more complicated orders
        Melons: $1
        Available with a 3 for 2 deal

        Step 5:
        Real Time Checkout
        */
        public static double CheckOut(string[] pCart)
        {
            if (!(pCart.Length >= 1))
                return 0;

            #region Two Fruit Method
            /*
            //int apples = 0;
            //int oranges = 0;
            //foreach (var fruit in pCart)
            //{
            //    if (fruit == "Apple")
            //        apples++;
            //    else
            //        oranges++;
            //}

            //return (ApplesCost(apples)) + (OrangesCost(oranges));
            */
            #endregion

            #region >2 Fruit Method

            //Determine the cost of each item type
            var itemizedCosts = new List<double>();
            itemizedCosts.Add(ApplesCost(pCart.Where(x => x == "Apple").Count()));
            if(itemizedCosts.Last() != 0)
                Console.WriteLine("Cost of Apples: " + itemizedCosts.Last());

            itemizedCosts.Add(OrangesCost(pCart.Where(x => x == "Orange").Count()));
            if (itemizedCosts.Last() != 0)
                Console.WriteLine("Cost of Oranges: " + itemizedCosts.Last());

            itemizedCosts.Add(BananasCost(pCart.Where(x => x == "Banana").Count()));
            if (itemizedCosts.Last() != 0)
                Console.WriteLine("Cost of Bananas: " + itemizedCosts.Last());

            itemizedCosts.Add(MelonsCost(pCart.Where(x => x == "Melon").Count()));
            if (itemizedCosts.Last() != 0)
                Console.WriteLine("Cost of Melons: " + itemizedCosts.Last());


            itemizedCosts.RemoveAll(x => x == 0); //Remove zeros for comparison purposes

            if (itemizedCosts.Count > 1)
            {
                itemizedCosts.Sort();
                Console.WriteLine("You're saving " + itemizedCosts.First());
                itemizedCosts.RemoveAt(0);
            }

            double rVal = 0;
            foreach (var cost in itemizedCosts)
            {
                rVal += cost;
            }
            return rVal;
            #endregion
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

        //Current deal for Bananas is buy one get one
        public static double BananasCost(int pBananas)
        {
            return pBananas % 2 == 0 ?          //Chcek if odd or even
                    (pBananas / 2) * .6 :       //Even number cost 
                    (pBananas / 2) * .6 + .6;   //Odd number cost
        }
        //Current deal for oranges is buy 3 for 2
        public static double MelonsCost(int pMelons)
        {
            return (pMelons / 3) * 2 +
                ((pMelons % 3) * 1);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FruitStore;
using System.Collections.Generic;
using System.Linq;

namespace FruitStore.Tests
{
    [TestClass()]
    public class FruitStoreTests
    {

        //There is a full gamut of MelonsCost testing
        #region MelonsCost Tests

        [TestMethod()]
        [Timeout(2000)]
        public void MelonsCostTest_DivisibleBy3_Pass()
        {
            //arrange
            int numberOfMelons = 3;
            double expectedPrice = 2;

            //act
            double actualPrice = Program.MelonsCost(numberOfMelons);

            //assert
            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [TestMethod]
        [Timeout(2000)]
        public void MelonsCostTest_DivisibleBy3_Fail()
        {
            //arrange
            int numberOfMelons = 3;
            double expectedAndIncorrectPrice = 3;

            //act
            double actualPrice = Program.MelonsCost(numberOfMelons);

            //assert
            Assert.AreNotEqual(expectedAndIncorrectPrice, actualPrice);
        }

        [TestMethod]
        [Timeout(2000)]
        public void MelonsCostTest_DivisibleBy3Plus1_Pass()
        {
            //arange
            int numberOfMelons = 7;
            double expectedPrice = 5;

            //act
            double actualPrice = Program.MelonsCost(numberOfMelons);

            //assert
            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [TestMethod]
        [Timeout(2000)]
        public void MelonsCostTest_DivisibleBy3Plus2_Pass()
        {
            //arrange
            int numberOfMelons = 11;
            double expectedPrice = 8;

            //act
            double actualPrice = Program.MelonsCost(numberOfMelons);

            //assert
            Assert.AreEqual(expectedPrice, actualPrice);
        }

        #endregion

        //At least one test for each other pricing method
        #region other fruit costs tests
        [TestMethod]
        [Timeout(2000)]
        public void ApplesCost_DivisibleBy2_Pass()
        {
            //Arrange
            int numberOfApples = 20;
            double expectedPrice = 4.5;

            //act
            double actualPrice = Program.ApplesCost(numberOfApples);

            //Assert
            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [TestMethod]
        [Timeout(2000)]
        public void BananasCost_NotDivisibleBy2_Pass()
        {
            //arrange
            int numberOfBananans = 21;
            double expectedPrice = 6.6;

            //act
            double actualPrice = Program.BananasCost(numberOfBananans);

            //assert
            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [TestMethod]
        [Timeout(2000)]
        public void OrangesCost_DivisibleBy3_Pass()
        {
            //arange
            int numberOfOranges = 30;
            double expectedPrice = 13;

            //act
            double actualPrice = Program.OrangesCost(numberOfOranges);

            //assert
            Assert.AreEqual(expectedPrice, actualPrice);
        }
        #endregion

        #region FindCheapestCart Tests

        //Empty Cart
        [TestMethod]
        [Timeout(2000)]
        public void FindCheapestCart_EmptyCart_Pass()
        {
            //arrange
            var testCart = new List<double>();
            var expectedCart = new List<double>();

            //act
            var actualCart = Program.FindCheapestCart(testCart);

            //Assert
            CollectionAssert.AreEqual(expectedCart, actualCart);
        }

        //Cart of 1 item
        [TestMethod]
        public void FindCheapestCart_OneItem_Pass()
        {
            //arrange
            var testCart = new List<double> { 1 };
            var expectedCart = new List<double> { 1 };

            //act
            var actualCart = Program.FindCheapestCart(testCart);

            //assert
            CollectionAssert.AreEqual(expectedCart, actualCart);
        }

        //Cart of 2 items
        [TestMethod]
        [Timeout(2000)]
        public void FindCheapestCart_TwoItems_Pass()
        {
            //arrange
            var testCart = new List<double> { 13, 14 };
            var expectedCart = new List<double> { 14 };

            //act
            var actualCart = Program.FindCheapestCart(testCart);

            //assert
            CollectionAssert.AreEqual(expectedCart, actualCart);
        }

        //Cart of >2 items
        [TestMethod]
        [Timeout(5000)]
        public void FindCheapestCart_MoreThanTwoItems_Pass()
        {
            //arrange
            var testCart = new List<double> { 20, 21, 23, 25, 26, 28, 39, 30 };
            var expectedCart = new List<double> { 21, 25, 28, 39 };

            //act
            var actualCart = Program.FindCheapestCart(testCart);

            //assert
            CollectionAssert.AreEqual(expectedCart, actualCart);
        }
        #endregion
    }
}
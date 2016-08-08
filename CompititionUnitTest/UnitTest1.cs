using System;
using LittleShinoAndTheTournament;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShinuAndFib;

namespace CompititionUnitTest
{
    [TestClass]
    public class TestClass
    {
        [TestMethod]
        public void TestMethod()
        {
           var result =  Program.SolveFight(new [] {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,-1 }, 
                               new [] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }, 25);

            var actualOutput = new[] { 1, 2, 1, 3, 1, 2, 1, 4, 1, 2, 1, 3, 1, 2, 1, 5, 1, 2, 1, 3, 1, 2, 1, 4, 2 };

            int i = 0;
            foreach (var actual in actualOutput)
            {
                Assert.AreEqual(actual,result[i++]);
            }
        }

      

        [TestMethod]
        public void RunSpaceShip()
        {
            var queries = new int[] { 5, 10, 8 };
            var noOfSpaceShips = 3;
            var spaceShips = "5  6   7";
           

            //BennyAndTheUniverse.Program.Run(noOfSpaceShips, queries, spaceShips );

            queries = new int[] { 16 };
            spaceShips = "7  3   11";
            noOfSpaceShips = 3;

            //BennyAndTheUniverse.Program.Run(noOfSpaceShips, queries, spaceShips);

            //queries = new int[] { 16, 21, 2 };
            //spaceShips = "7  3   11";
            //noOfSpaceShips = 3;

            //BennyAndTheUniverse.Program.Run(noOfSpaceShips, queries, spaceShips);

            //queries = new int[] { 60 };
            //spaceShips = "7";
            //noOfSpaceShips = 1;

            //BennyAndTheUniverse.Program.Run(noOfSpaceShips, queries, spaceShips);

            queries = new int[] { 128, 7, 6, 28, 39, 11, 12, 16, 20, 91 };
            spaceShips = "  7  1 3   4   6  8  9             22   56  76   33 44  55  67 26  5";
            noOfSpaceShips = 16;

            BennyAndTheUniverse.Program.Run(noOfSpaceShips, queries, spaceShips);
        }
    }
    
    [TestClass]
    public class DivBy7UnitTest
    {
        [TestMethod]
        public void DivBy7Test()
        {
           var output =  RhezoAndDivisibilityBy7.Program.DivisibleBy7(1, 2, 357753);
           Assert.AreEqual(output, "YES");

            output = RhezoAndDivisibilityBy7.Program.DivisibleBy7(2, 3, 357753);
            Assert.AreEqual(output, "NO");

            output = RhezoAndDivisibilityBy7.Program.DivisibleBy7(4, 4, 357753);
            Assert.AreEqual(output, "YES");

            output = RhezoAndDivisibilityBy7.Program.DivisibleBy7(1, 1, 719474488);
            Assert.AreEqual(output, "YES");

            output = RhezoAndDivisibilityBy7.Program.DivisibleBy7(10, 10, 0819474487);
            Assert.AreEqual(output, "YES");

            output = RhezoAndDivisibilityBy7.Program.DivisibleBy7(5, 11,0819721284987);
            Assert.AreEqual(output, "YES");

            output = RhezoAndDivisibilityBy7.Program.DivisibleBy7(5, 11, 83853988942798);
            Assert.AreEqual(output, "NO");

        }
    }
}

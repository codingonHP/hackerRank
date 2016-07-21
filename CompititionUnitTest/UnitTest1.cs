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
    }
  
}

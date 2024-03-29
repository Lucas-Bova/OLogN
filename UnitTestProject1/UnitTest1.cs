using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLarge()
        {
            System.Console.WriteLine("Starting test");
            int[] arr = new int[1000000];
            for (var i = 0; i <= 999870; ++i)
            {
                arr[i] = i;
            }
            var LN = new newOLog.OLogN<int>(arr, 957);
            Stopwatch stopwatch = Stopwatch.StartNew(); 
            var result = LN.SearchArray();
            stopwatch.Stop();
            System.IO.File.AppendAllText(@"..\..\..\..\speed.txt", "\nRun - " + DateTime.Now.ToString() + ": " + stopwatch.ElapsedMilliseconds.ToString());
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void AlphabetTest()
        {
            string[] arr = new string[10];
            Random rchar = new Random();
            for (var i = 0; i < 10; ++i)
            {
                arr[i] = ((char)(rchar.Next(65, 91))).ToString();
            }
            arr[6] = "y";
            var LN = new newOLog.OLogN<string>(arr, "y");
            var result = LN.SearchArray();
            Assert.AreEqual(true, result);

        }

        [TestMethod]
        public void StringTest()
        {
            string[] arr = {"Car", "Cab", "Back", "Right", "Apple", "Zoo", "Truck", "Might", "Produce" };
            var LN = new newOLog.OLogN<string>(arr, "Truck");
            var result = LN.SearchArray();
            Assert.AreEqual(true, result);

        }

        [TestMethod]
        public void FloorTest()
        {
            int[] arr = new int[10];
            for (var i = 0; i <= 9; ++i)
            {
                arr[i] = i;
            }
            var LN = new newOLog.OLogN<int>(arr, 0);
            var result = LN.SearchArray();
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void RoofTest()
        {
            int[] arr = new int[1000];
            for (var i = 0; i <= 999; ++i)
            {
                arr[i] = i;
            }
            var LN = new newOLog.OLogN<int>(arr, arr[arr.Length - 1]);
            var result = LN.SearchArray();
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void NotEqual()
        {
            int[] arr = new int[1000];
            for (var i = 0; i <= 999; ++i)
            {
                arr[i] = i;
            }
            var LN = new newOLog.OLogN<int>(arr, 1001);
            var result = LN.SearchArray();
            Assert.AreEqual(false, result);
        }
    }
}

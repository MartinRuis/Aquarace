using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AquaraceV2.Tests
{
    [TestClass]
    public class GuessTests
    {
        [TestMethod]
        public void test_guess_check()
        {
            //Arange
            bool expected = true;
            List<int> memberIds = new List<int>();
            memberIds.Add(1);
            memberIds.Add(2);
            memberIds.Add(3);
            memberIds.Add(4);
            int self_id = 1;
            int[] driverIds = { 2,5,4,9,15};

            //Act

            //Assert
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringAlgorithms;


namespace StringAlgorithmsTests
{
    [TestClass]
    public class ImplementationTests
    {
        StringAlgorithms.Implementation stringAlg = null;

        [TestInitialize]
        public void SetUp() {
            stringAlg = new Implementation();
        }

        [TestMethod]
        public void Rotate()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7 };
            var result = stringAlg.Rotate(nums, 3);
            Assert.IsTrue(result[0] == 5);
        }
    }
}

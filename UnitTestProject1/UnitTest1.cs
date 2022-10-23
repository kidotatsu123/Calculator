using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalcultorTester
{
    [TestClass]
    public class UnitTest1
    {
        private Calculation cal;
        [TestInitialize]
        public void SetUp()
        {
            this.cal = new Calculation(10, 5);
        }
        [TestMethod]
        public void TestAddOperator()
        {
            Assert.AreEqual(15, cal.Execute("+"));
        }
        [TestMethod]
        public void TestSubOperator()
        {
            Assert.AreEqual(5, cal.Execute("-"));
        }
        [TestMethod]
        public void TestMulOperator()
        {
            Assert.AreEqual(50, cal.Execute("*"));
        }
        [TestMethod]
        public void TestDivOperator()
        {
            Assert.AreEqual(2, cal.Execute("/"));
        }
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestDivByZero()
        {
            Calculation c = new Calculation(10, 0);
            c.Execute("/");
        }
    }
}

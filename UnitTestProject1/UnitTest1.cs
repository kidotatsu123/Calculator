using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalcultorTester
{
    [TestClass]
    public class UnitTest1
    {
        private Calculation cal;
        public TestContext TestContext { get; set; }
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
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
@".\Data\TestData.csv", "TestData#csv", DataAccessMethod.Sequential)]
        
        public void TestWithDataSource()
        {
            Calculation c;
            int a, b, expected;
            string operation;
            a = int.Parse(TestContext.DataRow[0].ToString());
            b = int.Parse(TestContext.DataRow[1].ToString());
            operation = TestContext.DataRow[2].ToString();
            operation = operation.Remove(0, 1);
            expected = int.Parse(TestContext.DataRow[3].ToString());
            
            c = new Calculation(a, b);
            Assert.AreEqual(expected, c.Execute(operation));
        }
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
@".\Data\TestSoSanh.csv", "TestSoSanh#csv", DataAccessMethod.Sequential)]
        public void TestSoSanh()
        {
            Calculation c;
            int a, b, expected;
            int actual;
            a = int.Parse(TestContext.DataRow[0].ToString());
            b = int.Parse(TestContext.DataRow[1].ToString());
            expected = int.Parse(TestContext.DataRow[2].ToString());
            c = new Calculation(a, b);
            actual =c.SoSanh(a, b);
            Assert.AreEqual(expected,actual);
        }
    }
}

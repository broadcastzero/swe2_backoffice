using EPUBackoffice.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Rulemanager;

namespace BackofficeTests
{   
    /// <summary>
    ///This is a test class for RuleManagerTest and is intended
    ///to contain all RuleManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RuleManagerTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        ///A test for ValidatePerCent
        ///</summary>
        [TestMethod()]
        public void ValidatePerCentTest()
        {
            string input = "100";
            int expected = 100;
            int actual;
            actual = RuleManager.ValidatePerCent(input);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A second test for ValidatePerCent
        ///</summary>
        [TestMethod()]
        public void ValidatePerCentTest1()
        {
            string input = "100x";
            int expected = -1;
            int actual;
            actual = RuleManager.ValidatePerCent(input);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A third test for ValidatePerCent
        ///</summary>
        [TestMethod()]
        public void ValidatePerCentTest2()
        {
            string input = "101";
            int expected = -1;
            int actual;
            actual = RuleManager.ValidatePerCent(input);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A forth test for ValidatePerCent
        ///</summary>
        [TestMethod()]
        public void ValidatePerCentTest3()
        {
            string input = "-1";
            int expected = -1;
            int actual;
            actual = RuleManager.ValidatePerCent(input);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ValidateLettersHyphen
        ///</summary>
        [TestMethod()]
        public void ValidateLettersHyphenTest()
        {
            string input = "Franz-Karl-Stephan";
            bool expected = true;
            bool actual;
            actual = RuleManager.ValidateLettersHyphen(input);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A second test for ValidateLettersHyphen
        ///</summary>
        [TestMethod()]
        public void ValidateLettersHyphenTest1()
        {
            string input = "Franz Karl Stephan";
            bool expected = false;
            bool actual;
            actual = RuleManager.ValidateLettersHyphen(input);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A third test for ValidateLettersHyphen
        ///</summary>
        [TestMethod()]
        public void ValidateLettersHyphenTest2()
        {
            string input = "Franz";
            bool expected = true;
            bool actual;
            actual = RuleManager.ValidateLettersHyphen(input);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ValidateLettersNumbersHyphenSpace
        ///</summary>
        [TestMethod()]
        public void ValidateLettersNumbersHyphenSpaceTest()
        {
            string input = "No-Responsibility Company 05";
            bool expected = true;
            bool actual;
            actual = RuleManager.ValidateLettersNumbersHyphenSpace(input);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ValidatePositiveInt
        ///</summary>
        [TestMethod()]
        public void ValidatePositiveIntTest()
        {
            string input = "32x";
            int expected = -1;
            int actual;
            actual = RuleManager.ValidatePositiveInt(input);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A second test for ValidatePositiveInt
        ///</summary>
        [TestMethod()]
        public void ValidatePositiveIntTest1()
        {
            string input = "32";
            int expected = 32;
            int actual;
            actual = RuleManager.ValidatePositiveInt(input);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ValidateStringLength150
        ///</summary>
        [TestMethod()]
        public void ValidateStringLength150Test()
        {
            string input = "Franz";
            bool expected = true;
            bool actual;
            actual = RuleManager.ValidateStringLength150(input);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ValidateStringLength150
        ///</summary>
        [TestMethod()]
        public void ValidateStringLength150Test1()
        {
            string input = "ddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd"; //151
            bool expected = false;
            bool actual;
            actual = RuleManager.ValidateStringLength150(input);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A second test for ValidateStringLength150
        ///</summary>
        [TestMethod()]
        public void ValidateStringLength150Test2()
        {
            string input = "dddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd"; //150
            bool expected = true;
            bool actual;
            actual = RuleManager.ValidateStringLength150(input);
            Assert.AreEqual(expected, actual);
        }
    }
}

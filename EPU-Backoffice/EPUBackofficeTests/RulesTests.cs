using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EPU_Backoffice_Panels.BL;
using EPU_Backoffice_Panels.Rules;

namespace BackofficeTests
{
    /// <summary>
    ///This is a test class for RuleManagerTest and is intended
    ///to contain all RuleManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RulesTests
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
            PercentValidator val = new PercentValidator();
            string input = "100";
            val.Eval(input);
            Assert.AreEqual(false, val.HasErrors);
        }

        /// <summary>
        ///A second test for ValidatePerCent
        ///</summary>
        [TestMethod()]
        public void ValidatePerCentTest1()
        {
            PercentValidator val = new PercentValidator();
            string input = "100x";

            val.Eval(input);
            Assert.AreEqual(true, val.HasErrors);
        }

        /// <summary>
        ///A third test for ValidatePerCent
        ///</summary>
        [TestMethod()]
        public void ValidatePerCentTest2()
        {
            PercentValidator val = new PercentValidator();
            string input = "101";
            val.Eval(input);
            Assert.AreEqual(true, val.HasErrors);
        }

        /// <summary>
        ///A forth test for ValidatePerCent
        ///</summary>
        [TestMethod()]
        public void ValidatePerCentTest3()
        {
            PercentValidator val = new PercentValidator();
            string input = "-1";
            val.Eval(input);
            Assert.AreEqual(true, val.HasErrors);
        }

        /// <summary>
        ///A test for ValidateLettersHyphen
        ///</summary>
        [TestMethod()]
        public void ValidateLettersHyphenTest()
        {
            LettersHyphenValidator val = new LettersHyphenValidator();
            string input = "Franz-Karl-Stephan";
            val.Eval(input);
            Assert.AreEqual(false, val.HasErrors);
        }

        /// <summary>
        ///A second test for ValidateLettersHyphen
        ///</summary>
        [TestMethod()]
        public void ValidateLettersHyphenTest1()
        {
            LettersHyphenValidator val = new LettersHyphenValidator();
            string input = "Franz Karl Stephan";
            val.Eval(input);
            Assert.AreEqual(true, val.HasErrors);
        }

        /// <summary>
        ///A third test for ValidateLettersHyphen
        ///</summary>
        [TestMethod()]
        public void ValidateLettersHyphenTest2()
        {
            LettersHyphenValidator val = new LettersHyphenValidator();
            string input = "Franz";
            val.Eval(input);
            Assert.AreEqual(false, val.HasErrors);
        }

        /// <summary>
        ///A test for ValidateLettersNumbersHyphenSpace
        ///</summary>
        [TestMethod()]
        public void ValidateLettersNumbersHyphenSpaceTest()
        {
            LettersNumbersHyphenSpaceValidator val = new LettersNumbersHyphenSpaceValidator();
            string input = "No-Responsibility Company 05";
            val.Eval(input);
            Assert.AreEqual(false, val.HasErrors);
        }

        /// <summary>
        ///A test for ValidatePositiveInt
        ///</summary>
        [TestMethod()]
        public void ValidatePositiveIntTest()
        {
            PositiveIntValidator val = new PositiveIntValidator();
            string input = "32x";
            val.Eval(input);
            Assert.AreEqual(true, val.HasErrors);
        }

        /// <summary>
        ///A second test for ValidatePositiveInt
        ///</summary>
        [TestMethod()]
        public void ValidatePositiveIntTest1()
        {
            PositiveIntValidator val = new PositiveIntValidator();
            string input = "32";
            val.Eval(input);
            Assert.AreEqual(false, val.HasErrors);
        }

        /// <summary>
        ///A test for ValidateStringLength150
        ///</summary>
        [TestMethod()]
        public void ValidateStringLength150Test()
        {
            StringLength150Validator val = new StringLength150Validator();
            string input = "Franz";
            val.Eval(input);
            Assert.AreEqual(false, val.HasErrors);
        }

        /// <summary>
        ///A test for ValidateStringLength150
        ///</summary>
        [TestMethod()]
        public void ValidateStringLength150Test1()
        {
            StringLength150Validator val = new StringLength150Validator();
            string input = "ddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd"; //151
            val.Eval(input);
            Assert.AreEqual(true, val.HasErrors);
        }

        /// <summary>
        ///A second test for ValidateStringLength150
        ///</summary>
        [TestMethod()]
        public void ValidateStringLength150Test2()
        {
            StringLength150Validator val = new StringLength150Validator();
            string input = "dddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd"; //150
            val.Eval(input);
            Assert.AreEqual(false, val.HasErrors);
        }
    }
}

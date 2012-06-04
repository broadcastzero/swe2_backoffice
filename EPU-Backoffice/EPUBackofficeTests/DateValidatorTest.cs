namespace EPUBackofficeTests
{
    using EPU_Backoffice_Panels.Rules;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    
    /// <summary>
    ///This is a test class for DateValidatorTest and is intended
    ///to contain all DateValidatorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DateValidatorTest
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
        ///A test for Eval
        ///</summary>
        [TestMethod()]
        public void EvalTest()
        {
            DateValidator target = new DateValidator();
            string input = DateTime.Today.ToShortDateString();
            target.Eval(input);
            Assert.AreEqual(target.HasErrors, false);
        }

        /// <summary>
        ///A test for Eval
        ///</summary>
        [TestMethod()]
        public void EvalTest1()
        {
            DateValidator target = new DateValidator();
            DateTime input = DateTime.Today;
            target.Eval(input);
            Assert.AreEqual(target.HasErrors, false);
        }

        /// <summary>
        ///A test for Eval
        ///</summary>
        [TestMethod()]
        public void EvalTest2()
        {
            DateValidator target = new DateValidator();
            int input = DateTime.Today.Year;
            target.Eval(input);
            Assert.AreEqual(target.HasErrors, true);
        }

        /// <summary>
        ///A test for Eval
        ///</summary>
        [TestMethod()]
        public void EvalTest3()
        {
            DateValidator target = new DateValidator();
            DateTime date = new DateTime(2012, 2, 3);
            target.Eval(date);
            Assert.AreEqual(target.HasErrors, false);
        }

        /// <summary>
        ///A test for Eval
        ///</summary>
        [TestMethod()]
        public void EvalTest4()
        {
            DateValidator target = new DateValidator();
            string date = "30.12.2011";
            target.Eval(date);
            Assert.AreEqual(target.HasErrors, false);
        }

        /// <summary>
        ///A test for Eval
        ///</summary>
        [TestMethod()]
        public void EvalTest5()
        {
            DateValidator target = new DateValidator();
            string date = "30.13.2011";
            target.Eval(date);
            Assert.AreEqual(target.HasErrors, true);
        }
    }
}

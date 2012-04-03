// -----------------------------------------------------------------------
// <copyright file="MockDataBaseManagerTest.cs" company="Marvin&Felix">
// TODO: You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace BackofficeTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using EPUBackoffice.BL;
    using EPUBackoffice.Dal;    

    /// <summary>
    ///This is a test class for MockDataBaseManagerTest and is intended
    ///to contain all MockDataBaseManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MockDataBaseManagerTest
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
        ///A test for MockDataBaseManager Constructor
        ///</summary>
        [TestMethod()]
        public void MockDataBaseManagerConstructorTest()
        {
            MockDataBaseManager target = new MockDataBaseManager();
            //Assert.AreEqual(
        }

        /// <summary>
        ///A test for CreateDataBase
        ///</summary>
        [TestMethod()]
        public void CreateDataBaseTest()
        {
            MockDataBaseManager target = new MockDataBaseManager(); // TODO: Initialize to an appropriate value
            target.CreateDataBase();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SaveNewKunde
        ///</summary>
        [TestMethod()]
        public void SaveNewKundeTest()
        {
            MockDataBaseManager target = new MockDataBaseManager(); // TODO: Initialize to an appropriate value
            string lastname = string.Empty; // TODO: Initialize to an appropriate value
            bool type = false; // TODO: Initialize to an appropriate value
            string firstname = string.Empty; // TODO: Initialize to an appropriate value
            target.SaveNewKunde(lastname, type, firstname);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}

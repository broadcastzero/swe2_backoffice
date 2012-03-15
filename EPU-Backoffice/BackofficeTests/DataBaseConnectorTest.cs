using EPUBackoffice.Dal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.Diagnostics;

namespace BackofficeTests
{    
    /// <summary>
    ///This is a test class for DataBaseConnectorTest and is intended
    ///to contain all DataBaseConnectorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DataBaseConnectorTest
    {
        private TestContext testContextInstance;
        private DataBaseConnector target;

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
        //    
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            target = new DataBaseConnector();
        }
        //
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            target = null;
        }
        //
        #endregion

        /// <summary>
        ///A test for checkDataBaseExistance with a string as parameter
        ///</summary>
        [TestMethod()]
        public void checkDataBaseExistanceTest1()
        {
            string path = "../../../EPU-Backoffice/bin/Debug/testdb.db"; // create this file in test folder!
            bool expected = true;
            bool actual;
            actual = target.checkDataBaseExistance(path);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for checkDataBaseExistance with a string as parameter - file does not end with .db
        /// Should return false, because "Logfile.txt" does exist, but does not end with ".db".
        /// </summary>
        [TestMethod()]
        public void checkDataBaseExistanceTest2()
        {
            string path = "../../../EPU-Backoffice/bin/Debug/Logfile.txt";
            bool expected = false;
            bool actual;
            actual = target.checkDataBaseExistance(path);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for checkDataBaseExistance without params - path is read out of Logfile.
        ///Actual should be false, when no Logfile is found (which is the case within the path in which tests are run).
        ///</summary>
        [TestMethod()]
        public void checkLogfileExistanceTest()
        {
            bool expected = false;
            bool actual;
            actual = target.checkDataBaseExistance();
            Assert.AreEqual(expected, actual);
        }
    }
}

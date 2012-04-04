namespace BackofficeTests
{
    using EPUBackoffice.Dal;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    /// <summary>
    ///This is a test class for DataBaseManagerTest and is intended
    ///to contain all DataBaseManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DataBaseManagerTest
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
        ///A test for GetKundenKontakteSQL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("EPU-Backoffice.exe")]
        public void GetKundenKontakteSQLTest()
        {
            DataBaseManager target = new DataBaseManager();
            string type = "Kunde";
            string firstname = null;
            string lastname = "Huber";
            string expected = "SELECT * FROM " + type + " WHERE Nachname_Firmenname = ?";
            string actual;
            actual = target.GetKundenKontakteSQL(type, firstname, lastname);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A second test for GetKundenKontakteSQL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("EPU-Backoffice.exe")]
        public void GetKundenKontakteSQLTest1()
        {
            DataBaseManager target = new DataBaseManager();
            string type = "Kunde";
            string firstname = "Franz";
            string lastname = null;
            string expected = "SELECT * FROM " + type + " WHERE Vorname = ?";
            string actual;
            actual = target.GetKundenKontakteSQL(type, firstname, lastname);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A third test for GetKundenKontakteSQL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("EPU-Backoffice.exe")]
        public void GetKundenKontakteSQLTest2()
        {
            DataBaseManager target = new DataBaseManager();
            string type = "Kunde";
            string firstname = null;
            string lastname = null;
            string expected = "SELECT * FROM " + type;
            string actual;
            actual = target.GetKundenKontakteSQL(type, firstname, lastname);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A fourth test for GetKundenKontakteSQL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("EPU-Backoffice.exe")]
        public void GetKundenKontakteSQLTest3()
        {
            DataBaseManager target = new DataBaseManager();
            string type = "Kontakt";
            string firstname = "Hans";
            string lastname = "Huber";
            string expected = "SELECT * FROM " + type + " WHERE Vorname = ? AND Nachname_Firmenname = ?";
            string actual;
            actual = target.GetKundenKontakteSQL(type, firstname, lastname);
            Assert.AreEqual(expected, actual);
        }
    }
}

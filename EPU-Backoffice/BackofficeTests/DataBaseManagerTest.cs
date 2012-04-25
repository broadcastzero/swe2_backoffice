namespace BackofficeTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using EPUBackoffice.Dal;
    using EPUBackoffice.Dal.Tables;

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

            KundeKontaktTable k = new KundeKontaktTable();
            k.ID = -1; // indicates that it shall not be searched for ID
            k.Type = false;
            k.Vorname = string.Empty;
            k.NachnameFirmenname = "Huber";
            string expected = "SELECT * FROM Kunde WHERE Nachname_Firmenname = ?";
            string actual;
            actual = target.GetKundenKontakteSQL(k);
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

            KundeKontaktTable k = new KundeKontaktTable();
            k.ID = -1; // indicates that it shall not be searched for ID
            k.Type = false;
            k.Vorname = "Franz";
            k.NachnameFirmenname = string.Empty;
            string expected = "SELECT * FROM Kunde WHERE Vorname = ?";
            string actual;
            actual = target.GetKundenKontakteSQL(k);
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

            KundeKontaktTable k = new KundeKontaktTable();
            k.ID = -1; // indicates that it shall not be searched for ID
            k.Type = false;
            k.Vorname = string.Empty;
            k.NachnameFirmenname = string.Empty;
            string expected = "SELECT * FROM Kunde"; ;
            string actual;
            actual = target.GetKundenKontakteSQL(k);
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
            KundeKontaktTable k = new KundeKontaktTable();
            k.ID = -1; // don't search for ID
            k.Type = true;
            k.Vorname = "Hans";
            k.NachnameFirmenname = "Huber";
            string expected = "SELECT * FROM Kontakt WHERE Vorname = ? AND Nachname_Firmenname = ?";
            string actual;
            actual = target.GetKundenKontakteSQL(k);
            Assert.AreEqual(expected, actual);
        }
    }
}

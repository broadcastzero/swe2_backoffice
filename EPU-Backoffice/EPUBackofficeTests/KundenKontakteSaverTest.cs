namespace BackofficeTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Data.SQLite;
    using EPU_Backoffice_Panels.BL;
    using EPU_Backoffice_Panels.Dal;
    using EPU_Backoffice_Panels.Dal.Tables;
    using EPU_Backoffice_Panels.UserExceptions;

    /// <summary>
    ///This is a test class for GuiDataValidatorTest and is intended
    ///to contain all GuiDataValidatorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class KundenKontakteSaverTest
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
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            ConfigFileManager.MockDB = true;
        }

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
            if (MockDataBaseManager.SavedKontakte == null)
            {
                MockDataBaseManager testMockDB = new MockDataBaseManager();
                testMockDB.CreateDataBase();
            }
        }
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        ///A test for saveNewKunde
        ///test wrong entry, invalid first name
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(InvalidInputException), "Feld 'Vorname' ist ungültig!")]
        public void SaveNewKundeTest()
        {
            KundenKontakteSaver target = new KundenKontakteSaver(); // TODO: Initialize to an appropriate value
            KundeKontaktTable k = new KundeKontaktTable();

            k.Vorname = "Hans4*";
            k.NachnameFirmenname = "Mayer";
            k.Type = false;
            target.SaveNewKundeKontakt(k, new System.Windows.Forms.Label());
        }

        /// <summary>
        ///A test for saveNewKunde
        ///test wrong entry, invalid lastname / comp
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(InvalidInputException), "Feld 'Nachname/Firma' ist ungültig!")]
        public void SaveNewKundeTest1()
        {
            KundenKontakteSaver target = new KundenKontakteSaver();

            KundeKontaktTable k = new KundeKontaktTable();
            k.Vorname = string.Empty;
            k.NachnameFirmenname = "#";
            k.Type = false;
            target.SaveNewKundeKontakt(k, new System.Windows.Forms.Label());
        }
    }
}
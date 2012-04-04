namespace BackofficeTests
{
    using EPUBackoffice.BL;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Data.SQLite;
    using EPUBackoffice.UserExceptions;
    using EPUBackoffice.Dal;

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
            ConfigFileManager.mockDB = true;
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
            if (MockDataBaseManager.savedKontakte == null)
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
        public void saveNewKundeTest()
        {
            KundenKontakteSaver target = new KundenKontakteSaver(); // TODO: Initialize to an appropriate value
            string firstname = "Hans4*"; // TODO: Initialize to an appropriate value
            string lastname = "Mayer"; // TODO: Initialize to an appropriate value
            bool type = false; // TODO: Initialize to an appropriate value
            target.saveNewKundeKontakt(firstname, lastname, type);
        }

        /// <summary>
        ///A test for saveNewKunde
        ///test wrong entry, invalid lastname / comp
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(InvalidInputException), "Feld 'Nachname/Firma' ist ungültig!")]
        public void saveNewKundeTest1()
        {
            KundenKontakteSaver target = new KundenKontakteSaver(); // TODO: Initialize to an appropriate value
            string firstname = string.Empty; // TODO: Initialize to an appropriate value
            string lastname = "#"; // TODO: Initialize to an appropriate value
            bool type = false; // TODO: Initialize to an appropriate value
            target.saveNewKundeKontakt(firstname, lastname, type);
        }
    }
}
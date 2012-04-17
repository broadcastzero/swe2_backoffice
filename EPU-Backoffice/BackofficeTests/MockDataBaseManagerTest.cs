using EPUBackoffice.Dal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EPUBackoffice.Dal.Tables;
using System.Collections.Generic;
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
    using EPUBackoffice.Dal.Tables;
    using EPUBackoffice.UserExceptions;

    /// <summary>
    ///This is a test class for MockDataBaseManagerTest and is intended
    ///to contain all MockDataBaseManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MockDataBaseManagerTest
    {
        private TestContext testContextInstance;
        private MockDataBaseManager mdb;

        private static Object lockObj = new Object();

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
            this.mdb = new MockDataBaseManager();

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
        ///A test for CreateDataBase - the two static lists savedKontakte and savedKunden have to be initialized afterwards
        ///</summary>
        [TestMethod()]
        public void CreateDataBaseTest()
        {
            Assert.IsNotNull(MockDataBaseManager.SavedKontakte);
            Assert.IsNotNull(MockDataBaseManager.SavedKunden);
        }

        /// <summary>
        ///A test for SaveNewKunde - the saved Kunde has to be stored within the kunden-mockDB
        ///type: false...Kunde, true...Kontakt
        ///</summary>
        [TestMethod()]
        public void SaveNewKundeTest()
        {
            int count_before = MockDataBaseManager.SavedKunden.Count;

            KundeKontaktTable k = new KundeKontaktTable();
            k.Vorname = "Karl";
            k.NachnameFirmenname = "Grausgruber";
            k.Type = false; // Kunde
            
            this.mdb.SaveNewKundeKontakt(k);

            int count_after = MockDataBaseManager.SavedKunden.Count;

            Assert.AreEqual(count_before + 1, count_after);
        }

        /// <summary>
        ///A test for SaveNewKunde - the saved Kontakt has to be stored within the kontakt-mockDB
        ///</summary>
        [TestMethod()]
        public void SaveNewKundeTest2()
        {
            int count_before = MockDataBaseManager.SavedKontakte.Count;

            KundeKontaktTable k = new KundeKontaktTable();
            k.Vorname = "Hans";
            k.NachnameFirmenname = "Huber";
            k.Type = true; // Kontakt
            
            this.mdb.SaveNewKundeKontakt(k);

            int count_after = MockDataBaseManager.SavedKontakte.Count;

            Assert.AreEqual(count_before+1, count_after);
        }

        /// <summary>
        ///A test for SaveNewKunde - check if ID is continuing
        ///</summary>
        [TestMethod()]
        public void SaveNewKundeTest3()
        {
            int current = MockDataBaseManager.KundenID;
            Assert.AreEqual(current + 1, MockDataBaseManager.KundenID);
        }

        /// <summary>
        ///A test for DeleteKundeKontakt - must throw an exception, for there will never be an entry with the id -1
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(EntryNotFoundException))]
        public void DeleteKundeKontaktTest()
        {
            int id = -1;
            bool type = false;
            this.mdb.DeleteKundeKontakt(id, type);
        }

        /*/// <summary>
        ///A test for DeleteKundeKontakt - after deleting an entry, there must be one entry less in the list
        ///</summary>
        [TestMethod()]
        public void DeleteKundeKontaktTest1()
        {
            KundeKontaktTable k = new KundeKontaktTable();
            k.Vorname = string.Empty;
            k.NachnameFirmenname = "Huber";
            k.Type = false;
            k.ID = MockDataBaseManager.KundenID +1;

            this.mdb.SaveNewKundeKontakt(k);
            bool type = false;
            
            int savedBefore = MockDataBaseManager.SavedKunden.Count;
            this.mdb.DeleteKundeKontakt();
            int savedAfter = MockDataBaseManager.SavedKunden.Count;
            
            Assert.AreEqual(savedBefore, savedAfter+1);
        }*/
    }
}
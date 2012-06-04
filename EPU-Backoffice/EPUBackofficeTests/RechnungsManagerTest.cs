using EPU_Backoffice_Panels.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EPU_Backoffice_Panels.Dal.Tables;
using EPU_Backoffice_Panels.UserExceptions;

namespace EPUBackofficeTests
{
    
    
    /// <summary>
    ///This is a test class for RechnungsManagerTest and is intended
    ///to contain all RechnungsManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RechnungsManagerTest
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
        ///A test for CreateEingangsrechnung
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(InvalidInputException), "Daten ungültig!")]
        public void CreateEingangsrechnungTest()
        {
            RechnungsManager target = new RechnungsManager();
            EingangsrechnungTable table = new EingangsrechnungTable();
            table.Archivierungspfad = "path";
            table.Bezeichnung = "test";
            table.KontaktID = 1;
            table.Rechnungsdatum = string.Empty; // this should lead to exception
            
            target.CreateEingangsrechnung(table);            
        }
    }
}

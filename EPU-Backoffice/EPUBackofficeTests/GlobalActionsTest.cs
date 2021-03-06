﻿using EPU_Backoffice_Panels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace EPUBackofficeTests
{    
    /// <summary>
    ///This is a test class for GlobalActionsTest and is intended
    ///to contain all GlobalActionsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GlobalActionsTest
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
        ///A test for ParseToSQLiteDateString
        ///</summary>
        [TestMethod()]
        public void ParseToSQLiteDateStringTest()
        {
            DateTime dt = new DateTime(2012, 5,1);
            string input = dt.ToShortDateString();
            string expected = "2012-05-01 00:00:00";
            string actual;
            actual = GlobalActions.ParseToSQLiteDateString(input);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ShowSuccessLabel
        ///</summary>
        [TestMethod()]
        public void ShowSuccessLabelTest1()
        {
            Label l = new Label();
            GlobalActions.ShowSuccessLabel(l);
            Assert.IsTrue(l.Visible);
        }

        /// <summary>
        ///A test for ShowSuccessLabel
        ///</summary>
        [TestMethod()]
        public void ShowSuccessLabelTest2()
        {
            Label l = new Label();
            GlobalActions.ShowSuccessLabel(l);
            Assert.IsTrue(l.Text == "Erfolgreich aktualisiert.");
        }

        /// <summary>
        ///A test for ShowSuccessLabel
        ///</summary>
        [TestMethod()]
        public void ShowSuccessLabelTest3()
        {
            Label l = new Label();
            GlobalActions.ShowSuccessLabel(l);
            Assert.IsTrue(l.ForeColor == Color.Green);
        }
    }
}

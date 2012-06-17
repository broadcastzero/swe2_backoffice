// -----------------------------------------------------------------------
// <copyright file="ConfigFileManagerTest.cs" company="Marvin&Felix">
// You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace BackofficeTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Configuration;
    using System.Diagnostics;
    using EPU_Backoffice_Panels.BL;
    using EPU_Backoffice_Panels.Dal;

    /// <summary>
    ///This is a test class for ConfigFileManager and is intended
    ///to contain all ConfigFileManager Unit Tests
    ///</summary>
    [TestClass()]
    public class ConfigFileManagerTest
    {
        private TestContext testContextInstance;
        private ConfigFileManager target;

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
            target = new ConfigFileManager();
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
        /// A test for checkDataBaseExistance with a string as parameter - file does not end with .db
        /// Should return false, because "Logfile.txt" does exist, but does not end with ".db".
        /// </summary>
        [TestMethod()]
        public void CheckDataBaseExistanceTest2()
        {
            string path = "../../../EPU-Backoffice/bin/Debug/logs.txt";
            bool expected = false;
            bool actual;
            actual = target.CheckDataBaseExistance(path);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for checkDataBaseExistance without params - path is read out of Logfile.
        ///Actual should be false, when no Logfile is found (which is the case within the path in which tests are run).
        ///</summary>
        [TestMethod()]
        public void CheckLogfileExistanceTest()
        {
            bool expected = false;
            bool actual;
            actual = target.CheckDataBaseExistance();
            Assert.AreEqual(expected, actual);
        }
    }
}
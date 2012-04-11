using EPUBackoffice;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;
using Rulemanager;

namespace BackofficeTests
{    
    /// <summary>
    ///This is a test class for DataBindingFrameworkTest and is intended
    ///to contain all DataBindingFrameworkTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DataBindingFrameworkTest
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
        ///A test for BindFromInt
        ///</summary>
        [TestMethod()]
        public void BindFromIntTest()
        {
            TextBox sender = new TextBox();
            sender.Text = "42";
            Label label = new Label();
            int expected = 42;
            int actual;
            actual = DataBindingFramework.BindFromInt(sender, label, Rulemanager.Rules.PositiveInt);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A second test for BindFromInt
        ///</summary>
        [TestMethod()]
        public void BindFromIntTest1()
        {
            TextBox sender = new TextBox();
            sender.Text = "-42";
            Label label = new Label();
            int expected = -1;
            int actual;
            actual = DataBindingFramework.BindFromInt(sender, label, Rulemanager.Rules.PositiveInt);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A third test for BindFromInt
        ///</summary>
        [TestMethod()]
        public void BindFromIntTest2()
        {
            TextBox sender = new TextBox();
            sender.Text = "4x2";
            Label label = new Label();
            int expected = -1;
            int actual;
            actual = DataBindingFramework.BindFromInt(sender, label, Rulemanager.Rules.PositiveInt);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A fourth test for BindFromInt
        ///</summary>
        [TestMethod()]
        public void BindFromIntTest3()
        {
            TextBox sender = new TextBox();
            sender.Text = "41";
            Label label = new Label();
            int expected = 41;
            int actual;
            actual = DataBindingFramework.BindFromInt(sender, label, Rulemanager.Rules.PositiveInt);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A fourth test for BindFromInt
        ///</summary>
        [TestMethod()]
        public void BindFromIntTest4()
        {
            TextBox sender = new TextBox();
            sender.Text = "101";
            Label label = new Label();
            int expected = -1;
            int actual;
            actual = DataBindingFramework.BindFromInt(sender, label, Rulemanager.Rules.PositiveInt);
            Assert.AreEqual(expected, actual);
        }
    }
}

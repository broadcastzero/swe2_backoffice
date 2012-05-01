using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;
using EPU_Backoffice_Panels;
using EPU_Backoffice_Panels.DatabindingFramework;
using EPU_Backoffice_Panels.Dal.Tables;
using EPU_Backoffice_Panels.Rules;

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

            IRule posval = new PositiveIntValidator();

            actual = DataBindingFramework.BindFromInt(sender.Text, "Integer", label, false, posval);
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

            IRule posval = new PositiveIntValidator();

            actual = DataBindingFramework.BindFromInt(sender.Text, "Integer", label, false, posval);
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

            IRule posval = new PositiveIntValidator();

            actual = DataBindingFramework.BindFromInt(sender.Text, "Integer", label, false, posval);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A fourth test for BindFromInt
        ///</summary>
        [TestMethod()]
        public void BindFromIntTest3()
        {
            TextBox sender = new TextBox();
            sender.Text = "0";
            Label label = new Label();
            int expected = 0;
            int actual;

            IRule posval = new PositiveIntValidator();

            actual = DataBindingFramework.BindFromInt(sender.Text, "Integer", label, false, posval);
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
            int expected = 101;
            int actual;

            IRule posval = new PositiveIntValidator();

            actual = DataBindingFramework.BindFromInt(sender.Text, "Integer", label, false, posval);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for BindFromString
        ///</summary>
        [TestMethod()]
        public void BindFromStringTest()
        {
            TextBox sender = new TextBox();
            sender.Text = string.Empty;
            Label label = new Label();
            string actual;

            actual = DataBindingFramework.BindFromString(sender.Text, "anyname", label, false);

            Assert.IsTrue(label.Visible);
        }

        /// <summary>
        ///A test for BindFromDouble
        ///</summary>
        [TestMethod()]
        public void BindFromDoubleTest()
        {
            TextBox sender = new TextBox();
            sender.Text = "4,33";
            Label label = new Label();
            double expected = 4.33;
            double actual;

            IRule val = new PositiveDoubleValidator();

            actual = DataBindingFramework.BindFromDouble(sender.Text, "Double", label, false, val);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A second test for BindFromDouble
        ///</summary>
        [TestMethod()]
        public void BindFromDoubleTest1()
        {
            TextBox sender = new TextBox();
            sender.Text = string.Empty;
            Label label = new Label();

            double expected = 0;
            double actual;

            IRule doubleval = new PositiveDoubleValidator();

            actual = DataBindingFramework.BindFromDouble(sender.Text, "Double", label, true, doubleval);
            Assert.AreEqual(expected, actual);
        }
    }
}

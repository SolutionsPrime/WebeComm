using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eCommSite.SolutionsPrime;

namespace eCommSite
{
    /// <summary>
    /// Summary description for Examples
    /// </summary>
    [TestClass]
    public class Examples 
    {
        public Examples()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        //[TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine("test started");
            spCvsData cdata = new spCvsData();
            cdata.cvsFile = spCvsData.cvsFilePath + "TestSetData1.csv";
            cdata.cvsDelimiter = ",";
            spCvsData.testData = cdata.getCvsData();
            DataRow tdr = cdata.getTestCaseData("DisplayOrder");

            spWrapper spw = new spWrapper();
            spWrapper.ProjectDetails["BaseStateURL"] = "http://automationpractice.com/";
            spw.initBrowser(false, spWrapper.BrowserType.ChromeMobile);

        }

        //[TestMethod]
        public void TestMethod2()
        {
            Scripts.Register r = new Scripts.Register();
            r.registerAccount();

        }
    }
}

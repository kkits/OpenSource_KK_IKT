using NetsLibrary.entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace NetsTestProsjekt
{
    /// <summary>
    ///This is a test class for ForsendelseTest and is intended
    ///to contain all ForsendelseTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ForsendelseTest
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
        ///A test for Forsendelse Constructor
        ///</summary>
        [TestMethod()]
        public void ForsendelseConstructorTest()
        {
            int KundeID = 12345678; // TODO: Initialize to an appropriate value
            int ForsendelsesNr = 1234; // TODO: Initialize to an appropriate value
            Forsendelse target = new Forsendelse(KundeID, ForsendelsesNr);
            Assert.IsNotNull(target);
        }
    }
}
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CategoriesDataDriven.jupiter.pages;

namespace CategoriesDataDriven.jupiter.tests
{
    [TestClass]
    public class ContactPageTests : BaseTestSuite
    {
        [TestInitialize]
        public void PreTestSetup()
        {
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().GoToUrl("http://jupiter.cloud.planittesting.com");
        }

        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\jupiter.data\\data.csv", "data#csv", DataAccessMethod.Sequential)]
        [TestCategory("Smoke"), TestCategory("Regression")]
        [TestMethod]
        public void DataDrivenSubmissionTest()
        {
            HomePage homePage = new HomePage(driver);
            ContactPage contactPage = homePage.clickContact();
            //set variables from datasource
            string forename = TestContext.DataRow["forename"].ToString();
            string email = TestContext.DataRow["email"].ToString();
            string telephone = TestContext.DataRow["telephone"].ToString(); 
            string message = message = TestContext.DataRow["message"].ToString(); 
            string forenameerror = TestContext.DataRow["forenameerror"].ToString();
            string emailerror = TestContext.DataRow["emailerror"].ToString(); 
            string telephoneerror = TestContext.DataRow["telephoneerror"].ToString(); 
            string messageerror = TestContext.DataRow["messageerror"].ToString(); 
            string expectedsubmission = TestContext.DataRow["expectedsubmission"].ToString();

            System.Diagnostics.Debug.WriteLine("forename: " + forename);
            System.Diagnostics.Debug.WriteLine("email: " + email);
            System.Diagnostics.Debug.WriteLine("telephone: " + telephone);
            System.Diagnostics.Debug.WriteLine("message: " + message);

            contactPage.setForename(forename);
            contactPage.setEmail(email);
            contactPage.setTelephoneNumber(telephone);
            contactPage.setMessage(message);
            contactPage.clickSubmitButton();

            if (expectedsubmission.Equals("true"))
            {
                Assert.AreEqual("Thanks " + forename + ", we appreciate your feedback.", contactPage.getFormSuccessMessage(),"Valid submission displays success message");
            }
            else {
                Assert.AreEqual("We welcome your feedback - but we won't get it unless you complete the form correctly.", contactPage.getSubmitError(), "Invalid submission displays error message");
            }

            if (!forenameerror.Equals(""))
            {
                Assert.AreEqual(forenameerror, contactPage.getForenameError(), "Forename error correctly displayed");
            }
            if (!emailerror.Equals(""))
            {
                Assert.AreEqual(emailerror, contactPage.getEmailError(), "Email error correctly displayed");
            }
            if (!telephoneerror.Equals(""))
            {
                Assert.AreEqual(telephoneerror, contactPage.getTelephoneNumberError(), "Telephone error correctly displayed");
            }
            if (!messageerror.Equals(""))
            {
                Assert.AreEqual(messageerror, contactPage.getMessageError(), "Message error correctly displayed");
            }

        }
    }
}

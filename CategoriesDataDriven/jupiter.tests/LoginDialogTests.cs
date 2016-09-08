using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CategoriesDataDriven.jupiter.pages;

namespace CategoriesDataDriven.jupiter.tests
{
    [TestClass]
    public class LoginDialogTests : BaseTestSuite
    {
        [TestInitialize]
        public void PreTestSetup()
        {
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().GoToUrl("http://jupiter.cloud.planittesting.com");
        }

        [TestCategory("Regression")]
        [TestMethod]
        public void errorOnEmptyCredentials()
        {
            HomePage homePage = new HomePage(driver);
            LoginDialog loginDialog = homePage.clickLogin();

            loginDialog.clickLoginButton();
            Assert.AreEqual("Your login details are incorrect", loginDialog.getLoginError(), "Login details error displayed on empty entry");
        }

        [TestCategory("Regression")]
        [TestMethod]
        public void errorOnMissingPassword()
        {
            HomePage homePage = new HomePage(driver);
            LoginDialog loginDialog = homePage.clickLogin();

            loginDialog.setUserName("test");

            loginDialog.clickLoginButton();
            Assert.AreEqual("Your login details are incorrect", loginDialog.getLoginError(), "Login details error displayed on empty password");
        }

        [TestCategory("Regression")]
        [TestMethod]
        public void errorOnIncorrectPassword()
        {
            HomePage homePage = new HomePage(driver);
            LoginDialog loginDialog = homePage.clickLogin();

            loginDialog.setUserName("test");
            loginDialog.setPassword("incorrectpassword");

            loginDialog.clickLoginButton();
            Assert.AreEqual("Your login details are incorrect", loginDialog.getLoginError(), "Login details error displayed on incorrect password");
        }

        [TestCategory("Smoke"), TestCategory("Regression")]
        [TestMethod]
        public void successfulLogin()
        {
            HomePage homePage = new HomePage(driver);
            LoginDialog loginDialog = homePage.clickLogin();

            loginDialog.setUserName("test");
            loginDialog.setPassword("letmein");

            loginDialog.clickLoginButton();
            Assert.AreEqual("test", homePage.getLoggedInUsername(), "Logged in username displayed");
        }

        [TestCategory("Regression")]
        [TestMethod]
        public void cancelLogin()
        {
            HomePage homePage = new HomePage(driver);
            LoginDialog loginDialog = homePage.clickLogin();

            loginDialog.setUserName("test");
            loginDialog.setPassword("letmein");

            loginDialog.clickCancelButton();
            Assert.AreEqual("", homePage.getLoggedInUsername(), "Logged in username displayed");
        }
    }
}

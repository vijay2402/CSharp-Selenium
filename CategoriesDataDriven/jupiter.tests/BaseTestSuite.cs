using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace CategoriesDataDriven
{
    [TestClass]
    public abstract class BaseTestSuite
    {
        protected static IWebDriver driver;

        [AssemblyInitialize]
        public static void TestSetUp(TestContext context)
        {
            string browser = GetEnvironmentVariable();
            if (browser.Equals("Chrome"))
            {
                driver = new ChromeDriver();
            }else if (browser.Equals("Firefox"))
            {
                driver = new FirefoxDriver();
            }else if (browser.Equals("IE"))
            {
                driver = new InternetExplorerDriver();
            }
            else
            {
                driver = new ChromeDriver();
            }
                   
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
        }

        public static string GetEnvironmentVariable()
        {
            return Environment.GetEnvironmentVariable("MYBROWSER", EnvironmentVariableTarget.Machine) ?? "";
        }

        [AssemblyCleanup]
        public static void TestTearDown()
        {
            driver.Quit();
        }
    }
}

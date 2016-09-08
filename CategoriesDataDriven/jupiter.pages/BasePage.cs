using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoriesDataDriven.jupiter.pages
{
    //the base page is created when your app has base functionality accessible throughout the app
    //for instance navigation which is shared between all screens. headers or footers which don't change etc
    public abstract class BasePage
    {

        //the base page has its own instance of the driver to work with
        protected IWebDriver driver;

        //the local instance is set to the instance passed all the way from the BaseTestSuite, through the test classes
        //to the page classes which extend the BasePage
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //methods can return new instances of objects. Useful when clicking something changes the interface under test
        public HomePage clickHomePage()
        {
            this.driver.FindElement(By.CssSelector("#nav-home a")).Click();
            return new HomePage(this.driver);
        }

        public ContactPage clickContact()
        {
            this.driver.FindElement(By.CssSelector("#nav-contact a")).Click();
            return new ContactPage(this.driver);
        }

        public LoginDialog clickLogin()
        {
            this.driver.FindElement(By.CssSelector("#nav-login a")).Click();
            return new LoginDialog(this.driver);
        }

        public String getLoggedInUsername()
        {
            ICollection<IWebElement> userName = driver.FindElements(By.CssSelector("#nav-user .user"));
            return userName.Count() == 0 ? "" : driver.FindElement(By.CssSelector("#nav-user .user")).Text;
        }

    public int getCartCount()
        {
            return Int32.Parse(this.driver.FindElement(By.ClassName("cart-count")).Text);
        }
    }
}

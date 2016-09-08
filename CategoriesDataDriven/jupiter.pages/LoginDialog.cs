using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoriesDataDriven.jupiter.pages
{
    public class LoginDialog
    {

        private IWebDriver driver;

        public LoginDialog(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void setUserName(String value)
        {
            this.driver.FindElement(By.Id("loginUserName")).SendKeys(value);
        }

        public void setPassword(String value)
        {
            this.driver.FindElement(By.Id("loginPassword")).SendKeys(value);
        }

        public void clickLoginButton()
        {
            this.driver.FindElement(By.CssSelector(".popup .btn-primary")).Click();
        }

        public void clickCancelButton()
        {
            this.driver.FindElement(By.CssSelector(".popup .btn-cancel")).Click();
        }

        public String getLoginError()
        {
            ICollection<IWebElement> loginErrors = driver.FindElements(By.Id("login-error"));
            return loginErrors.Count() == 0 ? "" : driver.FindElement(By.Id("login-error")).Text;
        }
    }
}

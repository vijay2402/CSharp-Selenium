using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CategoriesDataDriven.jupiter.pages
{
    public class ContactPage : BasePage
    {
        public ContactPage(IWebDriver driver) : base(driver) { }

        //all methods are written with very clear naming so that non technical users can understand the code
        //rather than rolling lots of indivIdual methods into single grouped methods, its more readable to
        //have everything separated indivIdually. a majority of the methods in these classes will be get set and click
        public void setForename(String value)
        {
            driver.FindElement(By.Id("forename")).SendKeys(value);
        }
        public String getForenameError()
        {
            ICollection<IWebElement> fornameErrors = driver.FindElements(By.Id("forename-err"));
            return fornameErrors.Count() == 0 ? "" : driver.FindElement(By.Id("forename-err")).Text;
        }

        public void setEmail(String value)
        {
            driver.FindElement(By.Id("email")).SendKeys(value);
        }
        public String getEmailError()
        {
            ICollection<IWebElement> fornameErrors = driver.FindElements(By.Id("email-err"));
            return fornameErrors.Count() == 0 ? "" : driver.FindElement(By.Id("email-err")).Text;
        }

        public void setMessage(String value)
        {
            driver.FindElement(By.Id("message")).SendKeys(value);
        }
        public string getMessageError()
        {
            ICollection<IWebElement> fornameErrors = driver.FindElements(By.Id("message-err"));
            return fornameErrors.Count() == 0 ? "" : driver.FindElement(By.Id("message-err")).Text;
        }

        public void setTelephoneNumber(String value)
        {
            driver.FindElement(By.Id("telephone")).SendKeys(value);
        }
        public string getTelephoneNumberError()
        {
            ICollection<IWebElement> fornameErrors = driver.FindElements(By.Id("telephone-err"));
            return fornameErrors.Count() == 0 ? "" : driver.FindElement(By.Id("telephone-err")).Text;
        }

        public void clickSubmitButton()
        {
            driver.FindElement(By.LinkText("Submit")).Click();
        }


        public string getFormSuccessMessage()
        {
            (new WebDriverWait(driver, TimeSpan.FromSeconds(60)))
            .Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".alert-success")));
            return driver.FindElement(By.CssSelector(".alert-success")).Text;
        }

        public String getSubmitError()
        {
            (new WebDriverWait(driver, TimeSpan.FromSeconds(60)))
            .Until(ExpectedConditions.ElementToBeClickable(By.ClassName("alert-error")));
            return driver.FindElement(By.ClassName("alert-error")).Text;
        }
    }
}

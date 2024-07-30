using OpenQA.Selenium;
using System;
using System.Threading;

namespace NUnit.POM
{
    public class Login
    {
         By emailField = By.XPath("//*[@type='email']");
         By emailButton = By.Id("email-btn");
         By submitButton = By.Id("1-submit");
         By continueButton = By.XPath("//button[@aria-label='Continue']");

        public void enterEmail(IWebDriver driver, String email)
        {
            driver.FindElement(emailField).SendKeys(email);
        }

        public void submitEmail(IWebDriver driver)
        {
            driver.FindElement(emailButton).Click();
        }
          
        public void confirmEmail(IWebDriver driver)
        {
            driver.FindElement(submitButton).Click();
        }

        public void submitOTP(IWebDriver driver)
        {
            Thread.Sleep(TimeSpan.FromSeconds(15));
            driver.FindElement(continueButton).Click();
        }

        public void LoginToWebsite(IWebDriver driver, String email)
        {
            driver.FindElement(emailField).SendKeys(email);
            driver.FindElement(emailButton).Click();
            driver.FindElement(submitButton).Click();

            Thread.Sleep(TimeSpan.FromSeconds(15));
            driver.FindElement(continueButton).Click();
        }
    }
}

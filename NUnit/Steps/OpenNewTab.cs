using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using System.Configuration;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using NUnit.POM;

namespace NUnit.Steps
{

    [Binding]

    class OpenNewTab
    {
        IWebDriver currentDriver = null;

        
        [Given(@"I have navigated to the website")]

        public void GivenIHaveNavigatedToAmazonWebsite()
        {
            currentDriver = new ChromeDriver();
            currentDriver.Navigate().GoToUrl("https://fenixshare.anchormydata.com/fenixpyre/s/669ff2910e5caf9f73cd28ea/QA%2520Assignment");
        }

        [When(@"I have entered my email address and click submit")]
        public void IEnterEmailAddress()
        {
            currentDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            currentDriver.FindElement(By.XPath("//*[@type='email']")).SendKeys("hammadbangash.1@gmail.com");
            currentDriver.FindElement(By.Id("email-btn")).Click();
        }

        [When(@"I verify my email address")]
        public void AndIVerifyEmail()
        {
            currentDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            currentDriver.FindElement(By.Id("1-submit")).Click();
        }

        [Then(@"I enter submit")]
        public void AndIEnterSubmit()
        {
            Thread.Sleep(TimeSpan.FromSeconds(15));
            currentDriver.FindElement(By.XPath("//button[@aria-label='Continue']")).Click();
        }
    }
}

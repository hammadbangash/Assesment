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
using System.IO;
using NUnit.Framework.Interfaces;

namespace NUnit.Steps
{
    [Binding]
    class NewTab
    {
        IWebDriver currentDriver = new ChromeDriver();
        FileListPage fileListPage = new FileListPage();
        Login loginPage = new Login();
        [BeforeFeature]
        public static void setup()
        {

        }

        [Given(@"I have logged in")]
        public void GivenIHaveNavigatedToAmazonWebsite()
        {
            currentDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            currentDriver.Navigate().GoToUrl("https://fenixshare.anchormydata.com/fenixpyre/s/669ff2910e5caf9f73cd28ea/QA%2520Assignment");

            loginPage.LoginToWebsite(currentDriver, "hammadbangash.1@gmail.com");

             var wait = new WebDriverWait(currentDriver, new TimeSpan(0, 0, 30));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlMatches("https://fenixshare.anchormydata.com/fenixpyre/s/669ff2910e5caf9f73cd28ea/QA%20Assignment"));

        }

        [Given(@"I have clicked on action button")]
        public void ClickActionButton()
        {
            fileListPage.ClickActionButton(currentDriver);
        }

        [Given(@"I click on new tab button")]
        public void ClickNewTabButton()
        {
            fileListPage.ClickOpenNewTab(currentDriver);
        }

        [Then(@"New Tab opens")]
        public void VerifyNewTabOpens()
        {
            List<String> browserTabs = new List<String>(currentDriver.WindowHandles);
            Assert.That(browserTabs.Count, Is.EqualTo(2));

            currentDriver = currentDriver.SwitchTo().Window(browserTabs[1]);

            Thread.Sleep(TimeSpan.FromSeconds(15));

            Assert.That(currentDriver.Url, Is.EqualTo("https://fenixshare.anchormydata.com/fenixpyre/v/Book.xlsx"));

            //String mode = currentDriver.FindElement(By.Id("ModeSwitcher")).GetAttribute("aria-label");
            //Assert.That(mode, Is.EqualTo("Mode Menu;Editing Selected"));

        }


        [AfterScenario()]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Screenshot result = ((ITakesScreenshot)currentDriver).GetScreenshot();
                result.SaveAsFile(Path.Combine(Directory.GetCurrentDirectory(), "login-" + (new Random().Next(1, 101).ToString()) + ".png"));


            }
        }
    }
}

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
using NUnit.Framework.Interfaces;
using System.IO;

namespace NUnit.Steps
{
    [Binding]
    class LoginToWebsite
    {
        static IWebDriver currentDriver;
        static FileListPage fileListPage;
        static Login login;

        [BeforeFeature]
        public static void setup()
        {
            currentDriver = new ChromeDriver();
            fileListPage = new FileListPage();
            login = new Login();
        }

        [Given(@"I have navigated to the website")]

        public void GivenIHaveNavigatedToAmazonWebsite()
        {
            currentDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            currentDriver.Navigate().GoToUrl("https://fenixshare.anchormydata.com/fenixpyre/s/669ff2910e5caf9f73cd28ea/QA%2520Assignment");

        }

        [When(@"I have entered my email address and click submit")]
        public void IEnterEmailAddress()
        {
            login.enterEmail(currentDriver, "hammadbangash.1@gmail.com");
            login.submitEmail(currentDriver);
        }

        [When(@"I verify my email address")]
        public void AndIVerifyEmail()
        {

            login.confirmEmail(currentDriver);
        }

        [Then(@"I enter submit")]
        public void AndIEnterSubmit()
        {
            login.submitOTP(currentDriver);

            var wait = new WebDriverWait(currentDriver, new TimeSpan(0, 0, 30));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlMatches("https://fenixshare.anchormydata.com/fenixpyre/s/669ff2910e5caf9f73cd28ea/QA%20Assignment"));
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



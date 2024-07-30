﻿using System;
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
    class Preview
    {
        static IWebDriver currentDriver;
        static FileListPage fileListPage;

        [BeforeFeature]
        public static void setup()
        {
            currentDriver = new ChromeDriver();
            fileListPage = new FileListPage();
        }


        [Given(@"I click on preview button")]
        public void ClickPreviewButton()
        {
            fileListPage.ClickPreviewButton(currentDriver);
        }

        [Then(@"Preview tab opens")]
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
                result.SaveAsFile(Path.Combine(Directory.GetCurrentDirectory(), "failures/login-" + (new Random().Next(1, 10001).ToString()) + ".png"));


            }
        }
    }
}

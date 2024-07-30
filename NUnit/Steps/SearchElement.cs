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
    class SearchElement
    {
        IWebDriver currentDriver = new ChromeDriver();
        FileListPage fileListPage = new FileListPage();

        [BeforeFeature]
        public static void setup()
        {

        }

        [When(@"I click home button")]
        public void IClickHomeButton()
        {
            Thread.Sleep(TimeSpan.FromSeconds(50));
            fileListPage.ClickHomeButton(currentDriver);
        }

        [Given(@"I search a product")]
        public void ISearchAProduct()
        {
            fileListPage.SearchProduct(currentDriver, "Book");
        }

        [Then(@"Product should show")]
        public void AndIEnterSubmit()
        {
            String prodName = fileListPage.GetFirstElementofRow(currentDriver);
            Assert.That(prodName, Is.EqualTo("Book.xlsx"));
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



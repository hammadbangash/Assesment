using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.POM
{
    public class FileListPage
    {

        By firstRowActionButton = By.Id("radix-:r16:");
        By openNewTabButton = By.Id("fp-sharedlink-table-body-0-0_actions-open");
        By openPreviewButton = By.Id("fp-sharedlink-table-body-0-0_actions-preview");
        By openHomeButton = By.XPath("//*[@aria-label='Home']");
        By searchProductField = By.Id("fp-home-recentfiles-search-bar");
        By itemTable = By.XPath("//table[class='w-full caption-bottom text-sm']");
        By firstRowOfTable = By.XPath("//tr[@id='fp-home-recentfiles-recenttable-body-0'] > //td[@id='fp-home-recentfiles-recenttable-body-0-0_name'] > div > button > //span[@aria-label='Book.xlsx']");
        public void ClickActionButton(IWebDriver driver)
        {
            driver.FindElement(firstRowActionButton).Click();
        }

        public void ClickOpenNewTab(IWebDriver driver)
        {
            driver.FindElement(openNewTabButton).Click();

        }

        public void ClickHomeButton(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(openHomeButton));

            driver.FindElement(openHomeButton).Click();
        }
        public void ClickPreviewButton(IWebDriver driver)
        {
            driver.FindElement(openPreviewButton).Click();
        }

        public void OpenHomePage(IWebDriver driver)
        {
            driver.FindElement(openHomeButton).Click();
        }

        public void SearchProduct (IWebDriver driver, String product)
        {
            driver.FindElement(searchProductField).SendKeys(product);
        }

        public string GetFirstElementofRow(IWebDriver driver)
        {
            String text = driver.FindElement(firstRowOfTable).Text;
            return text;
        }
    }
}

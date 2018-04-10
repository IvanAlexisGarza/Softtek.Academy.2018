using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Testing.SurveyTest
{
    class CITesting
    {
        [Test]
        public void OpenPage()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "http://localhost:64226/";

            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/ul/li[1]/a")).Click();

            driver.FindElement(By.XPath("/ html / body / div[2] / a")).Click();



            driver.FindElement(By.XPath("//*[@id="IsActive"]")).Click();


            SelectElement oSelect = new SelectElement(driver.FindElement(By.Id("Status")));

            oSelect.selectByText("2010");

            driver.Quit();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;

namespace SeleniumTesting
{
    class NUnitTest
    {
        IWebDriver driver;
        [SetUp]
        public void Initialize()
        {
            driver = new FirefoxDriver();
        }

        [Test]
        public void OpenAppTest()
        {
            driver.Url = "http://www.demoqa.com";
        }

        [TearDown]
        public void EndTask()
        {
            driver.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumTesting.SeleniumBasics;


namespace SeleniumTesting
{
    class FirstTestCase
    {
        static void Main(string[] args)
        {
            Practice1 _practice1 = new Practice1();

            //IWebDriver driver = new FirefoxDriver();
            //driver.Url = "http://www.demoqa.com";

            _practice1.Exercise1();
        }
    }
}

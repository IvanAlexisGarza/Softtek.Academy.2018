using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Test Instructions
    //Launch a new Firefox browser.
    //Open Store.DemoQA.com
    //Get Page Title name and Title length
    //Print Page Title and Title length on the Console.
    //Get Page URL and Page Url Length
    //Print Page URL and Page Url Length on the Console.
    //Get Page Source (HTML Source code) and Page Source length
    //Print Page Length on Console.
    //Close the Browser.
#endregion


namespace SeleniumTesting.SeleniumBasics
{
    class Practice1
    {
        IWebDriver driver;


        public void Exercise1()
        {
            driver = new FirefoxDriver();
            driver.Url = "http://www.Store.DemoQA.com";

            string PageTitle = driver.Title;
            Console.WriteLine($"Page Title is: {PageTitle}");
            Console.WriteLine($"Title Length is: {PageTitle.Length}");

            string PageUrl = driver.Url;
            Console.WriteLine($"Page URL is: {PageUrl}");
            Console.WriteLine($"URL Length is: {PageUrl.Length}");

            string PageSource = driver.PageSource;
            Console.WriteLine($"Page Source Length is: {PageSource.Length}");

            driver.Quit();  
        }
    }
}

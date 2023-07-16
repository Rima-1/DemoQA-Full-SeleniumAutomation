using AventStack.ExtentReports;
using CivicPlus_Selenium_Demo;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Xml.Linq;

namespace CivicPlus_Selenium_Demo
{
    public class NewTabPage : BaseDriver
    {
        public NewTabPage(IWebDriver driver, ExtentTest extenttest) : base(driver, extenttest) { }
        


        public string HeadingOfNewTabPage()
        {
            return ChromeDriver.FindElement(By.XPath("/html")).Text;
        }



    }
}

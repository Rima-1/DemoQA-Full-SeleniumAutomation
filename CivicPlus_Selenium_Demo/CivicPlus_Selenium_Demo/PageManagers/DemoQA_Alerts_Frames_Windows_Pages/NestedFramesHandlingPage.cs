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
    public class NestedFramesHandlingPage : BaseDriver
    {
        public NestedFramesHandlingPage(IWebDriver driver, ExtentTest extenttest) : base(driver, extenttest) { }

        public void OpenURL_NestedFramesHandlingPage()
        {
            test.Log(Status.Info, "Navigating to URL of demoQA Elements Nested Frames page");
            //ChromeDriver.Navigate().GoToUrl("https://demoqa.com/nestedframes");
            OpenURL("https://demoqa.com/nestedframes");
        }

        public bool IsSwitchedToParentFrame()
        {
            
            test.Log(Status.Info, "Check if correctly switched to Parent IFrame");
            ChromeDriver.SwitchTo().Frame(ChromeDriver.FindElement(By.Id("frame1")));
            ScrollElementIntoViewJSVersion(ChromeDriver, By.XPath("//*[contains(text(),'Parent frame')]"));
            return ChromeDriver.FindElement(By.XPath("//*[contains(text(),'Parent frame')]")).Text.Contains("Parent frame");
        }
        
        public bool IsSwitchedToChildFrame()
        {
            test.Log(Status.Info, "Check if correctly switched to Child IFrame");
            ChromeDriver.SwitchTo().Frame(ChromeDriver.FindElement(By.XPath("//iframe[contains(@srcdoc,'Child Iframe')]")));
            return ChromeDriver.FindElement(By.XPath("//*[contains(text(),'Child Iframe')]")).Text.Contains("Child Iframe");
        }

        public bool IsSwitchedToDefaultContent()
        {
            test.Log(Status.Info, "Check if correctly switched to Default Content");
            ChromeDriver.SwitchTo().DefaultContent();
            return ChromeDriver.FindElement(By.XPath("//*[contains(text(),'Sample Nested Iframe page.')]")).Text.Contains("Sample Nested Iframe page.");
        }
    }
}

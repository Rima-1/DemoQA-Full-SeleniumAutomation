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
    public class FramesHandlingPage : BaseDriver
    {
        public FramesHandlingPage(IWebDriver driver, ExtentTest extenttest) : base(driver, extenttest) { }
        
        public void OpenURL_FramesHandlingPage()
        {
            test.Log(Status.Info, "Navigating to URL of demoQA Elements Frames page");
            //ChromeDriver.Navigate().GoToUrl("https://demoqa.com/frames");
            OpenURL("https://demoqa.com/frames");
        }

        public bool IsSwitchedToFrame1()
        {
            test.Log(Status.Info, "Check if correctly switched to IFrame1");
            ChromeDriver.SwitchTo().Frame("frame1");
            return ChromeDriver.FindElement(By.XPath("/html")).Text.Contains("This is a sample page");
        }
        public bool IsSwitchedToDefaultContent()
        {
            test.Log(Status.Info, "Check if correctly switched to Default Content");
            ChromeDriver.SwitchTo().DefaultContent();
            return ChromeDriver.FindElement(By.ClassName("main-header")).Text.Contains("Frames");
        }
        public bool IsSwitchedToFrame2()
        {
            test.Log(Status.Info, "Check if correctly switched to IFrame2");
            ChromeDriver.SwitchTo().Frame("frame2");
            return ChromeDriver.FindElement(By.XPath("/html")).Text.Contains("This is a sample page");
        }
    }
}

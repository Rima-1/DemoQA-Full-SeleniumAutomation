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
    public class BrowserWindowsPage : BaseDriver
    {
        public BrowserWindowsPage(IWebDriver driver, ExtentTest extenttest) : base(driver, extenttest) { }
        private By newTabButton = By.Id("tabButton");
        private By newWindowButton = By.Id("windowButton");
        private By newWindowMessageButton = By.Id("messageWindowButton");

        public void OpenURL_BrowserWindowsPage()
        {
            test.Log(Status.Info, "Navigating to URL of demoQA Elements Browser Windows page");
            //ChromeDriver.Navigate().GoToUrl("https://demoqa.com/browser-windows");
            OpenURL("https://demoqa.com/browser-windows");
        }

        public bool IsNewTabButtonClicked()
        {
            test.Log(Status.Info, "Check if New Tab Button is clickable & click on it");
            ClickElement(ChromeDriver, newTabButton);
            return true;
        }

        public bool IsLandedOnNewTabPage()
        {
            test.Log(Status.Info, "Check if Landed on New Tab Page");
            ChromeDriver.SwitchTo().Window(ChromeDriver.WindowHandles[1]);
            return new NewTabPage(ChromeDriver, test).HeadingOfNewTabPage().Equals("This is a sample page");
        }

        public bool IsNewWindowButtonClicked()
        {
            test.Log(Status.Info, "Check if New Window Button is clickable & click on it");
            ChromeDriver.SwitchTo().Window(ChromeDriver.WindowHandles[0]);
            ClickElement(ChromeDriver, newWindowButton);
            return true;
        }

        public bool IsLandedOnNewWindowPage()
        {
            test.Log(Status.Info, "Check if Landed on New Window Page");
            var aa = ChromeDriver.WindowHandles;
            ChromeDriver.SwitchTo().Window(ChromeDriver.WindowHandles[2]);
            return new NewWindowPage(ChromeDriver, test).HeadingOfNewWindowPage().Equals("This is a sample page");
        }

        public bool IsNewWindowMessageButtonClicked()
        {
            test.Log(Status.Info, "Check if New Window Message Button is clickable & click on it");
            ChromeDriver.SwitchTo().Window(ChromeDriver.WindowHandles[0]);
            ClickElement(ChromeDriver, newWindowMessageButton);
            return true;
        }

        public bool IsLandedOnNewWindowMessagePage()
        {
            test.Log(Status.Info, "Check if Landed on New Window Message Page");
            ChromeDriver.SwitchTo().Window(ChromeDriver.WindowHandles[3]);
            return new NewWindowMessagePage(ChromeDriver, test).HeadingOfNewWindowMessagePage().Equals("Knowledge increases by sharing but not by saving. Please share this website with your friends and in your organization.");
        }
        public void SwitchingToParentWindow()
        {
            ChromeDriver.SwitchTo().Window(ChromeDriver.WindowHandles[0]);
        }
    }
}

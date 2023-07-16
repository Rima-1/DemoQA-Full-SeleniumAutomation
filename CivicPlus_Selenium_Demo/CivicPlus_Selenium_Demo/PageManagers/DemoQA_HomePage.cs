using AventStack.ExtentReports;
using CivicPlus_Selenium_Demo;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace CivicPlus_Selenium_Demo
{
    public class DemoQA_HomePage : BaseDriver
    {
        public DemoQA_HomePage(IWebDriver driver, ExtentTest extenttest) : base(driver, extenttest) { }
        private string _expectedTitleofDemoQAPage = "ToolsQA";
        public void OpenURL_HomePage()
        {
            test.Log(Status.Info, "Navigating to URL of demoQA home page");
            //ChromeDriver.Navigate().GoToUrl("https://demoqa.com/elements");
            OpenURL("https://demoqa.com/elements");
        }

        public bool ConfirmTitleofDemoQAPage()
        {
            test.Log(Status.Info, "Check if Title matches with actual title of DemoQAPage");
            return ChromeDriver.Title.Equals(_expectedTitleofDemoQAPage);
        }

    }
}

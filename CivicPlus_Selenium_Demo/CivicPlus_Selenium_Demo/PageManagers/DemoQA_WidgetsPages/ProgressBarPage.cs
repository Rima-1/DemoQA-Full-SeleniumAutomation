using AventStack.ExtentReports;

using OpenQA.Selenium;

using System;

using System.Threading;


namespace CivicPlus_Selenium_Demo
{
    public class ProgressBarPage : BaseDriver
    {
        public ProgressBarPage(IWebDriver driver, ExtentTest extenttest) : base(driver, extenttest) { }

        //private By datePickerButton = By.Id("item-2");
        private By startStopButton = By.Id("startStopButton");
        private By resetButton = By.Id("resetButton");






        public void OpenURL_ProgressBarPage()
        {
            test.Log(Status.Info, "Navigating to URL of demoQA Elements Progress Bar page");
            //ChromeDriver.Navigate().GoToUrl("https://demoqa.com/progress-bar");
            OpenURL("https://demoqa.com/progress-bar");
        }

        public void StartProgressCalculation()
        {
            test.Log(Status.Info, "Check if Start Button is clickable & click on it");
            ClickElement(ChromeDriver, startStopButton);
            test.Log(Status.Info, "Start Button is clickable & clicked on it");
        }

        public bool checkForCompleteProgress()
        {
            test.Log(Status.Info, "Check If Progress Is 100%");
            //ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4200);
            Thread.Sleep(10000);
            return ChromeDriver.FindElement(By.XPath("//div[contains(@class, 'progress-bar')]")).
                GetAttribute("aria-valuenow").ToString().Equals("100");
        }

        public void ResetProgressCalculation()
        {
            Thread.Sleep(3000);
            test.Log(Status.Info, "Check if Reset Button is clickable & click on it");
            ClickElement(ChromeDriver, resetButton);
            test.Log(Status.Info, "Reset Button is clickable & clicked on it");
        }

        public bool IsProgressResetted()
        {
            test.Log(Status.Info, "Check If Progress Is 0% Or Resetted");
            ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            //Thread.Sleep(3000);
            return ChromeDriver.FindElement(By.XPath("//div[contains(@class, 'progress-bar')]")).
                GetAttribute("aria-valuenow").ToString().Equals("0");
        }
    }
}

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
    public class AlertsHandlingPage : BaseDriver
    {
        public AlertsHandlingPage(IWebDriver driver, ExtentTest extenttest) : base(driver, extenttest) { }
        private By AlertButton1 = By.Id("alertButton");
        private By AlertButton2 = By.Id("timerAlertButton");
        private By AlertButton3 = By.Id("confirmButton");
        private By acceptOrDismissAlert = By.Id("confirmResult");
        private By AlertButton4 = By.Id("promtButton");
        private By promptAlert = By.Id("promptResult");

        

        public void OpenURL_AlertsHandlingPage()
        {
            test.Log(Status.Info, "Navigating to URL of demoQA Elements Alerts page");
            //ChromeDriver.Navigate().GoToUrl("https://demoqa.com/alerts");
            OpenURL("https://demoqa.com/alerts");
        }

        public bool IsButtonToGetAlertClicked()
        {
            test.Log(Status.Info, "Check if Button to see alert is clickable & click on it");
            ClickElement(ChromeDriver, AlertButton1);
            return true;
        }

        public bool IsAlertWindowOpened()
        {
            test.Log(Status.Info, "Check if correct alert window is opened");
            if (ChromeDriver.SwitchTo().Alert().Text.Contains("You clicked a button"))
                return true;
            else
                return false;
        }
        public void acceptAlert()
        {
            test.Log(Status.Info, "Check if alert is accepted");
            ChromeDriver.SwitchTo().Alert().Accept();
            test.Log(Status.Info, "alert is accepted");
        }
        public void dismissAlert()
        {
            test.Log(Status.Info, "Check if alert is dismissed");
            ChromeDriver.SwitchTo().Alert().Dismiss();
            test.Log(Status.Info, "alert is dismissed");
        }

        public bool IsButtonToGetTimerAlertClicked()
        {
            test.Log(Status.Info, "Check if Button to see Timer alert is clickable & click on it");
            ClickElement(ChromeDriver, AlertButton2);
            return true;
        }

        public bool IsTimerAlertWindowOpened()
        {
            test.Log(Status.Info, "Check if correct Timer alert window is opened");
            Thread.Sleep(5000);
            if (ChromeDriver.SwitchTo().Alert().Text.Contains("This alert appeared after 5 seconds"))
                return true;
            else
                return false;
        }

        public bool IsButtonToGetAcceptDismissAlertClicked()
        {
            test.Log(Status.Info, "Check if Button to see Accept/Dismiss alert is clickable & click on it");
            ClickElement(ChromeDriver, AlertButton3);
            return true;
        }

        public bool IsAcceptDismissAlertWindowOpened()
        {
            test.Log(Status.Info, "Check if correct Accept/Dismiss alert window is opened");
            Thread.Sleep(5000);
            if (ChromeDriver.SwitchTo().Alert().Text.Contains("Do you confirm action?"))
                return true;
            else
                return false;
        }

        public bool IsAlertAccepted()
        {
            return ChromeDriver.FindElement(acceptOrDismissAlert).Text.Contains("Ok");
        }
        public bool IsAlertDismissed()
        {
            return ChromeDriver.FindElement(acceptOrDismissAlert).Text.Contains("Cancel");
        }

        public bool IsButtonToGetPromptAlertClicked()
        {
            test.Log(Status.Info, "Check if Button to see Prompt alert is clickable & click on it");
            ScrollElementIntoViewJSVersion(ChromeDriver, AlertButton4);
            ClickElement(ChromeDriver, AlertButton4);
            return true;
        }

        public bool IsPromptAlertWindowOpened()
        {
            test.Log(Status.Info, "Check if correct Prompt alert window is opened");
            Thread.Sleep(5000);
            if (ChromeDriver.SwitchTo().Alert().Text.Contains("Please enter your name"))
                return true;
            else
                return false;
        }

        public void enterTextInPromptAlert()
        {
            test.Log(Status.Info, "Check if text can be entered in Prompt alert window and enter text");
            // Switch the control of 'driver' to the Alert from main window
            IAlert promptAlertText = ChromeDriver.SwitchTo().Alert();
            // '.SendKeys()' to enter the text in to the textbox of alert
            promptAlertText.SendKeys("Mix Sahaphap Wongratch");
        }
        public bool IsPromptAlertAccepted()
        {
            string screenshotPath = ScreenshotTaker.Capture(ChromeDriver, "ConfirmAlerts");
            test.AddScreenCaptureFromPath(screenshotPath);
            return ChromeDriver.FindElement(promptAlert).Text.Contains("Mix Sahaphap Wongratch");
        }

        
    }
}

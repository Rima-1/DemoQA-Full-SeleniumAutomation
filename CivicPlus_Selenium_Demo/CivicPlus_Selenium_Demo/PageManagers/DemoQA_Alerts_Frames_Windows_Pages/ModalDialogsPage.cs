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
    public class ModalDialogsPage : BaseDriver
    {
        public ModalDialogsPage(IWebDriver driver, ExtentTest extenttest) : base(driver, extenttest) { }

        private By smallModalButton = By.Id("showSmallModal");
        private By largeModalButton = By.Id("showLargeModal");
        private By closeSmallModalButton = By.Id("closeSmallModal");
        private By closeLargeModalButton = By.Id("closeLargeModal");

        public void OpenURL_ModalDialogsPage()
        {
            test.Log(Status.Info, "Navigating to URL of demoQA Elements Modal Dialogs page");
            //ChromeDriver.Navigate().GoToUrl("https://demoqa.com/modal-dialogs");
            OpenURL("https://demoqa.com/modal-dialogs");
        }

        public void HitSmallModalButton()
        {
            test.Log(Status.Info, "Check if Small Modal Button is clickable & click on it");
            ClickElement(ChromeDriver, smallModalButton);
            test.Log(Status.Info, "Small Modal Button is clickable & clicked");
        }

        public bool IsLandedOnSmallModalDialog()
        {
            test.Log(Status.Info, "Check if Landed On Small Modal Dialog");
            return ChromeDriver.FindElement(By.Id("example-modal-sizes-title-sm")).Text.Contains("Small Modal");
        }

        public void HitCloseSmallModalButton()
        {
            test.Log(Status.Info, "Check if Small Modal Close Button is clickable & click on it");
            ClickElement(ChromeDriver, closeSmallModalButton);
            test.Log(Status.Info, "Small Modal Close Button is clickable & clicked");
        }

        public void HitLargeModalButton()
        {
            test.Log(Status.Info, "Check if Large Modal Button is clickable & click on it");
            ClickElement(ChromeDriver, largeModalButton);
            test.Log(Status.Info, "Large Modal Button is clickable & clicked");
        }

        public bool IsLandedOnLargeModalDialog()
        {
            test.Log(Status.Info, "Check if Landed On Large Modal Dialog");
            Thread.Sleep(3000);
            return ChromeDriver.FindElement(By.Id("example-modal-sizes-title-lg")).Text.Contains("Large Modal");
        }

        public void HitCloseLargeModalButton()
        {
            test.Log(Status.Info, "Check if Large Modal Close Button is clickable & click on it");
            ClickElement(ChromeDriver, closeLargeModalButton);
            test.Log(Status.Info, "Large Modal Close Button is clickable & clicked");
        }

        public bool IsLandedOnDefaultContentPage()
        {
            test.Log(Status.Info, "Check if Landed On Default Content Page");
            return ChromeDriver.FindElement(By.XPath("//*[contains(text(), 'Click on button to see modal')]")).Text.Contains("Click on button to see modal");
        }
    }
}

using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace CivicPlus_Selenium_Demo
{
    [TestClass]
    public class BaseDriver
    {
        protected IWebDriver ChromeDriver;
        protected ExtentTest test;
        public BaseDriver(IWebDriver driver, ExtentTest extenttest)
        {
            this.ChromeDriver = driver;
            this.test = extenttest;
        }

        public void OpenURL(string url) 
        {
            ChromeDriver.Navigate().GoToUrl(url);
        }
        public void WaitToBeVisible(IWebDriver ChromeDriver, int timeSeconds, By checkingElement)
        {
            WebDriverWait wait = new WebDriverWait(ChromeDriver, TimeSpan.FromSeconds(timeSeconds));
            wait.Until(ExpectedConditions.ElementIsVisible(checkingElement));
        }
        public bool IsVisible(IWebDriver ChromeDriver, int timeSeconds, By checkingElement)
        {
            WaitToBeVisible(ChromeDriver, timeSeconds, checkingElement);
            return ChromeDriver.FindElement(checkingElement).Displayed;

        }
        public IWebElement IsClickable(IWebDriver ChromeDriver, By checkingElement, int timeout = 3)
        {
            WebDriverWait wait = new WebDriverWait(ChromeDriver, TimeSpan.FromSeconds(timeout));
            return wait.Until(ExpectedConditions.ElementToBeClickable(checkingElement));
        }
        public void ClickElement(IWebDriver ChromeDriver, By locator)
        {
            IsClickable(ChromeDriver, locator).Click();
        }
        public void DoubleClickElement(IWebDriver ChromeDriver, By locator)
        {
            Actions doubleClickAction = new Actions(ChromeDriver);
            //doubleClickAction.MoveToElement(ChromeDriver.FindElement(locator))
            doubleClickAction.DoubleClick(ChromeDriver.FindElement(locator)).
            Build().Perform();
        }
        public void RightClickElement(IWebDriver ChromeDriver, By locator)
        {
            Actions rightClickAction = new Actions(ChromeDriver);
            //rightClickAction.MoveToElement(ChromeDriver.FindElement(locator)).
            rightClickAction.ContextClick(ChromeDriver.FindElement(locator)).
            Build().Perform();
        }
       
        public void HoverOverElement(IWebDriver ChromeDriver, By locator)
        {
            Actions hover = new Actions(ChromeDriver);
            hover.MoveToElement(ChromeDriver.FindElement(locator)).Perform();
        }
        public void SelectElemntFromdropdown(IWebDriver ChromeDriver, By locator, string searchKey)
        {
            (new SelectElement(ChromeDriver.FindElement(locator))).SelectByText(searchKey);
        }

        public void ScrollElementIntoViewJSVersion(IWebDriver ChromeDriver, By locator)
        {
            IJavaScriptExecutor js1 = (IJavaScriptExecutor)ChromeDriver;
            js1.ExecuteScript("arguments[0].scrollIntoView(true);", ChromeDriver.FindElement(locator)); //move or scroll into view the required button
        }

        public void DragAndDropElement(IWebDriver ChromeDriver, By sourceElement, By targetElement)
        {
            Actions dragAndDropElements = new Actions(ChromeDriver);
            dragAndDropElements.DragAndDrop(ChromeDriver.FindElement(sourceElement), ChromeDriver.FindElement(targetElement)).Perform();
        }

        public void DragAndDropElementByOffset(IWebDriver ChromeDriver, By locator, int x_offset, int y_offset)
        {
            Actions actions = new Actions(ChromeDriver);
            actions.MoveToElement(ChromeDriver.FindElement(locator))
                    .ClickAndHold(ChromeDriver.FindElement(locator))
                    .MoveByOffset(x_offset, y_offset)
                    .Release().Build().Perform();
        }

        public bool IsCheckboxSelected(IWebDriver ChromeDriver, By locator)
        {
            return ChromeDriver.FindElement(locator).Selected;
        }
        public void TextEntered(IWebDriver ChromeDriver, By locator, string searchKey)
        {
            IsVisible(ChromeDriver, 2, locator);
            ChromeDriver.FindElement(locator).SendKeys(searchKey);
        }
        public void SelectRadioButtonFromList(IWebDriver ChromeDriver, By radioButtonListlocator, int radioButtonIndex)
        {
            IList<IWebElement> radioButton = ChromeDriver.FindElements(radioButtonListlocator);
            radioButton.ElementAt(radioButtonIndex).Click(); 
        }
        public static int GetPixelsToMove(IWebElement Slider, decimal Amount, decimal SliderMax, decimal SliderMin)
        {
            int pixels = 0;
            decimal tempPixels = Slider.Size.Width;
            tempPixels = tempPixels / (SliderMax - SliderMin);
            tempPixels = tempPixels * ((Amount + 1) - SliderMin);
            pixels = Convert.ToInt32(tempPixels);
            return pixels;
        }
        public void SliderMove(IWebDriver ChromeDriver, By locator, decimal Amount, decimal SliderMax, decimal SliderMin)
        {
            IWebElement Slider = ChromeDriver.FindElement(locator);
            Actions SliderAction = new Actions(ChromeDriver);
            SliderAction.ClickAndHold(Slider)
                .MoveByOffset((-(int)Slider.Size.Width / 2), 0)
                .MoveByOffset(GetPixelsToMove(Slider, Amount, SliderMax, SliderMin), 0).Release().Perform();
        }

    }
}
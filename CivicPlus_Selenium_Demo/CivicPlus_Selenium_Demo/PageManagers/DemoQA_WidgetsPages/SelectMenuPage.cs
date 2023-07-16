using AventStack.ExtentReports;

using OpenQA.Selenium;

using OpenQA.Selenium.Interactions;

using System;

using System.Threading;


namespace CivicPlus_Selenium_Demo
{
    public class SelectMenuPage : BaseDriver
    {
        public SelectMenuPage(IWebDriver driver, ExtentTest extenttest) : base(driver, extenttest) { }

        //private By datePickerButton = By.Id("item-2");
        




        public void OpenURL_SelectMenuPage()
        {
            test.Log(Status.Info, "Navigating to URL of demoQA Elements Select Menu page");
            //ChromeDriver.Navigate().GoToUrl("https://demoqa.com/select-menu");
            OpenURL("https://demoqa.com/select-menu");
        }

        /*public bool IsLandedOnDatePickerPage()
        {
            test.Log(Status.Info, "Check if AutoComplete Button is visible");
            ScrollElementIntoViewJSVersion(ChromeDriver, datePickerButton);
            return IsVisible(ChromeDriver, 1, datePickerButton);
        }*/
        public bool HandlingSelectValueMenu()
        {
            test.Log(Status.Info, "Check if Select Value Dropdown is correctly handled");
            try
            {
                ClickElement(ChromeDriver, By.XPath("//div[contains(@class, 'css-1hwfws3')]"));
                Thread.Sleep(3000);
                Actions selectfrommenu = new Actions(ChromeDriver);
                selectfrommenu.SendKeys(Keys.ArrowDown).Perform();
                Actions entertomenu = new Actions(ChromeDriver);
                entertomenu.SendKeys(Keys.Enter).Perform();
                return true;
            }
            catch (Exception ex) { return false; }
        }
        public bool HandlingOldStyleSelectMenu()
        {
            test.Log(Status.Info, "Check if Old Style Dropdown is correctly handled");
            try
            {
                SelectElemntFromdropdown(ChromeDriver, By.Id("oldSelectMenu"), "Black");
                return true;
            }
            catch (Exception ex) { return false; }
        }
        public bool HandlingMultipleSelectValueMenu()
        {
            test.Log(Status.Info, "Check if Select Multiple Value Dropdown is correctly handled");
            try
            {
                ScrollElementIntoViewJSVersion(ChromeDriver, By.XPath("(//div[contains(@class, 'css-1hwfws3')])[3]"));
                ClickElement(ChromeDriver, By.XPath("(//div[contains(@class, 'css-1hwfws3')])[3]"));
                Thread.Sleep(3000);
                Actions selectfrommultiplemenu = new Actions(ChromeDriver);
                selectfrommultiplemenu.SendKeys(Keys.ArrowDown).Perform();
                Actions entertomultiplemenu = new Actions(ChromeDriver);
                entertomultiplemenu.SendKeys(Keys.Enter).Perform();

                Actions selectfrommultiplemenu1 = new Actions(ChromeDriver);
                selectfrommultiplemenu1.SendKeys(Keys.ArrowDown).Perform();
                Actions entertomultiplemenu1 = new Actions(ChromeDriver);
                entertomultiplemenu1.SendKeys(Keys.Enter).Perform();

                ClickElement(ChromeDriver, By.XPath("(//div[contains(@class, 'css-1hwfws3')])[3]"));
                return true;
            }
            catch(Exception ex) { return false; }
        }
    }
}

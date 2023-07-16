using AventStack.ExtentReports;

using OpenQA.Selenium;

using System;

using System.Threading;


namespace CivicPlus_Selenium_Demo
{
    public class DatePickerPage : BaseDriver
    {
        public DatePickerPage(IWebDriver driver, ExtentTest extenttest) : base(driver, extenttest) { }

        //private By datePickerButton = By.Id("item-2");
        private By datePickerInput = By.Id("datePickerMonthYearInput");
        private By datetimePickerInput = By.Id("dateAndTimePickerInput");
        private By monthComboPicker = By.ClassName("react-datepicker__month-select");
        private By yearComboPicker = By.ClassName("react-datepicker__year-select");
        private By dateComboPicker = By.XPath("//div[contains(@class, 'react-datepicker__day--014')]");




        public void OpenURL_DatePickerPage()
        {
            test.Log(Status.Info, "Navigating to URL of demoQA Elements Date Picker page");
            //ChromeDriver.Navigate().GoToUrl("https://demoqa.com/date-picker");
            OpenURL("https://demoqa.com/date-picker");
        }

        /*public bool IsLandedOnDatePickerPage()
        {
            test.Log(Status.Info, "Check if AutoComplete Button is visible");
            ScrollElementIntoViewJSVersion(ChromeDriver, datePickerButton);
            return IsVisible(ChromeDriver, 1, datePickerButton);
        }*/

        public bool EnterDate()
        {
            test.Log(Status.Info, "Check if Date can be entered from the Calender Popup");
            try
            {
                //ChromeDriver.FindElement(datePickerInput).Click();
                ClickElement(ChromeDriver, datePickerInput);
                /*SelectElement monthCombo = new SelectElement(ChromeDriver.FindElement(By.ClassName("react-datepicker__month-select")));
                monthCombo.SelectByText("April");*/
                SelectElemntFromdropdown(ChromeDriver, monthComboPicker, "April");

                /*SelectElement yearCombo = new SelectElement(ChromeDriver.FindElement(By.ClassName("react-datepicker__year-select")));
                yearCombo.SelectByText("1999");*/
                SelectElemntFromdropdown(ChromeDriver, yearComboPicker, "1999");
                ScrollElementIntoViewJSVersion(ChromeDriver, dateComboPicker);
                //ChromeDriver.FindElement(By.XPath("//div[contains(@class, 'react-datepicker__day--014')]")).Click();
                ClickElement(ChromeDriver, dateComboPicker);
                Thread.Sleep(3000);
                return true;
            }
            catch(Exception ex) { return false; }
        }

        public bool EnterDateAndTime()
        {
            test.Log(Status.Info, "Check if Date and Time can be entered from the Calender Popup");
            try
            {
                ChromeDriver.FindElement(datetimePickerInput).Click();
                ChromeDriver.FindElement(datetimePickerInput).SendKeys(Keys.Control + "a");
                ChromeDriver.FindElement(datetimePickerInput).SendKeys(Keys.Delete);
                ChromeDriver.FindElement(datetimePickerInput).SendKeys("April 14, 1999 8:15 PM");
                ChromeDriver.FindElement(datetimePickerInput).SendKeys(Keys.Enter);
                return true;
            }
            catch (Exception ex) { return false; }
        }

    }
}

using AventStack.ExtentReports;

using OpenQA.Selenium;

using System.Threading;


namespace CivicPlus_Selenium_Demo
{
    public class AutoCompletePage : BaseDriver
    {
        public AutoCompletePage(IWebDriver driver, ExtentTest extenttest) : base(driver, extenttest) { }

        private By autoCompleteButton = By.Id("item-1");
        //private By enterColourTextbox = By.XPath("(//*[text()='Type single color name']/parent::div//div)[3]");
        private By enterColourTextbox = By.XPath("input[@id = 'autoCompleteSingleInput']");



        public void OpenURL_AutoCompletePage()
        {
            test.Log(Status.Info, "Navigating to URL of demoQA Elements Auto Complete page");
            //ChromeDriver.Navigate().GoToUrl("https://demoqa.com/auto-complete");
            OpenURL("https://demoqa.com/auto-complete");
        }

        public bool IsLandedOnAutocompletePage()
        {
            test.Log(Status.Info, "Check if AutoComplete Button is visible");
            return IsVisible(ChromeDriver, 1, autoCompleteButton);
        }

        public void EnterSingleColourName()
        {
            ClickElement(ChromeDriver, enterColourTextbox);
            Thread.Sleep(5000);
            TextEntered(ChromeDriver, enterColourTextbox, "Blue");
            ChromeDriver.FindElement(enterColourTextbox).SendKeys(Keys.Enter);
        }

    }
}

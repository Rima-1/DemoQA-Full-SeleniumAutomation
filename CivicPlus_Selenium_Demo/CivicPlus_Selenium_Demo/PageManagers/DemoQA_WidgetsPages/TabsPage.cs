using AventStack.ExtentReports;

using OpenQA.Selenium;


namespace CivicPlus_Selenium_Demo
{
    public class TabsPage : BaseDriver
    {
        public TabsPage(IWebDriver driver, ExtentTest extenttest) : base(driver, extenttest) { }

        //private By datePickerButton = By.Id("item-2");
        private By whatTab = By.Id("demo-tab-what");
        private By contentsOfWhatTab = By.Id("demo-tabpane-what");
        private By originTab = By.Id("demo-tab-origin");
        private By contentsOfOriginTab = By.Id("demo-tabpane-origin");
        private By useTab = By.Id("demo-tab-use");
        private By contentsOfUseTab = By.Id("demo-tabpane-use");






        public void OpenURL_TabsPage()
        {
            test.Log(Status.Info, "Navigating to URL of demoQA Elements Tab page");
            //ChromeDriver.Navigate().GoToUrl("https://demoqa.com/tabs");
            OpenURL("https://demoqa.com/tabs");
        }

        public bool IsWhatTabOpened()
        {
            test.Log(Status.Info, "Check if Landed on What Tab succesfully & it's text matches correctly");
            ClickElement(ChromeDriver, whatTab);
            return ChromeDriver.FindElement(whatTab).Text.Equals("What") && 
                ChromeDriver.FindElement(contentsOfWhatTab).Text.Contains("Lorem Ipsum is simply dummy text");
        }

        public bool IsOriginTabOpened()
        {
            test.Log(Status.Info, "Check if Landed on Origin Tab succesfully & it's text matches correctly");
            ClickElement(ChromeDriver, originTab);
            return ChromeDriver.FindElement(originTab).Text.Equals("Origin") &&
                ChromeDriver.FindElement(contentsOfOriginTab).Text.Contains("Hampden-Sydney College in Virginia");
        }

        public bool IsUseTabOpened()
        {
            test.Log(Status.Info, "Check if Landed on Use Tab succesfully & it's text matches correctly");
            ClickElement(ChromeDriver, useTab);
            return ChromeDriver.FindElement(useTab).Text.Equals("Use") &&
                ChromeDriver.FindElement(contentsOfUseTab).Text.Contains("has a more-or-less normal distribution of letters");
        }


    }
}

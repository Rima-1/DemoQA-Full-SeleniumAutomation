using AventStack.ExtentReports;

using OpenQA.Selenium;


namespace CivicPlus_Selenium_Demo
{
    public class NewDynamicLinkHomeTabPage : BaseDriver
    {
        public NewDynamicLinkHomeTabPage(IWebDriver driver, ExtentTest extenttest) : base(driver, extenttest) { }
        private By dynamicLinkElement1 = By.ClassName("card-up");


        public bool IsElementInNewTabPage()
        {
            return IsVisible(ChromeDriver, 1, dynamicLinkElement1);
        }



    }
}

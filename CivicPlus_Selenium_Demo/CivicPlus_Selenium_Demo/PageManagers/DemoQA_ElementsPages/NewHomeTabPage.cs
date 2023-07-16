using AventStack.ExtentReports;

using OpenQA.Selenium;


namespace CivicPlus_Selenium_Demo
{
    public class NewHomeTabPage : BaseDriver
    {
        public NewHomeTabPage(IWebDriver driver, ExtentTest extenttest) : base(driver, extenttest) { }
        private By Element1 = By.ClassName("card-up");


        public bool IsElementInNewTabPage()
        {
            return IsVisible(ChromeDriver,1, Element1);
        }



    }
}

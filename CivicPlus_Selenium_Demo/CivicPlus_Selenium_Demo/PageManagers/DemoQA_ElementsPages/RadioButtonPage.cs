using AventStack.ExtentReports;

using OpenQA.Selenium;


namespace CivicPlus_Selenium_Demo
{
    public class RadioButtonPage : BaseDriver
    {
        public RadioButtonPage(IWebDriver driver, ExtentTest extenttest) : base(driver, extenttest) { }
        
        private By radioButton = By.Id("item-2");
        private By radioButtonList = By.ClassName("custom-control-label");

        public void OpenURL_RadioButtonPage()
        {
            test.Log(Status.Info, "Navigating to URL of demoQA Elements Radio Button page");
            //ChromeDriver.Navigate().GoToUrl("https://demoqa.com/radio-button");
            OpenURL("https://demoqa.com/radio-button");
        }

        public bool IsLandedOnRadioButtonPage()
        {
            test.Log(Status.Info, "Check if Radio Button is visible");
            return IsVisible(ChromeDriver, 1, radioButton);
        }

        public bool IsYesRadioButtonClicked()
        {
            test.Log(Status.Info, "Check if Yes Radio Button is clicked");
            /*IList<IWebElement> radioButton = ChromeDriver.FindElements(By.ClassName("custom-control-label"));
            radioButton.ElementAt(0).Click(); //To click first radio button*/
            SelectRadioButtonFromList(ChromeDriver, radioButtonList, 0);//To click first radio button
            if (ChromeDriver.FindElement(By.XPath("//span[@class = 'text-success']")).Text.Equals("Yes"))
                return true;
            else
                return false;
        }

        public bool IsImpressiveRadioButtonClicked()
        {
            test.Log(Status.Info, "Check if Impressive Radio Button is clicked");
            /*IList<IWebElement> radioButton = ChromeDriver.FindElements(By.ClassName("custom-control-label"));
            radioButton.ElementAt(1).Click(); //To click second radio button*/
            SelectRadioButtonFromList(ChromeDriver, radioButtonList, 1);//To click second radio button
            if (ChromeDriver.FindElement(By.XPath("//span[@class = 'text-success']")).Text.Equals("Impressive"))
                return true;
            else
                return false;
        }

    }
}

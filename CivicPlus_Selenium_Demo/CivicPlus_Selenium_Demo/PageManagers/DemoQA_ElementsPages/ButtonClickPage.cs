using AventStack.ExtentReports;

using OpenQA.Selenium;


namespace CivicPlus_Selenium_Demo
{
    public class ButtonClickPage : BaseDriver
    {
        public ButtonClickPage(IWebDriver driver, ExtentTest extenttest) : base(driver, extenttest) { }

        private By clickButtons = By.Id("item-4");
        private By doubleClickMeButton = By.Id("doubleClickBtn");
        private By rightClickMeButton = By.Id("rightClickBtn");
        private By clickMeButton = By.XPath("//button[text()='Click Me']");
        private By doubleClickSuccessMessage = By.Id("doubleClickMessage");
        private By rightClickSuccessMessage = By.Id("rightClickMessage");
        private By dynamicClickSuccessMessage = By.Id("dynamicClickMessage");


        public void OpenURL_ButtonClicksPage()
        {
            test.Log(Status.Info, "Navigating to URL of demoQA Elements Buttons page");
            //ChromeDriver.Navigate().GoToUrl("https://demoqa.com/buttons");
            OpenURL("https://demoqa.com/buttons");
        }

        public bool IsLandedOnButtonPage()
        {
            test.Log(Status.Info, "Check if Buttons is visible");
            return IsVisible(ChromeDriver, 1, clickButtons);
        }

        public bool IsDoubleClickSuccess()
        {
            test.Log(Status.Info, "Check if Double Click button is clickable & double click on it");
            DoubleClickElement(ChromeDriver, doubleClickMeButton);
            return ChromeDriver.FindElement(doubleClickSuccessMessage).Text.Equals("You have done a double click");
        }

        public bool IsRightClickSuccess()
        {
            test.Log(Status.Info, "Check if Right Click button is clickable & right click on it");
            RightClickElement(ChromeDriver, rightClickMeButton);
            return ChromeDriver.FindElement(rightClickSuccessMessage).Text.Equals("You have done a right click");
        }

        public bool IsDynamicClickSuccess()
        {
            test.Log(Status.Info, "Check if Dynamic Click button is clickable & click on it");
            ClickElement(ChromeDriver, clickMeButton); //having dynamic/changing locator each time page loads
            return ChromeDriver.FindElement(dynamicClickSuccessMessage).Text.Equals("You have done a dynamic click");
        }



    }
}

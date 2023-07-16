using AventStack.ExtentReports;

using OpenQA.Selenium;


namespace CivicPlus_Selenium_Demo
{
    public class CheckBoxPage : BaseDriver
    {
        public CheckBoxPage(IWebDriver driver, ExtentTest extenttest) : base(driver, extenttest) { }
        
        private By checkboxButton = By.Id("item-1");
        private By checkbox = By.ClassName("rct-checkbox");
        private By checkboxCheckedResult = By.Id("result");
        

        public void OpenURL_CheckboxPage()
        {
            test.Log(Status.Info, "Navigating to URL of demoQA Elements Check Box page");
            //ChromeDriver.Navigate().GoToUrl("https://demoqa.com/checkbox");
            OpenURL("https://demoqa.com/checkbox");
        }

        public bool IsLandedOnCheckBoxPage()
        {
            test.Log(Status.Info, "Check if CheckBox Button is visible");
            return IsVisible(ChromeDriver, 1, checkboxButton);
        }

        public bool IsCheckboxUnchecked()
        {
            test.Log(Status.Info, "Check if CheckBox is unchecked");
            return IsCheckboxSelected(ChromeDriver, checkbox);
        }

        public void HitCheckbox()
        {
            test.Log(Status.Info, "Check if CheckBox is clickable & click on it");
            ClickElement(ChromeDriver, checkbox);
            test.Log(Status.Info, "CheckBox is clickable & clicked");
        }

        public bool IsCheckboxChecked()
        {
            test.Log(Status.Info, "Check if CheckBox is checked");
            return IsVisible(ChromeDriver, 5, checkboxCheckedResult);
        }

    }
}

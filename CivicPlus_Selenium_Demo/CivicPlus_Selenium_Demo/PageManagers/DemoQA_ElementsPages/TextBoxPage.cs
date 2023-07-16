using AventStack.ExtentReports;

using OpenQA.Selenium;


namespace CivicPlus_Selenium_Demo
{
    public class TextboxPage : BaseDriver
    {
        public TextboxPage(IWebDriver driver, ExtentTest extenttest) : base(driver, extenttest) { }
        private By textBoxButton = By.Id("item-0");
        private By name = By.Id("userName");
        private By email = By.Id("userEmail");
        private By currentAddress = By.Id("currentAddress");
        private By permanentAddress = By.Id("permanentAddress");
        private By submitButton = By.Id("submit");

        public void OpenURL_TestBoxPage()
        {
            test.Log(Status.Info, "Navigating to URL of demoQA Elements Text Box page");
            //ChromeDriver.Navigate().GoToUrl("https://demoqa.com/text-box");
            OpenURL("https://demoqa.com/text-box");
        }

        public bool IsLandedOnTextBoxPage()
        {
            test.Log(Status.Info, "Check if TextBox Button is visible");
            return IsVisible(ChromeDriver, 1, textBoxButton);
        }

        public void EnterNameInTextBox(string nameToEnter)
        {
            test.Log(Status.Info, "Check if TextBox is clickable & is Name entered correctly ");
            TextEntered(ChromeDriver, name, nameToEnter);
            test.Log(Status.Info, "Correct Name entered in Text Box");
        }

        public void EnterEmailInTextBox(string emailToEnter)
        {
            test.Log(Status.Info, "Check if TextBox is clickable & is Email entered correctly ");
            TextEntered(ChromeDriver, email, emailToEnter);
            test.Log(Status.Info, "Correct Email entered in Text Box");
        }

        public void EnterCurrentAddressInTextBox(string currentAddressToEnter)
        {
            test.Log(Status.Info, "Check if TextBox is clickable & is Current address entered correctly ");
            TextEntered(ChromeDriver, currentAddress, currentAddressToEnter);
            test.Log(Status.Info, "Correct Current Address entered in Text Box");
        }

        public void EnterPermanentAddressInTextBox(string permanentAddressToEnter)
        {
            test.Log(Status.Info, "Check if TextBox is clickable & is Permanent address entered correctly ");
            TextEntered(ChromeDriver, permanentAddress, permanentAddressToEnter);
            test.Log(Status.Info, "Correct Permanent Address entered in Text Box");
        }

        public bool IsFormSubmitted()
        {
            test.Log(Status.Info, "Check if Form is successfully submitted ");
            ChromeDriver.Manage().Window.Maximize();
            ScrollElementIntoViewJSVersion(ChromeDriver, submitButton);
            ClickElement(ChromeDriver, submitButton);
            return true;
        }

    }
}

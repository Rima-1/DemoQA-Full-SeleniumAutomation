using AventStack.ExtentReports;

using OpenQA.Selenium;


namespace CivicPlus_Selenium_Demo
{
    public class WebTablePage : BaseDriver
    {
        public WebTablePage(IWebDriver driver, ExtentTest extenttest) : base(driver, extenttest) { }

        private By webTableButton = By.Id("item-3");
        private By addRecordButton = By.Id("addNewRecordButton");
        private By addFirstName = By.Id("firstName");
        private By addLastName = By.Id("lastName");
        private By addEmail = By.Id("userEmail");
        private By addAge = By.Id("age");
        private By addSalary = By.Id("salary");
        private By addDepartment = By.Id("department");
        private By submitButton = By.Id("submit");
        private By firstNameAddedCell = By.XPath("//*[text()='Phayu']");
        private By lastNameAddedCell = By.XPath("//*[text()='Chaikamon']");



        public void OpenURL_WebTablePage()
        {
            test.Log(Status.Info, "Navigating to URL of demoQA Elements Web tables page");
            //ChromeDriver.Navigate().GoToUrl("https://demoqa.com/webtables");
            OpenURL("https://demoqa.com/webtables");
        }

        public bool IsLandedOnWebtablePage()
        {
            test.Log(Status.Info, "Check if WebTable Button is visible");
            return IsVisible(ChromeDriver, 1, webTableButton);
        }

        public void HitAddButton()
        {
            test.Log(Status.Info, "Check if Add Button is clickable & click on it");
            ClickElement(ChromeDriver, addRecordButton);
            test.Log(Status.Info, "Add Button is clickable & clicked on it");
        }

        public void AddDetails()
        {
            test.Log(Status.Info, "Check if Text Boxes for entering details are clickable & enter details");
            TextEntered(ChromeDriver, addFirstName, "Phayu");
            TextEntered(ChromeDriver, addLastName, "Chaikamon");
            TextEntered(ChromeDriver, addEmail, "phi.phayu1998@gmail.com");
            TextEntered(ChromeDriver, addAge, "24");
            TextEntered(ChromeDriver, addSalary, "30000");
            TextEntered(ChromeDriver, addDepartment, "MarCom");
            test.Log(Status.Info, "All details entered in respective textboxes");
        }

        public void HitSubmitButton()
        {
            test.Log(Status.Info, "Check if Submit Button is clickable & click on it");
            ClickElement(ChromeDriver, submitButton);
            test.Log(Status.Info, "Submit Button is clickable & clicked on it");
        }

        public bool IsCorrectDetailsAdded()
        {
            test.Log(Status.Info, "Check if details are correctly entered");
            ScrollElementIntoViewJSVersion(ChromeDriver, firstNameAddedCell);
            return ChromeDriver.FindElement(firstNameAddedCell).Text.Equals("Phayu") && 
                ChromeDriver.FindElement(lastNameAddedCell).Text.Equals("Chaikamon");
        }

        

    }
}

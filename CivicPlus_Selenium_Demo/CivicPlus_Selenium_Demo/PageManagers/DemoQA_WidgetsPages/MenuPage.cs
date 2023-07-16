using AventStack.ExtentReports;

using OpenQA.Selenium;


namespace CivicPlus_Selenium_Demo
{
    public class MenuPage : BaseDriver
    {
        public MenuPage(IWebDriver driver, ExtentTest extenttest) : base(driver, extenttest) { }

        //private By datePickerButton = By.Id("item-2");
        private By mainItem2Link = By.XPath("//a[contains(text(), 'Main Item 2')]");
        private By subItem1Link = By.XPath("(//a[contains(text(), 'Sub Item')])[1]");
        private By subItem2Link = By.XPath("(//a[contains(text(), 'Sub Item')])[2]");
        private By subsubItemListLink = By.XPath("//a[contains(text(), 'SUB SUB LIST »')]");
        private By subsubItem1Link = By.XPath("//a[contains(text(), 'Sub Sub Item 1')]");
        private By subsubItem2Link = By.XPath("//a[contains(text(), 'Sub Sub Item 2')]");




        public void OpenURL_MenuPage()
        {
            test.Log(Status.Info, "Navigating to URL of demoQA Elements Menu page");
            //ChromeDriver.Navigate().GoToUrl("https://demoqa.com/menu");
            OpenURL("https://demoqa.com/menu");
            ChromeDriver.Manage().Window.Maximize();
        }

        public bool IsHoveredOverMainItem2Link()
        {
            test.Log(Status.Info, "Check if hovered over Main Item 2");
            HoverOverElement(ChromeDriver, mainItem2Link);
            return ChromeDriver.FindElement(mainItem2Link).Text.Contains("Main Item 2");
        }

        public bool IsSubItem1LinkClickable()
        {
            test.Log(Status.Info, "Check if sub Item 1 is clickable & click on it");
            try
            {
                ClickElement(ChromeDriver, subItem1Link);
                return true;
            }
            catch { return false; }
        }

        public bool IsSubItem2LinkClickable()
        {
            test.Log(Status.Info, "Check if sub Item 2 is clickable & click on it");
            try
            {
                ClickElement(ChromeDriver, subItem2Link);
                return true;
            }
            catch { return false; }
        }

        public bool IsHoveredOverSubSubItemListLink()
        {
            test.Log(Status.Info, "Check if hovered over SUB SUB LIST");
            HoverOverElement(ChromeDriver, subsubItemListLink);
            return ChromeDriver.FindElement(subsubItemListLink).Text.Contains("SUB SUB LIST »");
        }

        public bool IsSubSubItem1LinkClickable()
        {
            test.Log(Status.Info, "Check if sub sub Item 1 is clickable & click on it");
            
            try
            {
                ClickElement(ChromeDriver, subsubItem1Link);
                return true;
            }
            catch { return false; }
        }

        public bool IsSubSubItem2LinkClickable()
        {
            test.Log(Status.Info, "Check if sub sub Item 2 is clickable & click on it");
            try
            {
                ClickElement(ChromeDriver, subsubItem2Link);
                return true;
            }
            catch { return false; }
        }

    }
}

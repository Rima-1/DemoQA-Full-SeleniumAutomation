using AventStack.ExtentReports;

using OpenQA.Selenium;


namespace CivicPlus_Selenium_Demo
{
    public class ToolTipsPage : BaseDriver
    {
        public ToolTipsPage(IWebDriver driver, ExtentTest extenttest) : base(driver, extenttest) { }

        //private By datePickerButton = By.Id("item-2");
        private By hoverButton = By.Id("toolTipButton");
        private By hoverTextBox = By.Id("toolTipTextField");
        private By contraryLink = By.XPath("//a[contains(text(), 'Contrary')]");
        private By numberLink = By.XPath("//a[contains(text(), '1.10.32')]");




        public void OpenURL_ToolTipsPage()
        {
            test.Log(Status.Info, "Navigating to URL of demoQA Elements Tool Tips page");
            //ChromeDriver.Navigate().GoToUrl("https://demoqa.com/tool-tips");
            OpenURL("https://demoqa.com/tool-tips");
        }

        public bool IsHoveredOverTheButton()
        {
            test.Log(Status.Info, "Check if hovered over the button");
            HoverOverElement(ChromeDriver, hoverButton);
            return ChromeDriver.FindElement(hoverButton).GetAttribute("aria-describedby").ToString().Contains("buttonToolTip");
        }

        public bool IsHoveredOverTheTextBox()
        {
            test.Log(Status.Info, "Check if hovered over the Text Box");
            HoverOverElement(ChromeDriver, hoverTextBox);
            return ChromeDriver.FindElement(hoverTextBox).GetAttribute("aria-describedby").ToString().Contains("textFieldToolTip");
        }

        public bool IsHoveredOverContraryLink()
        {
            test.Log(Status.Info, "Check if hovered over the Contrary Link");
            ScrollElementIntoViewJSVersion(ChromeDriver, contraryLink);
            HoverOverElement(ChromeDriver, contraryLink);
            return ChromeDriver.FindElement(contraryLink).GetAttribute("aria-describedby").ToString().Contains("contraryTexToolTip");
        }

        public bool IsHoveredOverNumberLink()
        {
            test.Log(Status.Info, "Check if hovered over the Number Link");
            ScrollElementIntoViewJSVersion(ChromeDriver, numberLink);
            HoverOverElement(ChromeDriver, numberLink);
            return ChromeDriver.FindElement(numberLink).GetAttribute("aria-describedby").ToString().Contains("sectionToolTip");
        }


    }
}

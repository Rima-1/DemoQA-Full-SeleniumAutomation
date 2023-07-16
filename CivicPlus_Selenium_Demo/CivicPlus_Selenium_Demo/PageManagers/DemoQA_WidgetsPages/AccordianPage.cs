using AventStack.ExtentReports;

using OpenQA.Selenium;


namespace CivicPlus_Selenium_Demo
{
    public class AccordianPage : BaseDriver
    {
        public AccordianPage(IWebDriver driver, ExtentTest extenttest) : base(driver, extenttest) { }

        //private By datePickerButton = By.Id("item-2");
        private By card1 = By.Id("section1Heading");
        private By card1_content = By.Id("section1Content");
        private By card2 = By.Id("section2Heading");
        private By card2_content = By.Id("section2Content");
        private By card3 = By.Id("section3Heading");
        private By card3_content = By.Id("section3Content");





        public void OpenURL_AccordianPage()
        {
            test.Log(Status.Info, "Navigating to URL of demoQA Elements Accordian page");
            //ChromeDriver.Navigate().GoToUrl("https://demoqa.com/accordian");
            OpenURL("https://demoqa.com/accordian");
        }

        public bool IsCard1Expanded()
        {
            test.Log(Status.Info, "Check if Card 1's heading & text after expanding it matches correctly");
            ClickElement(ChromeDriver, card1);
            ClickElement(ChromeDriver, card1);
            return ChromeDriver.FindElement(card1).Text.Contains("What is Lorem Ipsum?") && 
                ChromeDriver.FindElement(card1_content).Text.Contains("Lorem Ipsum is simply dummy text");
        }

        public bool IsCard2Expanded()
        {
            test.Log(Status.Info, "Check if Card 2's heading & text after expanding it matches correctly");
            ScrollElementIntoViewJSVersion(ChromeDriver, card2);
            ClickElement(ChromeDriver, card2);
            return ChromeDriver.FindElement(card2).Text.Contains("Where does it come from?") &&
                ChromeDriver.FindElement(card2_content).Text.Contains("Hampden-Sydney College in Virginia");
        }

        public bool IsCard3Expanded()
        {
            test.Log(Status.Info, "Check if Card 3's heading & text after expanding it matches correctly");
            ClickElement(ChromeDriver, card3);
            return ChromeDriver.FindElement(card3).Text.Contains("Why do we use it?") &&
                ChromeDriver.FindElement(card3_content).Text.Contains("has a more-or-less normal distribution of letters");
        }


    }
}

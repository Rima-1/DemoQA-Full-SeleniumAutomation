using AventStack.ExtentReports;

using OpenQA.Selenium;


namespace CivicPlus_Selenium_Demo
{
    public class SelectablePage : BaseDriver
    {
        public SelectablePage(IWebDriver driver, ExtentTest extenttest) : base(driver, extenttest) { }

        //private By datePickerButton = By.Id("item-2");
        private By listTab = By.Id("demo-tab-list");
        private By gridTab = By.Id("demo-tab-grid");
        private By listElement1 = By.XPath("//li[contains(text(), 'Cras')]");
        private By listElement2 = By.XPath("//li[contains(text(), 'Dapibus')]");
        private By listElement3 = By.XPath("//li[contains(text(), 'Morbi')]");
        private By listElement4 = By.XPath("//li[contains(text(), 'Porta')]");
        private By oneInGrid = By.XPath("//li[contains(text(), 'One')]");
        private By twoInGrid = By.XPath("//li[contains(text(), 'Two')]");
        private By threeInGrid = By.XPath("//li[contains(text(), 'Three')]");
        private By fourInGrid = By.XPath("//li[contains(text(), 'Four')]");
        private By fiveInGrid = By.XPath("//li[contains(text(), 'Five')]");
        private By sixInGrid = By.XPath("//li[contains(text(), 'Six')]");
        private By sevenInGrid = By.XPath("//li[contains(text(), 'Seven')]");
        private By eightInGrid = By.XPath("//li[contains(text(), 'Eight')]");
        private By nineInGrid = By.XPath("//li[contains(text(), 'Nine')]");




        public void OpenURL_SelectablePage()
        {
            test.Log(Status.Info, "Navigating to URL of demoQA Elements Selectable page");
            //ChromeDriver.Navigate().GoToUrl("https://demoqa.com/selectable");
            OpenURL("https://demoqa.com/selectable");
        }



        public void clickOnListTab()
        {
            test.Log(Status.Info, "Check If List tab is clickable & click on it");
            ClickElement(ChromeDriver, listTab);
            test.Log(Status.Info, "List tab is clickable & clicked on it");
        }
        public bool selectAllElementsInList()
        {
            test.Log(Status.Info, "Check If all Elements are clickable & can be selected in List");
            try
            {
                ScrollElementIntoViewJSVersion(ChromeDriver, listElement4);
                ClickElement(ChromeDriver, listElement1);
                ClickElement(ChromeDriver, listElement2);
                ClickElement(ChromeDriver, listElement3);
                ClickElement(ChromeDriver, listElement4);
                return true;
            }
            catch { return false; }

        }

        public void clickOnGridTab()
        {
            test.Log(Status.Info, "Check If Grid tab is clickable & click on it");
            ClickElement(ChromeDriver, gridTab);
            test.Log(Status.Info, "Grid tab is clickable & clicked on it");
        }

        public bool selectAllElementsInGrid()
        {
            test.Log(Status.Info, "Check If all Elements are clickable & can be selected in List");
            try
            {
                ClickElement(ChromeDriver, oneInGrid);
                ClickElement(ChromeDriver, twoInGrid);
                ClickElement(ChromeDriver, threeInGrid);
                ClickElement(ChromeDriver, fourInGrid);
                ClickElement(ChromeDriver, fiveInGrid);
                ClickElement(ChromeDriver, sixInGrid);
                ClickElement(ChromeDriver, sevenInGrid);
                ClickElement(ChromeDriver, eightInGrid);
                ClickElement(ChromeDriver, nineInGrid);
                return true;
            }
            catch { return false; }
        }



    }
}

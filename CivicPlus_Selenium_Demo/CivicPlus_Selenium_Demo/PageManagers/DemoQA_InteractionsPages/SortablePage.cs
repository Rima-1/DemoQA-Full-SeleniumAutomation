using AventStack.ExtentReports;

using OpenQA.Selenium;
using System.Threading;

namespace CivicPlus_Selenium_Demo
{
    public class SortablePage : BaseDriver
    {
        public SortablePage(IWebDriver driver, ExtentTest extenttest) : base(driver, extenttest) { }

        //private By datePickerButton = By.Id("item-2");
        private By listTab = By.Id("demo-tab-list");
        private By gridTab = By.Id("demo-tab-grid");
        private By oneInList = By.XPath("(//div[contains(text(), 'One')])[1]");
        private By twoInList = By.XPath("(//div[contains(text(), 'Two')])[1]");
        private By threeInList = By.XPath("(//div[contains(text(), 'Three')])[1]");
        private By fourInList = By.XPath("(//div[contains(text(), 'Four')])[1]");
        private By fiveInList = By.XPath("(//div[contains(text(), 'Five')])[1]");
        private By sixInList = By.XPath("(//div[contains(text(), 'Six')])[1]");
        private By oneInGrid = By.XPath("(//div[contains(text(), 'One')])[2]");
        private By nineInGrid = By.XPath("//div[contains(text(), 'Nine')]");




        public void OpenURL_SortablePage()
        {
            test.Log(Status.Info, "Navigating to URL of demoQA Elements Sortable page");
            //ChromeDriver.Navigate().GoToUrl("https://demoqa.com/sortable");
            OpenURL("https://demoqa.com/sortable");
        }

        

        public void clickOnListTab()
        {
            test.Log(Status.Info, "Check If List tab is clickable & click on it");
            ClickElement(ChromeDriver, listTab);
            test.Log(Status.Info, "List tab is clickable & clicked on it");
        }
        public bool sortElementsInDescendingOrder()
        {
            test.Log(Status.Info, "Check If Elements are sorted in Descending Order by Drag and Drop");
            try
            {
                ScrollElementIntoViewJSVersion(ChromeDriver, sixInList);
                Thread.Sleep(3000);
                DragAndDropElement(ChromeDriver, oneInList, sixInList);
                Thread.Sleep(3000);
                DragAndDropElement(ChromeDriver, sixInList, twoInList);
                Thread.Sleep(3000);
                DragAndDropElement(ChromeDriver, twoInList, oneInList);
                Thread.Sleep(3000);
                DragAndDropElement(ChromeDriver, threeInList, twoInList);
                Thread.Sleep(3000);
                DragAndDropElement(ChromeDriver, fourInList, threeInList);
                Thread.Sleep(3000);
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

        public bool dragAndDrop1Between8And9InGrid()
        {
            test.Log(Status.Info, "Check If Element named One is dragged and dropped between Elements named Eight & Nine in Grid");
            try
            {
                DragAndDropElement(ChromeDriver, oneInGrid, nineInGrid);
                return true;
            }
            catch { return false; }
        }
        


    }
}

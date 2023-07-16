using AventStack.ExtentReports;

using OpenQA.Selenium;

namespace CivicPlus_Selenium_Demo
{
    public class DraggablePage : BaseDriver
    {
        public DraggablePage(IWebDriver driver, ExtentTest extenttest) : base(driver, extenttest) { }

        //private By datePickerButton = By.Id("item-2");
        private By simpleTab = By.Id("draggableExample-tab-simple");
        private By axisRestrictedTab = By.Id("draggableExample-tab-axisRestriction");
        private By containerRestrictedTab = By.Id("draggableExample-tab-containerRestriction");
        private By cursorStyleTab = By.Id("draggableExample-tab-cursorStyle");
        private By dragBox = By.Id("dragBox");
        private By restrictedX_DragBox = By.Id("restrictedX");
        private By restrictedY_DragBox = By.Id("restrictedY");
        private By containerRestricted_dragBox = By.XPath("(//div[contains(@class, 'draggable ui-widget-content')])[1]");




        public void OpenURL_DraggablePage()
        {
            test.Log(Status.Info, "Navigating to URL of demoQA Elements Draggable page");
            //ChromeDriver.Navigate().GoToUrl("https://demoqa.com/dragabble");
            OpenURL("https://demoqa.com/dragabble");
        }

        public void clickOnSimpleTab()
        {
            test.Log(Status.Info, "Check if Simple Tab is clickable & click on it");
            ClickElement(ChromeDriver, simpleTab);
            test.Log(Status.Info, "Simple Tab is clickable & clicked on it");
        }
        public bool IsDragBoxDropped()
        {
            test.Log(Status.Info, "Check if Draggable Box can be dragged & dropped anywhere");
            try
            {
                ChromeDriver.Manage().Window.Maximize();
                /*Actions actions = new Actions(ChromeDriver);
                actions.MoveToElement(ChromeDriver.FindElement(dragBox))
                        .ClickAndHold(ChromeDriver.FindElement(dragBox))
                        .MoveByOffset(280, 30)
                        .Release().Build().Perform();*/
                DragAndDropElementByOffset(ChromeDriver, dragBox, 280, 30);
                return true;
            }
            catch { return false; }
        }
        public void clickOnAxisRestrictedTab()
        {
            test.Log(Status.Info, "Check if Axis Restricted Tab is clickable & click on it");
            ClickElement(ChromeDriver, axisRestrictedTab);
            test.Log(Status.Info, "Axis Restricted Tab is clickable & clicked on it");
        }
        public bool IsXAxisDragBoxDropped_Test1()
        {
            test.Log(Status.Info, "Check if X-Axis Draggable Box can be dragged & dropped anywhere");
            try
            {

                /*Actions actions = new Actions(ChromeDriver);
                actions.MoveToElement(ChromeDriver.FindElement(restrictedX_DragBox))
                        .ClickAndHold(ChromeDriver.FindElement(restrictedX_DragBox))
                        .MoveByOffset(280, 80)
                        
                        .Release().Build().Perform();*/
                DragAndDropElementByOffset(ChromeDriver, restrictedX_DragBox, 280, 80);

                return true;
            }
            catch { return false; }
        }
        public bool IsXAxisDragBoxDropped_Test2()
        {
            test.Log(Status.Info, "Check if X-Axis Draggable Box can be dragged & dropped only in X-axis");
            try
            {

                /*Actions actions = new Actions(ChromeDriver);
                actions.MoveToElement(ChromeDriver.FindElement(restrictedX_DragBox))
                        .ClickAndHold(ChromeDriver.FindElement(restrictedX_DragBox))
                        .MoveByOffset(80, 0)
                        .Release().Build().Perform();*/
                DragAndDropElementByOffset(ChromeDriver, restrictedX_DragBox, 80, 0);
                return true;
            }
            catch { return false; }
        }
        public bool IsYAxisDragBoxDropped_Test2()
        {
            test.Log(Status.Info, "Check if Y-Axis Draggable Box can be dragged & dropped only in Y-axis");
            try
            {

                /*Actions actions = new Actions(ChromeDriver);
                actions.MoveToElement(ChromeDriver.FindElement(restrictedY_DragBox))
                        .ClickAndHold(ChromeDriver.FindElement(restrictedY_DragBox))
                        .MoveByOffset(0, 80)
                        .Release().Build().Perform();*/
                DragAndDropElementByOffset(ChromeDriver, restrictedY_DragBox, 0, 80);
                return true;
            }
            catch { return false; }
        }
        public void clickOnContainerRestrictedTab()
        {
            test.Log(Status.Info, "Check if Container Restricted Tab is clickable & click on it");
            ClickElement(ChromeDriver, containerRestrictedTab);
            test.Log(Status.Info, "Container Restricted Tab is clickable & clicked on it");
        }
        public bool IsDragBoxDroppedWithinContainer()
        {
            test.Log(Status.Info, "Check if Draggable Box can be dragged & dropped only inside Container");
            try
            {

                /*Actions actions = new Actions(ChromeDriver);
                actions.MoveToElement(ChromeDriver.FindElement(containerRestricted_dragBox))
                        .ClickAndHold(ChromeDriver.FindElement(containerRestricted_dragBox))
                        .MoveByOffset(80, 80)
                        .Release().Build().Perform();*/
                DragAndDropElementByOffset(ChromeDriver, containerRestricted_dragBox, 80, 80);
                return true;
            }
            catch { return false; }
        }
        public void clickOnCursorStyleTab()
        {
            test.Log(Status.Info, "Check if Cursor Style Tab is clickable & click on it");
            ClickElement(ChromeDriver, cursorStyleTab);
            test.Log(Status.Info, "Cursor Style Tab is clickable & clicked on it");
        }
        //what to check in this tab ??


    }
}

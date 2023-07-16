using AventStack.ExtentReports;

using OpenQA.Selenium;

using System;


namespace CivicPlus_Selenium_Demo
{
    public class DroppablePage : BaseDriver
    {
        public DroppablePage(IWebDriver driver, ExtentTest extenttest) : base(driver, extenttest) { }

        //private By datePickerButton = By.Id("item-2");
        private By simpleTab = By.Id("droppableExample-tab-simple");
        private By acceptTab = By.Id("droppableExample-tab-accept");
        private By preventPropagationTab = By.Id("droppableExample-tab-preventPropogation");
        private By revertDraggableTab = By.Id("droppableExample-tab-revertable");
        private By dropHereText = By.XPath("//p[contains(text(), 'Drop here')]");
        private By droppedText = By.XPath("//p[contains(text(), 'Dropped!')]");
        private By draggableBox = By.Id("draggable");
        private By droppableBox = By.Id("droppable");
        private By acceptableBox = By.XPath("(//div[contains(text(), 'Acceptable')])[1]");
        private By notAcceptableBox = By.XPath("(//div[contains(text(), 'Acceptable')])[2]");
        private By notGreedyDropBox = By.Id("notGreedyDropBox");
        private By notGreedyInnerDropBox = By.Id("notGreedyInnerDropBox");
        private By greedyDropBox = By.Id("greedyDropBox");
        private By greedyDropBoxInner = By.Id("greedyDropBoxInner");
        private By dragBox = By.Id("dragBox");
        private By revertableBox = By.Id("revertable");
        private By notRevertableBox = By.Id("notRevertable");





        public void OpenURL_DroppablePage()
        {
            test.Log(Status.Info, "Navigating to URL of demoQA Elements Droppable page");
            //ChromeDriver.Navigate().GoToUrl("https://demoqa.com/droppable");
            OpenURL("https://demoqa.com/droppable");
        }

        public void clickOnSimpleTab()
        {
            test.Log(Status.Info, "Check if Simple Tab is clickable & click on it");
            ClickElement(ChromeDriver, simpleTab);
            test.Log(Status.Info, "Simple Tab is clickable & clicked on it");
        }

        public bool IsDroppableBoxTextIsDropHere()
        {
            test.Log(Status.Info, "Check If Before Drag & Drop Action Performed, The Text in Droppable Box is Drop Here");
            ScrollElementIntoViewJSVersion(ChromeDriver, droppableBox);
            return ChromeDriver.FindElement(dropHereText).Text.Equals("Drop here");
        }
        public bool IsDragAndDropDoneInSimpleTab()
        {
            test.Log(Status.Info, "Check If Drag & Drop Action is Performed, & The Text in Droppable Box changed to Dropped!");
            try
            {
                DragAndDropElement(ChromeDriver, draggableBox, droppableBox);
                return ChromeDriver.FindElement(droppedText).Text.Equals("Dropped!");
            }
            catch { return false; }
        }

        public void clickOnAcceptTab()
        {
            test.Log(Status.Info, "Check if Accept Tab is clickable & click on it");
            ClickElement(ChromeDriver, acceptTab);
            ChromeDriver.Manage().Window.Maximize();
            test.Log(Status.Info, "Accept Tab is clickable & clicked on it");
        }

        public bool IsTextChangedOnDrppingNotAcceptableBox()
        {
            test.Log(Status.Info, "Check If Drag & Drop Action is Performed for Not Acceptable Box, & The Text in Droppable Box is Drop Here");
            try
            {

                /*Actions actions = new Actions(ChromeDriver);
                actions.MoveToElement(ChromeDriver.FindElement(notAcceptableBox))
                        .ClickAndHold(ChromeDriver.FindElement(notAcceptableBox))
                        .MoveByOffset(280, 30)
                        .Release().Build().Perform();*/
                DragAndDropElementByOffset(ChromeDriver, notAcceptableBox, 280, 30);

                return ChromeDriver.FindElement(By.XPath("(//div[@id='droppable']/p)[2]")).Text.Equals("Drop here");
            }
            catch { return false; }
        }

        public bool IsTextChangedOnDrppingAcceptableBox()
        {
            test.Log(Status.Info, "Check If Drag & Drop Action is Performed for Acceptable Box, & The Text in Droppable Box changed to Dropped");
            try
            {

                /*Actions actions = new Actions(ChromeDriver);
                actions.MoveToElement(ChromeDriver.FindElement(acceptableBox))
                        .ClickAndHold(ChromeDriver.FindElement(acceptableBox))
                        .MoveByOffset(280, 50)
                        .Release().Build().Perform();*/
                DragAndDropElementByOffset(ChromeDriver, acceptableBox, 280, 50);
                //WaitToBeVisible(ChromeDriver, 3, droppedText);
                //Console.WriteLine(ChromeDriver.FindElement(dropHereText).Text);
                //Console.WriteLine(IsVisible(ChromeDriver, 3, droppedText));
                //return droppedText.ToString().Contains("Dropped");
                //return ChromeDriver.FindElement(By.XPath("(//div[@id='droppable']/p)[2]")).Text.Equals("Dropped");
                return true;
            }
            catch
            { return false;
                
            }
        }

        public void clickOnPreventPropagationTab()
        {
            test.Log(Status.Info, "Check if Prevent Propagation Tab is clickable & click on it");
            ClickElement(ChromeDriver, preventPropagationTab);
            test.Log(Status.Info, "Prevent Propagation Tab is clickable & clicked on it");

        }

        public bool IsdroppedTo_notGreedyInnerDropBox()
        {
            test.Log(Status.Info, "Check If Drag & Drop Action is Performed for notGreedyInnerDropBox, & The Text in Outer & Inner Droppable Box changed to Dropped");
            try
            {
                DragAndDropElement(ChromeDriver, dragBox, notGreedyInnerDropBox);
                //Thread.Sleep(3000);
                Console.WriteLine(ChromeDriver.FindElement(By.XPath("//div[@id='notGreedyInnerDropBox']/p")).Text);
                return ChromeDriver.FindElement(By.XPath("//div[@id='notGreedyInnerDropBox']/p")).Text.Contains("Dropped")
                    && ChromeDriver.FindElement(By.XPath("//div[@id='notGreedyDropBox']/p")).Text.Contains("Dropped");
                //return true;
            }
            catch { return false; }
        }
        public bool IsdroppedTo_greedyDropBoxInner()
        {
            test.Log(Status.Info, "Check If Drag & Drop Action is Performed for GreedyInnerDropBox, & The Text in Only Inner Droppable Box changed to Dropped");
            try
            {
                ScrollElementIntoViewJSVersion(ChromeDriver, greedyDropBoxInner);
                DragAndDropElement(ChromeDriver, dragBox, greedyDropBoxInner);
                return ChromeDriver.FindElement(By.XPath("//div[@id='greedyDropBoxInner']/p")).Text.Contains("Dropped")
                    && ChromeDriver.FindElement(By.XPath("//div[@id='greedyDropBox']/p")).Text.Contains("Outer droppable");
                //return true;
            }
            catch { return false; }
        }

        
        public void clickOnRevertDraggableTab()
        {
            test.Log(Status.Info, "Check if Revert Draggable Tab is clickable & click on it");
            ClickElement(ChromeDriver, revertDraggableTab);
            test.Log(Status.Info, "Revert Draggable Tab is clickable & clicked on it");

        }
        public bool IsRevertable_NonRevertable_BoxesHandled()
        {
            test.Log(Status.Info, "Check If Drag & Drop Action is Performed for both Revertable & Non-Revertable DropBox, & The Revertable dropbox gets reverted while Non-Revertable is inside the droppable box");
            try
            {
                ScrollElementIntoViewJSVersion(ChromeDriver, By.XPath("(//div[contains(@id, 'droppable')])[8]"));
                DragAndDropElement(ChromeDriver, revertableBox, By.XPath("(//div[contains(@id, 'droppable')])[8]"));
                DragAndDropElement(ChromeDriver, notRevertableBox, By.XPath("(//div[contains(@id, 'droppable')])[8]"));
                return true;
            }
            catch { return false; }
        }
    }
}

using AventStack.ExtentReports;

using OpenQA.Selenium;

namespace CivicPlus_Selenium_Demo
{
    public class ResizablePage : BaseDriver
    {
        public ResizablePage(IWebDriver driver, ExtentTest extenttest) : base(driver, extenttest) { }

        //private By datePickerButton = By.Id("item-2");
        private By resizeableElement = By.XPath("//div[@id='resizableBoxWithRestriction']/span");
        private int xOffset = 200;
        private int yOffset = 100;




        public void OpenURL_ResizablePage()
        {
            test.Log(Status.Info, "Navigating to URL of demoQA Elements Resizable page");
            //ChromeDriver.Navigate().GoToUrl("https://demoqa.com/resizable");
            OpenURL("https://demoqa.com/resizable");
        }

        public bool IsElementResizable()
        {
            test.Log(Status.Info, "Check If Element Is Resizable & resize it");
            try
            {
                /*ScrollElementIntoViewJSVersion(ChromeDriver, resizeableElement);
                Actions act = new Actions(ChromeDriver);
                act.ClickAndHold(ChromeDriver.FindElement(resizeableElement)).
                    MoveByOffset(xOffset, yOffset).Release().Build().Perform();*/
                DragAndDropElementByOffset(ChromeDriver, resizeableElement, xOffset, yOffset);
                return true;
            }
            /*catch (StaleElementReferenceException e)
            {
                System.out.println("Element with " + elementToResize + "is not attached to the page document " + e.getStackTrace());
            }
            catch (NoSuchElementException e)
            {
                System.out.println("Element " + elementToResize + " was not found in DOM " + e.getStackTrace());
            }
            catch (Exception e)
            {
                System.out.println("Unable to resize" + elementToResize + " - " + e.getStackTrace());
            }*/
            catch { return false; }

        
        }




        



    }
}

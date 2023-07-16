using AventStack.ExtentReports;

using OpenQA.Selenium;


namespace CivicPlus_Selenium_Demo
{
    public class SliderPage : BaseDriver
    {
        public SliderPage(IWebDriver driver, ExtentTest extenttest) : base(driver, extenttest) { }

        //private By datePickerButton = By.Id("item-2");
        private By sliderValueTextBox = By.Id("sliderValue");
        private By sliderlocator = By.XPath("//input[contains(@class, 'range-slider')]");






        public void OpenURL_SliderPage()
        {
            test.Log(Status.Info, "Navigating to URL of demoQA Elements Slider page");
            //ChromeDriver.Navigate().GoToUrl("https://demoqa.com/slider");
            OpenURL("https://demoqa.com/slider");
        }

        /*public static int GetPixelsToMove(IWebElement Slider, decimal Amount, decimal SliderMax, decimal SliderMin)
        {
            int pixels = 0;
            decimal tempPixels = Slider.Size.Width;
            tempPixels = tempPixels / (SliderMax - SliderMin);
            tempPixels = tempPixels * ((Amount+1) - SliderMin);
            pixels = Convert.ToInt32(tempPixels);
            return pixels;
        }*/
        public bool SliderTestByMovingSlider()
        {
            test.Log(Status.Info, "Check If value matches in the text box with moving the slider to a specific value");

            /*IWebElement Slider = ChromeDriver.FindElement(By.XPath("//input[contains(@class, 'range-slider')]"));
            Actions SliderAction = new Actions(ChromeDriver);
            SliderAction.ClickAndHold(Slider)
                .MoveByOffset((-(int)Slider.Size.Width / 2), 0)
                .MoveByOffset(GetPixelsToMove(Slider, 40, 100, 0), 0).Release().Perform();*/
            SliderMove(ChromeDriver, sliderlocator, 40, 100, 0);
            
            return ChromeDriver.FindElement(sliderValueTextBox).GetAttribute("value").ToString().Equals("40")
                && ChromeDriver.FindElement(sliderlocator).GetAttribute("value").ToString().Equals("40");
        }


    }
}

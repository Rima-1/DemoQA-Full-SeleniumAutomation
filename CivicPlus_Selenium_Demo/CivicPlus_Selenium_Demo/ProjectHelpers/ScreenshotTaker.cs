using OpenQA.Selenium;
using System;

namespace CivicPlus_Selenium_Demo
{
    public class ScreenshotTaker
    {
        public static string Capture(IWebDriver chromeDriver, string screenshotName)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)chromeDriver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "Screenshots\\" + screenshotName + ".png";
            screenshot.SaveAsFile(reportPath, ScreenshotImageFormat.Png);
            return reportPath;
        }
    }
}

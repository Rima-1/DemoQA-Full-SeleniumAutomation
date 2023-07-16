using AventStack.ExtentReports;
using AventStack.ExtentReports.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Configuration;
using ConfigurationSettings = System.Configuration.ConfigurationManager;

namespace CivicPlus_Selenium_Demo
{
    public class BaseUnitTest
    {
        public IWebDriver ChromeDriver;
        public static string browser = ConfigurationSettings.AppSettings["BrowserName"];
        public static ExtentReports rep;
        [AssemblyInitialize]
        //public static ExtentReports ExtentReportInitialize(TestContext testContext)
        public static ExtentReports ExtentReportInitialize()
        {
            rep = ExtentManager.GetInstance();
            return rep;
        }
        public ExtentTest test;
        [TestInitialize]
        public void InitializeTest()
        {
            switch (browser)
            {
                case "Chrome":
                    ChromeDriver = new ChromeDriver();
                    break;
                case "IE":
                    ChromeDriver = new InternetExplorerDriver();
                    break;
                case "Firefox":
                    ChromeDriver = new FirefoxDriver();
                    break;
            }
            
        }
        [TestCleanup]
        public void EndTest()
        {
            rep.Flush();
            ChromeDriver.Quit();
        }
    }
}

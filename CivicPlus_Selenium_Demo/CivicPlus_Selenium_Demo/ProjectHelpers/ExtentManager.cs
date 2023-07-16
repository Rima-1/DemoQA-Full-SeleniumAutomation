using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Net;

namespace CivicPlus_Selenium_Demo
{
    public class ExtentManager
    {
        private ExtentManager() { }
        public static ExtentHtmlReporter htmlReporter;
        private static ExtentReports extent;
        public static ExtentReports GetInstance()
        {
            if (extent == null)
            {
                string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
                string projectPath = new Uri(actualPath).LocalPath;
                string reportPath = projectPath + "Reports_" + System.DateTime.Today.Date.ToString("ddMMyyyy") + "\\TestRunReport.html";
                htmlReporter = new ExtentHtmlReporter(reportPath);
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
                extent.AddSystemInfo("Operating System : ", Environment.OSVersion.ToString());
                extent.AddSystemInfo("Host Name : ", Dns.GetHostName());
                extent.AddSystemInfo("Browser : ", "Chrome");

            }
            return extent;
        }
    }
}

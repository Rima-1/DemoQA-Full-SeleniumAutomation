using AventStack.ExtentReports;

using OpenQA.Selenium;

using System;

using System.IO;

using System.Threading;


namespace CivicPlus_Selenium_Demo
{
    public class UploadAndDownloadPage : BaseDriver
    {
        public UploadAndDownloadPage(IWebDriver driver, ExtentTest extenttest) : base(driver, extenttest) { }

        private By uploadAndDownloadButton = By.Id("item-7");
        private By uploadFileButton = By.Id("uploadFile");
        private By downloadFileButton = By.Id("downloadButton");


        public void OpenURL_UploadAndDownloadPage()
        {
            test.Log(Status.Info, "Navigating to URL of demoQA Elements Upload and Download page");
            //ChromeDriver.Navigate().GoToUrl("https://demoqa.com/upload-download");
            OpenURL("https://demoqa.com/upload-download");
        }

        public bool IsLandedOnUploadAndDownloadPage()
        {
            test.Log(Status.Info, "Check if Upload and Download Button is visible");
            return IsVisible(ChromeDriver, 1, uploadAndDownloadButton);
        }

        public bool IsFileUploaded(string filePath, string correctFileName)
        {
            test.Log(Status.Info, "Check if Correct file is uploaded");
            try
            {
                //Shift+rightclick on the file you want to copy pathof
                string mainfilePath = @filePath;
                TextEntered(ChromeDriver, uploadFileButton, mainfilePath);
                return Path.GetFileName(filePath).Equals(correctFileName); //checking if correct file is uploaded
            }
            catch { return false; }
        }

        public bool IsFileDownloaded()
        {
            test.Log(Status.Info, "Check if Correct file is downloaded");
            try
            {
                string filename = "sampleFile.jpeg";
                ClickElement(ChromeDriver, downloadFileButton);
                Thread.Sleep(7000);
                //"C:\Users\Rima.Panja\Downloads\sampleFile.jpeg"
                //This code verifies if the file is downloaded and then deletes it.
                bool exist = false;
                string Path = "C://Users//Rima.Panja//Downloads";
                string[] filePaths = Directory.GetFiles(Path);
                foreach (string p in filePaths)
                {
                    if (p.Contains(filename))
                    {
                        FileInfo thisFile = new FileInfo(p);
                        //Check the file that are downloaded in the last 3 minutes
                        if (thisFile.LastWriteTime.ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                        thisFile.LastWriteTime.AddMinutes(1).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                        thisFile.LastWriteTime.AddMinutes(2).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                        thisFile.LastWriteTime.AddMinutes(3).ToShortTimeString() == DateTime.Now.ToShortTimeString())
                            exist = true;
                        File.Delete(p);
                        break;
                    }
                }
                return exist;
            }
            catch { return false; }
        }

    }
}

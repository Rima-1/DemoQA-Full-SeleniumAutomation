using AventStack.ExtentReports;

using OpenQA.Selenium;

using System;

using System.Net;


namespace CivicPlus_Selenium_Demo
{
    public class BrokenImagesLinksPage : BaseDriver
    {
        public BrokenImagesLinksPage(IWebDriver driver, ExtentTest extenttest) : base(driver, extenttest) { }

        private By brokenimageslinksButton = By.Id("item-6");
        public void OpenURL_BrokenImagesLinksPage()
        {
            test.Log(Status.Info, "Navigating to URL of demoQA Elements Broken Images Links page");
            //ChromeDriver.Navigate().GoToUrl("https://demoqa.com/broken");
            OpenURL("https://demoqa.com/broken");
        }

        public bool IsLandedOnLinksPage()
        {
            test.Log(Status.Info, "Check if Broken Images Links Button is visible");
            return IsVisible(ChromeDriver, 1, brokenimageslinksButton);
        }

        public bool checkForBrokenImages()
        {
            test.Log(Status.Info, "Check if 2 Broken Images are present in the whole page");
            int brokenImagesCount = 0;
            foreach (WebElement image in ChromeDriver.FindElements(By.CssSelector("img")))
            {
                if (image.GetAttribute("naturalWidth").Equals("0"))
                {
                    brokenImagesCount++;
                }
                else
                    brokenImagesCount = 0;
            }
            return brokenImagesCount.ToString().Equals("2");
        }

        /*public int CheckForBrokenLinks()
        {
            ScrollElementIntoViewJSVersion(ChromeDriver, By.XPath("//a[contains(text(), 'Broken Link')]"));
            int brokenlinks = 0;
            IList<IWebElement> links = ChromeDriver.FindElements(By.XPath("//a[contains(text(), 'Broken Link')]"));
            foreach (IWebElement link in links)
            {
                //var name = link.Text; //To get the link name
                var Response = IsLinkWorking(link);
                if (Response)
                {
                    //Console.WriteLine("\r\nResponse Status Code is OK for " + name);
                    brokenlinks++;
                }
                else
                {
                    //Console.WriteLine("\r\nLink is broken for " + name);
                    brokenlinks=0;
                }
            }
            //return brokenlinks.ToString().Equals("1");
            return brokenlinks;
        }

        public bool IsLinkWorking(IWebElement link)
        {
            var url = link.GetAttribute("href");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            //request.AllowAutoRedirect = true;

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }*/

        /*public int brokenLinks()
        {
            int brokenLinksCount = 0;
            //IList<IWebElement> links = ChromeDriver.FindElements(By.XPath("//a[contains(text(), 'Broken Link')]"));
            //foreach (IWebElement link in links)
            //{
            //var url = link.GetAttribute("href");
            var url = "http://the-internet.herokuapp.com/status_codes/500";
                if (IsLinkWorking(url) == true)
                    brokenLinksCount = 0;
                else
                    brokenLinksCount++;
            //}
            return brokenLinksCount;
        }
        bool IsLinkWorking(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);

            //You can set some parameters in the "request" object...
            request.AllowAutoRedirect = true;

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    
                  // Releases the resources of the response.
            response.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            { //TODO: Check for the right exception here
                return false;
            }
        }*/
        public void brokenLinksTest()
        {
            HttpWebRequest req = null;
            var urls = ChromeDriver.FindElements(By.TagName("a"));
            foreach(var url in urls)
            {
                if(!(url.Text.Contains("Email") || url.Text == ""))
                {
                    req = (HttpWebRequest)WebRequest.Create(url.GetAttribute("href"));
                    try
                    {
                        var response = (HttpWebResponse)req.GetResponse();
                        Console.WriteLine($"URL: {url.GetAttribute("href")} status is :{response.StatusCode}");
                    }
                    catch(WebException e)
                    {
                        var errorResponse = (HttpWebResponse)e.Response;
                        Console.WriteLine($"URL: {url.GetAttribute("href")} status is :{errorResponse.StatusCode}");
                    }
                }
            }
        }
    }
}

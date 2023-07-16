using AventStack.ExtentReports;

using OpenQA.Selenium;


namespace CivicPlus_Selenium_Demo
{
    public class LinksPage : BaseDriver
    {
        public LinksPage(IWebDriver driver, ExtentTest extenttest) : base(driver, extenttest) { }

        private By linksButton = By.Id("item-5");
        private By newHomeTabButton = By.Id("simpleLink");
        private By newDynamicLinkHomeTabButton = By.Id("dynamicLink");
        private By createdApiCallLink = By.Id("created");
        private By noContentApiCallLink = By.Id("no-content");
        private By movedApiCallLink = By.Id("moved");
        private By badRequestApiCallLink = By.Id("bad-request");
        private By unauthorizedApiCallLink = By.Id("unauthorized");
        private By forbiddenApiCallLink = By.Id("forbidden");
        private By invalidUrlApiCallLink = By.Id("invalid-url");
        private By linkResponseMessage = By.Id("linkResponse");


        public void OpenURL_LinksPage()
        {
            test.Log(Status.Info, "Navigating to URL of demoQA Elements Links page");
            //ChromeDriver.Navigate().GoToUrl("https://demoqa.com/links");
            OpenURL("https://demoqa.com/links");
        }

        public bool IsLandedOnLinksPage()
        {
            test.Log(Status.Info, "Check if Links Button is visible");
            return IsVisible(ChromeDriver, 1, linksButton);
        }

        public bool IsNewHomeTabButtonClicked()
        {
            test.Log(Status.Info, "Check if New Home Link is clickable & click on it");
            ClickElement(ChromeDriver, newHomeTabButton);
            return true;
        }
        public bool IsLandedOnNewHomeTabPage()
        {
            test.Log(Status.Info, "Check if Landed on New Home Tab Page");
            ChromeDriver.SwitchTo().Window(ChromeDriver.WindowHandles[1]);
            return new NewHomeTabPage(ChromeDriver, test).IsElementInNewTabPage();
        }

        public bool IsNewDynamicLinkHomeTabButtonClicked()
        {
            test.Log(Status.Info, "Check if Dynamic Home Link is clickable & click on it");
            ChromeDriver.SwitchTo().Window(ChromeDriver.WindowHandles[0]);
            ClickElement(ChromeDriver, newDynamicLinkHomeTabButton);
            return true;
        }
        public bool IsLandedOnNewDynamicLinkHomeTabPage()
        {
            test.Log(Status.Info, "Check if Landed on Dynamic Home Tab Page");
            ChromeDriver.SwitchTo().Window(ChromeDriver.WindowHandles[2]);
            return new NewDynamicLinkHomeTabPage(ChromeDriver, test).IsElementInNewTabPage();
        }

        public void HitCreatedApiCallLink()
        {
            test.Log(Status.Info, "Check if Created API Call Link is clickable & click on it");
            ChromeDriver.SwitchTo().Window(ChromeDriver.WindowHandles[0]);
            ClickElement(ChromeDriver, createdApiCallLink);
            test.Log(Status.Info, "Created API Call Link is clickable & clicked on it");

        }
        public void HitNoContentApiCallLink()
        {
            test.Log(Status.Info, "Check if No Content API Call Link is clickable & click on it");
            ClickElement(ChromeDriver, noContentApiCallLink);
            test.Log(Status.Info, "No Content API Call Link is clickable & clicked on it");
        }
        public void HitMovedApiCallLink()
        {

            test.Log(Status.Info, "Check if Moved API Call Link is clickable & click on it");
            ClickElement(ChromeDriver, movedApiCallLink);
            test.Log(Status.Info, "Moved API Call Link is clickable & clicked on it");
        }
        public void HitBadRequestApiCallLink()
        {
            test.Log(Status.Info, "Check if Bad Request API Call Link is clickable & click on it");
            ClickElement(ChromeDriver, badRequestApiCallLink);
            test.Log(Status.Info, "Bad Request API Call Link is clickable & clicked on it");
        }
        public void HitUnauthorizedApiCallLink()
        {
            test.Log(Status.Info, "Check if Unauthorized API Call Link is clickable & click on it");
            ClickElement(ChromeDriver, unauthorizedApiCallLink);
            test.Log(Status.Info, "Unauthorized API Call Link is clickable & clicked on it");
        }
        public void HitForbiddenApiCallLink()
        {
            test.Log(Status.Info, "Check if Forbidden API Call Link is clickable & click on it");
            ClickElement(ChromeDriver, forbiddenApiCallLink);
            test.Log(Status.Info, "Forbidden API Call Link is clickable & clicked on it");
        }
        public void HitInvalidUrlApiCallLink()
        {
            test.Log(Status.Info, "Check if Invalid Url API Call Link is clickable & click on it");
            ClickElement(ChromeDriver, invalidUrlApiCallLink);
            test.Log(Status.Info, "Invalid Url API Call Link is clickable & clicked on it");
        }
        public bool IsAPICallResponseCorrect(string statusResponse)
        {
            test.Log(Status.Info, "Check if Link Response Message matches with API call status response");
            WaitToBeVisible(ChromeDriver, 5, linkResponseMessage);
            ScrollElementIntoViewJSVersion(ChromeDriver, linkResponseMessage);
            return ChromeDriver.FindElement(linkResponseMessage).Text.Contains(statusResponse);
            
        }
    }
}

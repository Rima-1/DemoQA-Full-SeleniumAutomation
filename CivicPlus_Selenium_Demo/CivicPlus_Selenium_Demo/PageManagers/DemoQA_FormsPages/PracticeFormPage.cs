using AventStack.ExtentReports;
using CivicPlus_Selenium_Demo;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Xml.Linq;

namespace CivicPlus_Selenium_Demo
{
    public class PracticeFormPage : BaseDriver
    {
        public PracticeFormPage(IWebDriver driver, ExtentTest extenttest) : base(driver, extenttest) { }

        private By practiceFormButton = By.Id("item-0");
        private By addFirstName = By.Id("firstName");
        private By addLastName = By.Id("lastName");
        private By addEmail = By.Id("userEmail");
        private By selectGender = By.Id("gender-radio-1");
        private By addMobileNumber = By.Id("userNumber");
        private By addDOB = By.Id("dateOfBirthInput");
        private By addSubjects = By.XPath("//div[contains(@class, 'subjects-auto-complete__value-container')]");
        private By radioButtonList = By.ClassName("custom-control-label");


        public void OpenURL_PracticeFormPage()
        {
            test.Log(Status.Info, "Navigating to URL of demoQA Practice Form page");
            //ChromeDriver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            OpenURL("https://demoqa.com/automation-practice-form");
        }

        public bool IsLandedOnPracticeFormPage()
        {
            test.Log(Status.Info, "Check if Practice Form Button is visible");
            return IsVisible(ChromeDriver, 5, practiceFormButton);
        }

        public void EnterName()
        {
            TextEntered(ChromeDriver, addFirstName, "Phupha");
            TextEntered(ChromeDriver, addLastName, "Pirapat");
        }
        public void EnterEmail()
        {
            TextEntered(ChromeDriver, addEmail, "PhuphaTianATOTS@gmail.com");
        }
        public void SelectGender()
        {
            /*IList<IWebElement> radioButton = ChromeDriver.FindElements(By.ClassName("custom-control-label"));
            radioButton.ElementAt(0).Click(); //To click first radio button*/
            SelectRadioButtonFromList(ChromeDriver, radioButtonList, 0);//To click first radio button
        }

        public void EnterMobileNumber() 
        {
            TextEntered(ChromeDriver, addMobileNumber, "8240689698");
        }

        public void EnterDOB()
        {
            ScrollElementIntoViewJSVersion(ChromeDriver, addDOB);
            ChromeDriver.FindElement(addDOB).Click();
            for(int i=0; i<10; i++) { ChromeDriver.FindElement(addDOB).SendKeys(Keys.Backspace); }
            TextEntered(ChromeDriver, addDOB, "4 Apr 1999");
            ChromeDriver.FindElement(addDOB).SendKeys(Keys.Enter);
        }
        
        public void EnterSubjects()
        {
            ChromeDriver.FindElement(addSubjects).Click();
            Thread.Sleep(5000);
            ChromeDriver.FindElement(addSubjects).SendKeys("Maths");
            /*ChromeDriver.FindElement(addSubjects).SendKeys(Keys.Enter);
            TextEntered(ChromeDriver, addSubjects, "Physics");
            ChromeDriver.FindElement(addSubjects).SendKeys(Keys.Enter);
            TextEntered(ChromeDriver, addSubjects, "Computer");
            ChromeDriver.FindElement(addSubjects).SendKeys(Keys.Enter);*/
        }
    }
}

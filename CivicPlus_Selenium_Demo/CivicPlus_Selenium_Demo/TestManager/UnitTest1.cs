using AventStack.ExtentReports;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Threading;

[assembly: Parallelize(Workers = 4, Scope = ExecutionScope.MethodLevel)]

namespace CivicPlus_Selenium_Demo
{
    [TestClass]
    public class UnitTest1 : BaseUnitTest
    {
        //public TestContext testContext;
        public ExtentReports getrep;
        /// <summary>
        /// Test Product Search in Automation Page.
        /// </summary>
        [TestMethod]
        public void TestDemoQAHomePage()
        {
            //getrep = ExtentReportInitialize(testContext);
            getrep = ExtentReportInitialize();
            test = getrep.CreateTest("Test DemoQA Home Page.");
            DemoQA_HomePage demoQA_HomePage = new DemoQA_HomePage(ChromeDriver, test);
            demoQA_HomePage.OpenURL_HomePage();
            Assert.IsTrue(demoQA_HomePage.ConfirmTitleofDemoQAPage());
            test.Log(Status.Pass, "Landed on DemoQA Home Page & it's title matched successfully.");
        }

        [TestMethod]
        public void TestDemoQAElementsPage_TextBox()
        {
            //getrep = ExtentReportInitialize(testContext);
            getrep = ExtentReportInitialize();
            test = getrep.CreateTest("Test DemoQA Elements Page for TextBox.");
            TextboxPage textboxPage = new TextboxPage(ChromeDriver, test);
            textboxPage.OpenURL_TestBoxPage();
            Assert.IsTrue(textboxPage.IsLandedOnTextBoxPage());
            test.Log(Status.Pass, "Landed on DemoQA Elements Text Box Page successfully.");
            textboxPage.EnterNameInTextBox("Earth Pirapat Watthanasetsiri");
            textboxPage.EnterEmailInTextBox("theearthe23021994@gmail.com");
            textboxPage.EnterCurrentAddressInTextBox("Bangna, Suphanburi");
            textboxPage.EnterPermanentAddressInTextBox("Pha Pun Dao, Chiang Mai");
            Assert.IsTrue(textboxPage.IsFormSubmitted());
            test.Log(Status.Pass, "Form submitted successfully.");
        }

        [TestMethod]
        public void TestDemoQAElementsPage_CheckBox()
        {
            //getrep = ExtentReportInitialize(testContext);
            getrep = ExtentReportInitialize();
            test = getrep.CreateTest("Test DemoQA Elements Page for CheckBox.");
            CheckBoxPage checkBoxPage = new CheckBoxPage(ChromeDriver, test);
            checkBoxPage.OpenURL_CheckboxPage();
            Assert.IsTrue(checkBoxPage.IsLandedOnCheckBoxPage());
            test.Log(Status.Pass, "Landed on DemoQA Elements Check Box Page successfully.");
            Assert.IsFalse(checkBoxPage.IsCheckboxUnchecked());
            test.Log(Status.Info, "Check Box is unchecked");
            checkBoxPage.HitCheckbox();
            Assert.IsTrue(checkBoxPage.IsCheckboxChecked());
            test.Log(Status.Pass, "Check Box is checked successfully.");
        }

        [TestMethod]
        public void TestDemoQAElementsPage_RadioButton()
        {
            //getrep = ExtentReportInitialize(testContext);
            getrep = ExtentReportInitialize();
            test = getrep.CreateTest("Test DemoQA Elements Page for RadioButtons.");
            RadioButtonPage radioButtonPage = new RadioButtonPage(ChromeDriver, test);
            radioButtonPage.OpenURL_RadioButtonPage();
            Assert.IsTrue(radioButtonPage.IsLandedOnRadioButtonPage());
            test.Log(Status.Pass, "Landed on DemoQA Elements Radio Button Page successfully.");
            Assert.IsTrue(radioButtonPage.IsYesRadioButtonClicked());
            test.Log(Status.Pass, "Clicked on Yes Radio Button successfully.");
            Assert.IsTrue(radioButtonPage.IsImpressiveRadioButtonClicked());
            test.Log(Status.Pass, "Clicked on Impressive Radio Button successfully.");
        }

        [TestMethod]
        public void TestDemoQAElementsPage_WebTable()
        {
            //getrep = ExtentReportInitialize(testContext);
            getrep = ExtentReportInitialize();
            test = getrep.CreateTest("Test DemoQA Elements Page for WebTable.");
            WebTablePage webTablePage = new WebTablePage(ChromeDriver, test);
            webTablePage.OpenURL_WebTablePage();
            Assert.IsTrue(webTablePage.IsLandedOnWebtablePage());
            test.Log(Status.Pass, "Landed on DemoQA Elements Web Table Page successfully.");
            webTablePage.HitAddButton();
            webTablePage.AddDetails();
            webTablePage.HitSubmitButton();
            Assert.IsTrue(webTablePage.IsCorrectDetailsAdded());
            test.Log(Status.Pass, "All details are entered correctly & successfully.");
        }

        [TestMethod]
        public void TestDemoQAElementsPage_ButtonClicks()
        {
            //getrep = ExtentReportInitialize(testContext);
            getrep = ExtentReportInitialize();
            test = getrep.CreateTest("Test DemoQA Elements Page for Buttons.");
            ButtonClickPage buttonClickPage = new ButtonClickPage(ChromeDriver, test);
            buttonClickPage.OpenURL_ButtonClicksPage();
            Assert.IsTrue(buttonClickPage.IsLandedOnButtonPage());
            test.Log(Status.Pass, "Landed on DemoQA Elements Buttons Page successfully.");
            Assert.IsTrue(buttonClickPage.IsDoubleClickSuccess());
            test.Log(Status.Pass, "Double Clicked successfully.");
            Assert.IsTrue(buttonClickPage.IsRightClickSuccess());
            test.Log(Status.Pass, "Right Clicked successfully.");
            Assert.IsTrue(buttonClickPage.IsDynamicClickSuccess());
            test.Log(Status.Pass, "Clicked successfully.");
        }

        [TestMethod]
        public void TestDemoQAElementsPage_Links()
        {
            //getrep = ExtentReportInitialize(testContext);
            getrep = ExtentReportInitialize();
            test = getrep.CreateTest("Test DemoQA Elements Page for Links.");
            LinksPage linksPage = new LinksPage(ChromeDriver, test);
            linksPage.OpenURL_LinksPage();
            Assert.IsTrue(linksPage.IsLandedOnLinksPage());
            test.Log(Status.Pass, "Landed on DemoQA Elements Links Page successfully.");
            Assert.IsTrue(linksPage.IsNewHomeTabButtonClicked());
            test.Log(Status.Pass, "New Home Link is clickable & clicked on it successfully.");
            Assert.IsTrue(linksPage.IsLandedOnNewHomeTabPage());
            test.Log(Status.Pass, "Landed on New Home Tab Page successfully.");
            Assert.IsTrue(linksPage.IsNewDynamicLinkHomeTabButtonClicked());
            test.Log(Status.Pass, "Dynamic Home Link is clickable & clicked on it successfully.");
            Assert.IsTrue(linksPage.IsLandedOnNewDynamicLinkHomeTabPage());
            test.Log(Status.Pass, "Landed on Dynamic Home Tab Page successfully.");
            linksPage.HitCreatedApiCallLink();
            Assert.IsTrue(linksPage.IsAPICallResponseCorrect("staus 201"));
            test.Log(Status.Pass, "Matched successfully.");
            linksPage.HitNoContentApiCallLink();
            Thread.Sleep(3000);
            Assert.IsTrue(linksPage.IsAPICallResponseCorrect("staus 204"));
            test.Log(Status.Pass, "Matched successfully.");
            linksPage.HitMovedApiCallLink();
            Thread.Sleep(3000);
            Assert.IsTrue(linksPage.IsAPICallResponseCorrect("staus 301"));
            test.Log(Status.Pass, "Matched successfully.");
            linksPage.HitBadRequestApiCallLink();
            Thread.Sleep(3000);
            Assert.IsTrue(linksPage.IsAPICallResponseCorrect("staus 400"));
            test.Log(Status.Pass, "Matched successfully.");
            linksPage.HitUnauthorizedApiCallLink();
            Thread.Sleep(3000);
            Assert.IsTrue(linksPage.IsAPICallResponseCorrect("staus 401"));
            test.Log(Status.Pass, "Matched successfully.");
            linksPage.HitForbiddenApiCallLink();
            Thread.Sleep(3000);
            Assert.IsTrue(linksPage.IsAPICallResponseCorrect("staus 403"));
            test.Log(Status.Pass, "Matched successfully.");
            linksPage.HitInvalidUrlApiCallLink();
            Thread.Sleep(3000);
            Assert.IsTrue(linksPage.IsAPICallResponseCorrect("staus 404"));
            test.Log(Status.Pass, "Matched successfully.");
        }

        [TestMethod]
        public void TestDemoQAElementsPage_BrokenImagesLinks()
        {
            //getrep = ExtentReportInitialize(testContext);
            getrep = ExtentReportInitialize();
            test = getrep.CreateTest("Test DemoQA Elements Page for BrokenImagesLinks.");
            BrokenImagesLinksPage brokenImagesLinksPage = new BrokenImagesLinksPage(ChromeDriver,test);
            brokenImagesLinksPage.OpenURL_BrokenImagesLinksPage();
            Assert.IsTrue(brokenImagesLinksPage.IsLandedOnLinksPage());
            test.Log(Status.Pass, "Landed on DemoQA Elements Broken Images Links Page successfully.");
            Assert.IsTrue(brokenImagesLinksPage.checkForBrokenImages());
            test.Log(Status.Pass, "2 broken images are found in the page successfully.");
            //Assert.IsTrue(brokenImagesLinksPage.CheckForBrokenLinks());
            //Console.WriteLine(brokenImagesLinksPage.brokenLinks());
            brokenImagesLinksPage.brokenLinksTest();
        }

        [TestMethod]
        public void TestDemoQAElementsPage_UploadAndDownload()
        {
            //getrep = ExtentReportInitialize(testContext);
            getrep = ExtentReportInitialize();
            test = getrep.CreateTest("Test DemoQA Elements Page for Upload and Download.");
            UploadAndDownloadPage uploadAndDownloadPage = new UploadAndDownloadPage(ChromeDriver, test);
            uploadAndDownloadPage.OpenURL_UploadAndDownloadPage();
            Assert.IsTrue(uploadAndDownloadPage.IsLandedOnUploadAndDownloadPage());
            test.Log(Status.Pass, "Landed on DemoQA Elements Upload & Download Page successfully.");
            Assert.IsTrue(uploadAndDownloadPage.IsFileUploaded("C://Users//Rima.Panja//Desktop//Xperiments6.02022.png", "Xperiments6.02022.png"));
            test.Log(Status.Pass, "Correct Image Uploaded successfully.");
            Assert.IsTrue(uploadAndDownloadPage.IsFileDownloaded());
            test.Log(Status.Pass, "Correct Image Downloaded successfully.");
        }

        [TestMethod]
        public void TestDemoQAElementsPage_BrowserWindows()
        {
            //getrep = ExtentReportInitialize(testContext);
            getrep = ExtentReportInitialize();
            test = getrep.CreateTest("Test DemoQA Elements Page for BrowserWindows.");
            BrowserWindowsPage browserWindowsPage = new BrowserWindowsPage(ChromeDriver, test);
            browserWindowsPage.OpenURL_BrowserWindowsPage();
            test.Log(Status.Info, "Landed on Browser Windows Page");
            Assert.IsTrue(browserWindowsPage.IsNewTabButtonClicked());
            test.Log(Status.Pass, "New Tab Button is clickable & clicked successfully.");
            Assert.IsTrue(browserWindowsPage.IsLandedOnNewTabPage());
            test.Log(Status.Pass, "Landed on New Tab Page successfully.");
            Assert.IsTrue(browserWindowsPage.IsNewWindowButtonClicked());
            test.Log(Status.Pass, "New Window Button is clickable & clicked successfully.");
            Assert.IsTrue(browserWindowsPage.IsLandedOnNewWindowPage());
            test.Log(Status.Pass, "Landed on New Window Page successfully.");
            Assert.IsTrue(browserWindowsPage.IsNewWindowMessageButtonClicked());
            test.Log(Status.Pass, "New Window Message Button is clickable & clicked successfully.");
            Assert.IsTrue(browserWindowsPage.IsLandedOnNewWindowMessagePage());
            test.Log(Status.Pass, "Landed on New Window Message Page successfully.");
            //The window doesn't automatically closes, taking a lot of time.
            browserWindowsPage.SwitchingToParentWindow(); 
        }

        [TestMethod]
        public void TestDemoQAElementsPage_Alerts()
        {
            //getrep = ExtentReportInitialize(testContext);
            getrep = ExtentReportInitialize();
            test = getrep.CreateTest("Test DemoQA Elements Page for Alerts.");
            AlertsHandlingPage alertsHandlingPage = new AlertsHandlingPage(ChromeDriver, test);
            alertsHandlingPage.OpenURL_AlertsHandlingPage();
            test.Log(Status.Info, "Landed on Alerts Page");
            Assert.IsTrue(alertsHandlingPage.IsButtonToGetAlertClicked());
            test.Log(Status.Pass, "Button to see alert is clickable & clicked successfully.");
            Assert.IsTrue(alertsHandlingPage.IsAlertWindowOpened());
            test.Log(Status.Pass, "correct alert window is opened successfully.");
            alertsHandlingPage.acceptAlert();
            Assert.IsTrue(alertsHandlingPage.IsButtonToGetTimerAlertClicked());
            test.Log(Status.Pass, "Button to see Timer alert is clickable & clicked successfully.");
            Assert.IsTrue(alertsHandlingPage.IsTimerAlertWindowOpened());
            test.Log(Status.Pass, "correct Timer alert window is opened successfully.");
            alertsHandlingPage.acceptAlert();
            Assert.IsTrue(alertsHandlingPage.IsButtonToGetAcceptDismissAlertClicked());
            test.Log(Status.Pass, "Button to see Accept/Dismiss alert is clickable & clicked successfully.");
            Assert.IsTrue(alertsHandlingPage.IsAcceptDismissAlertWindowOpened());
            test.Log(Status.Pass, "correct Accept/Dismiss alert window is opened successfully.");
            alertsHandlingPage.acceptAlert();
            Assert.IsTrue(alertsHandlingPage.IsAlertAccepted());
            test.Log(Status.Pass, "Accept/Dismiss alert is accepted correctly & successfully.");
            Assert.IsTrue(alertsHandlingPage.IsButtonToGetAcceptDismissAlertClicked());
            test.Log(Status.Pass, "Button to see Accept/Dismiss alert is clickable & clicked successfully.");
            Assert.IsTrue(alertsHandlingPage.IsAcceptDismissAlertWindowOpened());
            test.Log(Status.Pass, "correct Accept/Dismiss alert window is opened successfully.");
            alertsHandlingPage.dismissAlert();
            Assert.IsTrue(alertsHandlingPage.IsAlertDismissed());
            test.Log(Status.Pass, "Accept/Dismiss alert is Cancelled correctly & successfully.");
            Assert.IsTrue(alertsHandlingPage.IsButtonToGetPromptAlertClicked());
            test.Log(Status.Pass, "Button to see Prompt alert is clickable & clicked successfully.");
            Assert.IsTrue(alertsHandlingPage.IsPromptAlertWindowOpened());
            test.Log(Status.Pass, "correct Prompt alert window is opened successfully.");
            alertsHandlingPage.enterTextInPromptAlert();
            test.Log(Status.Pass, "Text entered in Prompt alert window successfully.");
            alertsHandlingPage.acceptAlert();
            Assert.IsTrue(alertsHandlingPage.IsPromptAlertAccepted());
            test.Log(Status.Pass, "Prompt alert is accepted correctly & successfully.");
        }

        [TestMethod]
        public void TestDemoQAElementsPage_Frames()
        {
            //getrep = ExtentReportInitialize(testContext);
            getrep = ExtentReportInitialize();
            test = getrep.CreateTest("Test DemoQA Elements Page for Frames.");
            FramesHandlingPage framesHandlingPage = new FramesHandlingPage(ChromeDriver, test);
            framesHandlingPage.OpenURL_FramesHandlingPage();
            test.Log(Status.Info, "Landed on Frames Page");
            Assert.IsTrue(framesHandlingPage.IsSwitchedToFrame1());
            test.Log(Status.Pass, "switched to IFrame1 correctly & successfully.");
            Assert.IsTrue(framesHandlingPage.IsSwitchedToDefaultContent());
            test.Log(Status.Pass, "switched to Default Content correctly & successfully.");
            Assert.IsTrue(framesHandlingPage.IsSwitchedToFrame2());
            test.Log(Status.Pass, "switched to IFrame2 correctly & successfully.");
        }

        [TestMethod]
        public void TestDemoQAElementsPage_NestedFrames()
        {
            //getrep = ExtentReportInitialize(testContext);
            getrep = ExtentReportInitialize();
            test = getrep.CreateTest("Test DemoQA Elements Page for Nested Frames.");
            NestedFramesHandlingPage nestedFramesHandlingPage = new NestedFramesHandlingPage(ChromeDriver, test);
            nestedFramesHandlingPage.OpenURL_NestedFramesHandlingPage();
            test.Log(Status.Info, "Landed on Nested Frames Page");
            Assert.IsTrue(nestedFramesHandlingPage.IsSwitchedToParentFrame());
            test.Log(Status.Pass, "switched to Parent IFrame correctly & successfully.");
            Assert.IsTrue(nestedFramesHandlingPage.IsSwitchedToChildFrame());
            test.Log(Status.Pass, "switched to Child IFrame correctly & successfully.");
            Assert.IsTrue(nestedFramesHandlingPage.IsSwitchedToDefaultContent());
            test.Log(Status.Pass, "switched to Default Content correctly & successfully.");
        }

        [TestMethod]
        public void TestDemoQAElementsPage_ModalDialogs()
        {
            //getrep = ExtentReportInitialize(testContext);
            getrep = ExtentReportInitialize();
            test = getrep.CreateTest("Test DemoQA Elements Page for Modal Dialogs.");
            ModalDialogsPage modalDialogsPage = new ModalDialogsPage(ChromeDriver, test);
            modalDialogsPage.OpenURL_ModalDialogsPage();
            test.Log(Status.Info, "Landed on Modal Dialogs Page");
            modalDialogsPage.HitSmallModalButton();
            Assert.IsTrue(modalDialogsPage.IsLandedOnSmallModalDialog());
            test.Log(Status.Pass, "Landed On Small Modal Dialog successfully.");
            modalDialogsPage.HitCloseSmallModalButton();
            modalDialogsPage.HitLargeModalButton();
            Assert.IsTrue(modalDialogsPage.IsLandedOnLargeModalDialog());
            test.Log(Status.Pass, "Landed On Large Modal Dialog successfully.");
            modalDialogsPage.HitCloseLargeModalButton();
            Assert.IsTrue(modalDialogsPage.IsLandedOnDefaultContentPage());
            test.Log(Status.Pass, "Landed On Default Content Page successfully.");
        }

        [TestMethod]
        public void TestDemoQAElementsPage_PracticeForm()
        {
            //getrep = ExtentReportInitialize(testContext);
            getrep = ExtentReportInitialize();
            test = getrep.CreateTest("Test DemoQA Elements Page for Practice Form.");
            PracticeFormPage practiceFormPage = new PracticeFormPage(ChromeDriver, test);
            practiceFormPage.OpenURL_PracticeFormPage();
            //Assert.IsTrue(practiceFormPage.IsLandedOnPracticeFormPage());
            practiceFormPage.EnterName();
            practiceFormPage.EnterEmail();
            practiceFormPage.SelectGender();
            practiceFormPage.EnterMobileNumber();
            practiceFormPage.EnterDOB();
            practiceFormPage.EnterSubjects();
        }

        [TestMethod]
        public void TestDemoQAElementsPage_AutoComplete()
        {
            //getrep = ExtentReportInitialize(testContext);
            getrep = ExtentReportInitialize();
            test = getrep.CreateTest("Test DemoQA Elements Page for Auto Complete.");
            AutoCompletePage autoCompletePage = new AutoCompletePage(ChromeDriver, test);
            autoCompletePage.OpenURL_AutoCompletePage();
            //Assert.IsTrue(autoCompletePage.IsLandedOnAutocompletePage());
            autoCompletePage.EnterSingleColourName();
        }

        [TestMethod]
        public void TestDemoQAElementsPage_DatePicker()
        {
            //getrep = ExtentReportInitialize(testContext);
            getrep = ExtentReportInitialize();
            test = getrep.CreateTest("Test DemoQA Elements Page for Date Picker.");
            DatePickerPage datePickerPage = new DatePickerPage(ChromeDriver, test);
            datePickerPage.OpenURL_DatePickerPage();
            test.Log(Status.Info, "Landed on Date Picker Page");
            //Assert.IsTrue(datePickerPage.IsLandedOnDatePickerPage());
            Assert.IsTrue(datePickerPage.EnterDate());
            test.Log(Status.Pass, "Date entered successfully.");
            Assert.IsTrue(datePickerPage.EnterDateAndTime());
            test.Log(Status.Pass, "Date & Time entered successfully.");
        }

        [TestMethod]
        public void TestDemoQAElementsPage_SelectMenu()
        {
            //getrep = ExtentReportInitialize(testContext);
            getrep = ExtentReportInitialize();
            test = getrep.CreateTest("Test DemoQA Elements Page for Select Menu.");
            SelectMenuPage selectMenuPage = new SelectMenuPage(ChromeDriver, test);
            selectMenuPage.OpenURL_SelectMenuPage();
            test.Log(Status.Info, "Landed on Select Menu Page");
            //Assert.IsTrue(datePickerPage.IsLandedOnDatePickerPage());
            selectMenuPage.HandlingSelectValueMenu();
            test.Log(Status.Pass, "Select Value Dropdown is handled successfully.");
            selectMenuPage.HandlingOldStyleSelectMenu();
            test.Log(Status.Pass, "Old Style Dropdown is handled successfully.");
            selectMenuPage.HandlingMultipleSelectValueMenu();
            test.Log(Status.Pass, "Select Multiple Value Dropdown is handled successfully.");
        }

        [TestMethod]
        public void TestDemoQAElementsPage_Accordian()
        {
            //getrep = ExtentReportInitialize(testContext);
            getrep = ExtentReportInitialize();
            test = getrep.CreateTest("Test DemoQA Elements Page for Accordian.");
            AccordianPage accordianPage = new AccordianPage(ChromeDriver, test);
            accordianPage.OpenURL_AccordianPage();
            test.Log(Status.Info, "Landed on Accordian Page");
            Assert.IsTrue(accordianPage.IsCard1Expanded());
            test.Log(Status.Pass, "Card 1's heading & text after expanding it matches correctly");
            Assert.IsTrue(accordianPage.IsCard2Expanded());
            test.Log(Status.Pass, "Card 2's heading & text after expanding it matches correctly");
            Assert.IsTrue(accordianPage.IsCard3Expanded());
            test.Log(Status.Pass, "Card 3's heading & text after expanding it matches correctly");
        }

        [TestMethod]
        public void TestDemoQAElementsPage_Slider()
        {
            //getrep = ExtentReportInitialize(testContext);
            getrep = ExtentReportInitialize();
            test = getrep.CreateTest("Test DemoQA Elements Page for Slider.");
            SliderPage sliderPage = new SliderPage(ChromeDriver, test);
            sliderPage.OpenURL_SliderPage();
            test.Log(Status.Info, "Landed on Slider Page");
            Assert.IsTrue(sliderPage.SliderTestByMovingSlider());
            test.Log(Status.Pass, "Slider is moving successfully to a specific value & it matches with the value in TextBox correctly");
        }

        [TestMethod]
        public void TestDemoQAElementsPage_ProgressBar()
        {
            //getrep = ExtentReportInitialize(testContext);
            getrep = ExtentReportInitialize();
            test = getrep.CreateTest("Test DemoQA Elements Page for Progress Bar.");
            ProgressBarPage progressBarPage = new ProgressBarPage(ChromeDriver, test);
            progressBarPage.OpenURL_ProgressBarPage();
            test.Log(Status.Info, "Landed on Progress Bar Page");
            progressBarPage.StartProgressCalculation();
            Assert.IsTrue(progressBarPage.checkForCompleteProgress());
            test.Log(Status.Pass, "Progress Is 100% shown successfully");
            progressBarPage.ResetProgressCalculation();
            Assert.IsTrue(progressBarPage.IsProgressResetted());
            test.Log(Status.Pass, "Progress Is 0%, Resetted successfully");
        }

        [TestMethod]
        public void TestDemoQAElementsPage_Tabs()
        {
            //getrep = ExtentReportInitialize(testContext);
            getrep = ExtentReportInitialize();
            test = getrep.CreateTest("Test DemoQA Elements Page for Tabs.");
            TabsPage tabsPage = new TabsPage(ChromeDriver, test);
            tabsPage.OpenURL_TabsPage();
            test.Log(Status.Info, "Landed on Tabs Page");
            Assert.IsTrue(tabsPage.IsWhatTabOpened());
            test.Log(Status.Pass, "Landed on What Tab succesfully & it's text matches correctly");
            Assert.IsTrue(tabsPage.IsOriginTabOpened());
            test.Log(Status.Pass, "Landed on Origin Tab succesfully & it's text matches correctly");
            Assert.IsTrue(tabsPage.IsUseTabOpened());
            test.Log(Status.Pass, "Landed on Use Tab succesfully & it's text matches correctly");
        }

        [TestMethod]
        public void TestDemoQAElementsPage_ToolTips()
        {
            //getrep = ExtentReportInitialize(testContext);
            getrep = ExtentReportInitialize();
            test = getrep.CreateTest("Test DemoQA Elements Page for Tool Tips.");
            ToolTipsPage toolTipsPage = new ToolTipsPage(ChromeDriver, test);
            toolTipsPage.OpenURL_ToolTipsPage();
            test.Log(Status.Info, "Landed on Tool Tips Page");
            Assert.IsTrue(toolTipsPage.IsHoveredOverTheButton());
            test.Log(Status.Pass, "Hovered over the button correctly & successfully");
            Assert.IsTrue(toolTipsPage.IsHoveredOverTheTextBox());
            test.Log(Status.Pass, "Hovered over the Text Box correctly & successfully");
            Assert.IsTrue(toolTipsPage.IsHoveredOverContraryLink());
            test.Log(Status.Pass, "Hovered over the Contrary Link correctly & successfully");
            Assert.IsTrue(toolTipsPage.IsHoveredOverNumberLink());
            test.Log(Status.Pass, "Hovered over the Number Link correctly & successfully");
        }

        [TestMethod]
        public void TestDemoQAElementsPage_Menu()
        {
            //getrep = ExtentReportInitialize(testContext);
            getrep = ExtentReportInitialize();
            test = getrep.CreateTest("Test DemoQA Elements Page for Menu.");
            MenuPage menuPage = new MenuPage(ChromeDriver, test);
            menuPage.OpenURL_MenuPage();
            test.Log(Status.Info, "Landed on Menu Page");
            Assert.IsTrue(menuPage.IsHoveredOverMainItem2Link());
            test.Log(Status.Pass, "Hovered over Main Item 2 correctly & successfully");
            Assert.IsTrue(menuPage.IsSubItem1LinkClickable());
            test.Log(Status.Pass, "sub Item 1 is clickable & clicked on it successfully");
            Assert.IsTrue(menuPage.IsSubItem2LinkClickable());
            test.Log(Status.Pass, "sub Item 2 is clickable & clicked on it successfully");
            Assert.IsTrue(menuPage.IsHoveredOverSubSubItemListLink());
            test.Log(Status.Pass, "Hovered over SUB SUB LIST correctly & successfully");
            Assert.IsTrue(menuPage.IsSubSubItem1LinkClickable());
            test.Log(Status.Pass, "sub sub Item 1 is clickable & clicked on it successfully");
            Assert.IsTrue(menuPage.IsSubSubItem2LinkClickable());
            test.Log(Status.Pass, "sub sub Item 2 is clickable & clicked on it successfully");
        }

        [TestMethod]
        public void TestDemoQAElementsPage_Sortable()
        {
            //getrep = ExtentReportInitialize(testContext);
            getrep = ExtentReportInitialize();
            test = getrep.CreateTest("Test DemoQA Elements Page for Sortable List & Grid.");
            SortablePage sortablePage = new SortablePage(ChromeDriver, test);
            sortablePage.OpenURL_SortablePage();
            test.Log(Status.Info, "Landed on Sortable Page");
            sortablePage.clickOnListTab();
            Assert.IsTrue(sortablePage.sortElementsInDescendingOrder());
            test.Log(Status.Pass, "Elements are dragged & dropped correctly, & sorted in Descending successfully");
            sortablePage.clickOnGridTab();
            Assert.IsTrue(sortablePage.dragAndDrop1Between8And9InGrid());
            test.Log(Status.Pass, "Element named One is dragged and dropped between Elements named Eight & Nine in Grid successfully");
        }

        [TestMethod]
        public void TestDemoQAElementsPage_Selectable()
        {
            //getrep = ExtentReportInitialize(testContext);
            getrep = ExtentReportInitialize();
            test = getrep.CreateTest("Test DemoQA Elements Page for Selectable List & Grid.");
            SelectablePage selectablePage= new SelectablePage(ChromeDriver,test);
            selectablePage.OpenURL_SelectablePage();
            test.Log(Status.Info, "Landed on Selectable Page");
            selectablePage.clickOnListTab();
            Assert.IsTrue(selectablePage.selectAllElementsInList());
            test.Log(Status.Pass, "All Elements are clickable & selected in List successfully");
            selectablePage.clickOnGridTab();
            Assert.IsTrue(selectablePage.selectAllElementsInGrid());
            test.Log(Status.Pass, "All Elements are clickable & selected in Grid successfully");
        }

        [TestMethod]
        public void TestDemoQAElementsPage_Resizable()
        {
            //getrep = ExtentReportInitialize(testContext);
            getrep = ExtentReportInitialize();
            test = getrep.CreateTest("Test DemoQA Elements Page for Resizable Element.");
            ResizablePage resizablePage = new ResizablePage(ChromeDriver,test);
            resizablePage.OpenURL_ResizablePage();
            test.Log(Status.Info, "Landed on Resizable Page");
            Assert.IsTrue(resizablePage.IsElementResizable());
            test.Log(Status.Pass, "Element Is Resizable & resized it successfully");
        }

        [TestMethod]
        public void TestDemoQAElementsPage_Droppable()
        {
            //getrep = ExtentReportInitialize(testContext);
            getrep = ExtentReportInitialize();
            test = getrep.CreateTest("Test DemoQA Elements Page for Droppable Element.");
            DroppablePage droppablePage = new DroppablePage(ChromeDriver, test);
            droppablePage.OpenURL_DroppablePage();
            test.Log(Status.Info, "Landed on Droppable Page");
            droppablePage.clickOnSimpleTab();
            Assert.IsTrue(droppablePage.IsDroppableBoxTextIsDropHere());
            test.Log(Status.Pass, "Before Drag & Drop Action Performed, The Text in Droppable Box is Drop Here");
            Assert.IsTrue(droppablePage.IsDragAndDropDoneInSimpleTab());
            test.Log(Status.Pass, "Drag & Drop Action is Performed successfully, & The Text in Droppable Box changed to Dropped!");
            droppablePage.clickOnAcceptTab();
            Assert.IsTrue(droppablePage.IsTextChangedOnDrppingNotAcceptableBox());
            test.Log(Status.Pass, "Drag & Drop Action is Performed successfully for Not Acceptable Box, but The Text in Droppable Box is Drop Here");
            Assert.IsTrue(droppablePage.IsTextChangedOnDrppingAcceptableBox());
            test.Log(Status.Pass, "Drag & Drop Action is Performed successfully for Acceptable Box, & The Text in Droppable Box changed to Dropped");
            //droppablePage.IsTextChangedOnDrppingAcceptableBox();
            //test.Log(Status.Pass, "Element Is Resizable & resized it successfully");
            droppablePage.clickOnPreventPropagationTab();
            Assert.IsTrue(droppablePage.IsdroppedTo_notGreedyInnerDropBox());
            test.Log(Status.Pass, "Drag & Drop Action is Performed successfully for notGreedyInnerDropBox, & The Text in Outer & Inner Droppable Box changed to Dropped");
            Assert.IsTrue(droppablePage.IsdroppedTo_greedyDropBoxInner());
            test.Log(Status.Pass, "Drag & Drop Action is Performed successfully for GreedyInnerDropBox, & The Text in Only Inner Droppable Box changed to Dropped");
            //Assert.IsTrue(droppablePage.IsdroppedTo_greedyDropBox());
            droppablePage.clickOnRevertDraggableTab();
            Assert.IsTrue(droppablePage.IsRevertable_NonRevertable_BoxesHandled());
            test.Log(Status.Pass, "Drag & Drop Action is Performed successfully for both Revertable & Non-Revertable DropBox, & The Revertable dropbox gets reverted while Non-Revertable is inside the droppable box");
        }

        [TestMethod]
        public void TestDemoQAElementsPage_Draggable()
        {
            //getrep = ExtentReportInitialize(testContext);
            getrep = ExtentReportInitialize();
            test = getrep.CreateTest("Test DemoQA Elements Page for Draggable Element.");
            DraggablePage draggablePage = new DraggablePage(ChromeDriver, test);
            draggablePage.OpenURL_DraggablePage();
            test.Log(Status.Info, "Landed on Draggable Page");
            draggablePage.clickOnSimpleTab();
            Assert.IsTrue(draggablePage.IsDragBoxDropped());
            test.Log(Status.Pass, "Draggable Box can be dragged & dropped anywhere successfully");
            draggablePage.clickOnAxisRestrictedTab();
            //Assert.IsFalse(draggablePage.IsXAxisDragBoxDropped_Test1());
            //test.Log(Status.Pass, "X-Axis Draggable Box can be dragged but can't be dropped anywhere");
            Assert.IsTrue(draggablePage.IsXAxisDragBoxDropped_Test2());
            test.Log(Status.Pass, "X-Axis Draggable Box can be dragged & dropped only in X-axis anywhere successfully");
            Assert.IsTrue(draggablePage.IsYAxisDragBoxDropped_Test2());
            test.Log(Status.Pass, "Y-Axis Draggable Box can be dragged & dropped only in Y-axis anywhere successfully");
            draggablePage.clickOnContainerRestrictedTab();
            Assert.IsTrue(draggablePage.IsDragBoxDroppedWithinContainer());
            test.Log(Status.Pass, "Draggable Box can be dragged & dropped only inside Container anywhere successfully");
            draggablePage.clickOnCursorStyleTab();
        }
    }
}

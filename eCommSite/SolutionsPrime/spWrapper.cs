using System;
using System.Diagnostics;
using System.Data;
using System.Threading.Tasks;
using System.Text;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace eCommSite.SolutionsPrime
{
    public class spWrapper
    {
        #region Constants_Initiation
        public static IWebDriver driver;
        public static FirefoxProfile profile;        
        public static int elementFindRepeatTime = 60;
        public static Microsoft.VisualStudio.TestTools.UnitTesting.TestContext RunTestContext;
        public IJavaScriptExecutor JS = (IJavaScriptExecutor)driver;
        public enum BrowserType { FireFox, IE, Chrome, ChromeMobile, Android, iOS };
        public enum eActions { Clear, Click, Check, Uncheck, SendKeys, NavigateToElement, InnerHtml, VerifyText, VerifyContains, VerifyTitle, SelectByIndex, SelectByText, SelectByValue, Sync, ClearAndSendKeys, ClearAndSendKeysAndTab, WaitResolveStaleElementAndClick, ClickHandleModal, Submit, SetProperty, jsClick, jsSetText }
        public string strLocationIE = "..\\..\\..\\..\\WebeComm\\packages\\Selenium.WebDriver.IEDriver.3.6.0\\driver";
        public string strLocationChrome = "..\\..\\..\\..\\WebeComm\\packages\\Selenium.WebDriver.ChromeDriver.2.33.0\\driver\\win32";
        public string strLocationFireFox = "..\\..\\..\\..\\WebeComm\\packages\\Selenium.Firefox.WebDriver.0.19.0\\driver";
        #endregion

        #region TestDetails
        public static Dictionary<string, string> ProjectDetails = new Dictionary<string, string>()
        {
            {"ProjectName", "Default" },
            {"BaseStateURL", "Default"},
            {"Env", "Default"},
            {"TestResultFolder", "Default"},


            {"CurrentFeature","Default" },
            {"CurrentTestScenario", "Default"},
            {"CurrentTestCase", "Default"},
            {"CurrentStepID", "Default"},
            {"CurrentTestResult", "Default"},
            {"CurrentWebElementName", "Default"},
            {"TestCaseStartTime", "Default"},
            {"TestCaseAlert", "FALSE"},
            {"TestResultComments", "Default"},

            {"UserName", "Default"},
            {"SignedIn", "Default"},
            {"LoggedIn", "false"},
            {"BrowserType", "3"},
            {"BrowserInitiated", "false"},

            {"SheetName", "Default"}
        };
        #endregion

        /// <summary>
        /// Kill the process with the specified name
        /// </summary>
        /// <param name="name">IEDriverServer</param>
        /// <param name="name">chromedriver</param>
        /// <param name="name">chrome</param>
        public void KillProcess(string name)
        {
            Process[] ps = Process.GetProcesses();
            foreach (Process p in ps)
            {
                try
                {
                    if ((p.ProcessName).ToUpper() == name.ToUpper())
                    {
                        p.Kill();
                    }
                }
                catch (Exception e)
                {
                    spReporter.WriteLine("Error catched in Process Kill Method " + e.StackTrace);
                }
            }
        }

        #region Browser Initiating Methods
        public void initBrowser(bool Clean, Enum pBrowserType)
        {
            try
            {
                eCommSite.SolutionsPrime.spWrapper.ProjectDetails["TestResultFolder"] = RunTestContext.TestRunDirectory + "-PICS";
                
                if (!System.IO.Directory.Exists(ProjectDetails["TestResultFolder"]))
                {                    
                    System.IO.Directory.CreateDirectory(ProjectDetails["TestResultFolder"]);
                }
            }
            catch { Console.WriteLine("In Catch Block ==" + ProjectDetails["TestResultFolder"] ); }
            if (ProjectDetails["BrowserInitiated"].Equals("false"))
            {
                switch (pBrowserType.ToString())
                {
                    case "FireFox":
                        if (Clean)
                        {
                            KillProcess("geckodriver");
                            KillProcess("firefox");
                        }
                        profile = new FirefoxProfile(); ;
                        profile.SetPreference("geo.prompt.testing", true);
                        profile.SetPreference("geo.prompt.testing.allow", true);
                        profile.SetPreference("geo.enabled", true);
                        profile.SetPreference("geo.provider.ms-windows-location", true);
                        profile.SetPreference("geo.wifi.uri", "{ \"status\": \"OK\", \"accuracy\": 10.0, \"location\": { \"lat\": 50.850780, \"lng\": 4.358138, \"latitude\": 50.850780, \"longitude\": 4.358138, \"accuracy\": 10.0}}");
                        //driver = new FirefoxDriver(profile);
                        driver = new FirefoxDriver();
                        ProjectDetails["BrowserType"] = "1";
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                        //driver.Navigate().GoToUrl(ProjectDetails["BaseStateURL"]);
                        //driver.Manage().Window.Maximize();
                        break;

                    case "IE":
                        if (Clean)
                        {
                            KillProcess("IEDriverServer");
                            KillProcess("iexplore");
                        }

                        InternetExplorerOptions ieo = new InternetExplorerOptions();
                        ieo.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                        ieo.IgnoreZoomLevel = true;
                        ieo.InitialBrowserUrl = ProjectDetails["BaseStateURL"];
                        ieo.EnsureCleanSession = true;
                        driver = new InternetExplorerDriver(strLocationIE, ieo);
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                        ProjectDetails["BrowserType"] = "2";
                        //driver.Navigate().GoToUrl(ProjectDetails["BaseStateURL"]);
                        //driver.Manage().Window.Maximize();

                        break;

                    case "Chrome":
                        if (Clean)
                        {
                            KillProcess("chromedriver");
                            KillProcess("chrome");
                        }
                        ChromeOptions co = new ChromeOptions();
                        co.AddArgument("--incognito");
                        driver = new ChromeDriver(strLocationChrome, co);
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                        driver.Navigate().GoToUrl(ProjectDetails["BaseStateURL"]);
                        ProjectDetails["BrowserType"] = "3";
                        driver.Manage().Window.Maximize();
                        break;
                    case "ChromeMobile":
                        if (Clean)
                        {
                            KillProcess("chromedriver");
                            KillProcess("chrome");
                        }
                        ChromeOptions com = new ChromeOptions();
                        com.AddArgument("--incognito");
                        com.AddArgument("--use-mobile-user-agent");
                        ChromeMobileEmulationDeviceSettings cmed = new ChromeMobileEmulationDeviceSettings("Apple iPad");
                        cmed.PixelRatio = 2.0;
                        cmed.Height = 1024;
                        cmed.Width = 768;

                        com.EnableMobileEmulation(cmed);
                        driver = new ChromeDriver(strLocationChrome, com);
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                        driver.Navigate().GoToUrl(ProjectDetails["BaseStateURL"]);
                        ProjectDetails["BrowserType"] = "3";
                        driver.Manage().Window.Maximize();
                        break;
                    default:
                        driver = new FirefoxDriver();
                        driver.Manage().Window.Maximize();
                        ProjectDetails["BrowserType"] = "1";
                        break;
                }
                ProjectDetails["BrowserInitiated"] = "true";
            }
        }
        #endregion

        #region Elements Methods
        public IWebElement getElement(string runTimeObjName, string runByType, string runPropertyValue)
        {            
            return getElement(new objIdentifier(runTimeObjName, runByType, runPropertyValue));
        }
        public IWebElement getElement(objIdentifier objI)
        {
            if(objI.IdName == null)
            {
                objI.IdName = string.Empty;
            }
            IWebElement cWebElement = driver.FindElement(By.TagName("HTML"));            
            int timer = 0;
            switch (objI.IdType.ToString())
            {
                case "Id":
                    objI.jsId = "getElementById(\"";
                    try
                    {
                        while(timer < elementFindRepeatTime)
                        {
                            cWebElement = driver.FindElement(By.Id(objI.IdValue.ToString()));
                            timer = elementFindRepeatTime;
                        }
                    }
                    catch
                    {
                        timer = timer + 1;
                        System.Threading.Thread.Sleep(100);
                    }
                    break;
                case "CssSelector":
                    objI.jsId = "querySelector(\"";
                    try
                    {
                        while (timer < elementFindRepeatTime)
                        {
                            cWebElement = driver.FindElement(By.CssSelector(objI.IdValue.ToString()));
                            timer = elementFindRepeatTime;
                        }
                    }
                    catch
                    {
                        timer = timer + 1;
                        System.Threading.Thread.Sleep(100);
                    }                    
                    break;
                case "ClassName":
                    objI.jsId = "getElementByClassName(\"";
                    try
                    {
                        while (timer < elementFindRepeatTime)
                        {
                            cWebElement = driver.FindElement(By.ClassName(objI.IdValue.ToString()));
                            timer = elementFindRepeatTime;
                        }
                    }
                    catch
                    {
                        timer = timer + 1;
                        System.Threading.Thread.Sleep(100);
                    }                    
                    break;
                case "Name":
                    //js will not work. generate css
                    objI.jsId = "getElementByName(\"";
                    try
                    {
                        while (timer < elementFindRepeatTime)
                        {
                            cWebElement = driver.FindElement(By.Name(objI.IdValue.ToString()));
                            timer = elementFindRepeatTime;
                        }
                    }
                    catch
                    {
                        timer = timer + 1;
                        System.Threading.Thread.Sleep(100);
                    }                    
                    break;
                case "LinkText":
                    //js will not work. generate css
                    objI.jsId = "querySelector(\"";
                    try
                    {
                        while (timer < elementFindRepeatTime)
                        {
                            cWebElement = driver.FindElement(By.LinkText(objI.IdValue.ToString()));
                            timer = elementFindRepeatTime;
                        }
                    }
                    catch
                    {
                        timer = timer + 1;
                        System.Threading.Thread.Sleep(100);
                    }                    
                    break;
                case "TagName":
                    objI.jsId = "getElementByTagName(\"";
                    try
                    {
                        while (timer < elementFindRepeatTime)
                        {
                            cWebElement = driver.FindElement(By.TagName(objI.IdValue.ToString()));
                            timer = elementFindRepeatTime;
                        }
                    }
                    catch
                    {
                        timer = timer + 1;
                        System.Threading.Thread.Sleep(100);
                    }                    
                    break;
                case "XPath":
                    //js will not work. generate css
                    objI.jsId = "getElementByXPath(\"";
                    try
                    {
                        while (timer < elementFindRepeatTime)
                        {
                            cWebElement = driver.FindElement(By.XPath(objI.IdValue.ToString()));
                            timer = elementFindRepeatTime;
                        }
                    }
                    catch
                    {
                        timer = timer + 1;
                        System.Threading.Thread.Sleep(100);
                    }                    
                    break;
                case "PartialLinkText":
                    //js will not work. generate css
                    objI.jsId = "getElementByPartialLinkText(\"";
                    try
                    {
                        while (timer < elementFindRepeatTime)
                        {
                            cWebElement = driver.FindElement(By.PartialLinkText(objI.IdValue.ToString()));
                            timer = elementFindRepeatTime;
                        }
                    }
                    catch
                    {
                        timer = timer + 1;
                        System.Threading.Thread.Sleep(100);
                    }                    
                    break;                
                default:
                    objI.jsId = "querySelector(\"";
                    cWebElement = null;
                    break;
            }

            return cWebElement;
        }
                
        public bool ElementAction(string ExpectedValue, string ActualValue)
        {
            bool result;
            if (ExpectedValue.Equals(ActualValue))
            {
                result = true;
                spReporter.WriteLine(":Expected Value = " + ExpectedValue + " :Actual Value = " + ActualValue + ":Result = verification passed");
            }

            else
            {
                result = false;
                spReporter.WriteLine(":Expected Value = " + ExpectedValue + " :Actual Value = " + ActualValue + ":Result = verification failed");
                TakeDriverScreenShot(DateTime.Now.ToString("ddMMyyyyHHmmssfff") + ".png");
            }

            return result;
        }

        public void ElementAction(objIdentifier oI, Enum Action)
        {
            ElementAction(oI, Action, "");
        }

        public void ElementAction(objIdentifier oI, Enum action, string ActionValue)
        {
            string StepStartTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:fff");
            IWebElement WebElement = getElement(oI);
                    
            switch (action.ToString())
            {
                case "Click":                                        
                    WebElement.Click();
                    spReporter.WriteLine("Object was " + oI.IdName.ToString() + " Action was " + action.ToString() + " Started at : " + StepStartTime + " Completed at: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:fff"));
                    break;
                case "jsClick":
                    JS = (IJavaScriptExecutor)driver;
                    JS.ExecuteScript("document." + oI.jsId + oI.IdValue + "\").click();");
                    spReporter.WriteLine("Object was " + oI.IdName.ToString() + " Action was " + action.ToString() + " Started at : " + StepStartTime + " Completed at: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:fff"));
                    break;
                case "jsSetText":
                    JS = (IJavaScriptExecutor)driver;
                    JS.ExecuteScript("document." + oI.jsId + oI.IdValue + "\").style.value=\"" + ActionValue + "\";");
                    spReporter.WriteLine("Object was " + oI.IdName.ToString() + " Action was " + action.ToString() + " Started at : " + StepStartTime + " Completed at: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:fff"));
                    break;
                case "Clear":
                    WebElement.Clear();
                    spReporter.WriteLine("Object was " + oI.IdName.ToString() + " Action was " + action.ToString() + "Started at : " + StepStartTime + " Completed at: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:fff"));
                    break;
                case "NavigateToElement":
                    OpenQA.Selenium.Interactions.Actions actions = new OpenQA.Selenium.Interactions.Actions(driver);
                    actions.MoveToElement(WebElement);
                    actions.Perform();
                    spReporter.WriteLine("Object was " + oI.IdName.ToString() + " Action was " + action.ToString() + "Started at : " + StepStartTime + " Completed at: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:fff"));
                    break;
                case "VerifyText":
                    if (WebElement.Text.Equals(ActionValue))
                    {
                        spReporter.WriteLine("Object was " + oI.IdName.ToString() + " Action was " + action.ToString() + "Expected Text = " + ActionValue + " Actual Text = " + WebElement.Text + " Started at : " + StepStartTime + " Completed at: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:fff") + "text verification passed");
                    }
                    else
                    {
                        ProjectDetails["CurrentTestResult"] = "Fail";
                        spReporter.WriteLine("Object was " + oI.IdName.ToString() + " Action was " + action.ToString() + "Expected Text = " + ActionValue + " Actual Text = " + WebElement.Text + " Started at : " + StepStartTime + " Completed at: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:fff") + "text verification failed");
                    }
                    break;
                case "InnerHtml":
                    if (WebElement.Text.Equals(ActionValue))
                    {
                        spReporter.WriteLine("Object was " + oI.IdName.ToString() + " Action was " + action.ToString() + "Expected Text = " + ActionValue + " Actual Text = " + WebElement.Text + " Started at : " + StepStartTime + " Completed at: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:fff") + "text verification passed");
                    }
                    else
                    {
                        ProjectDetails["CurrentTestResult"] = "Fail";
                        spReporter.WriteLine("Object was " + oI.IdName.ToString() + " Action was " + action.ToString() + "Expected Text = " + ActionValue + " Actual Text = " + WebElement.Text + " Started at : " + StepStartTime + " Completed at: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:fff") + "text verification failed");
                    }
                    break;
                case "VerifyContains":
                    if (WebElement.Text.Contains(ActionValue))
                    {
                        spReporter.WriteLine("Object was " + oI.IdName.ToString() + " Action was " + action.ToString() + "Expected Text = " + ActionValue + " Actual Text = " + WebElement.Text + " Started at : " + StepStartTime + " Completed at: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:fff") + "contains verification passed");
                    }
                    else
                    {
                        ProjectDetails["CurrentTestResult"] = "Fail";
                        spReporter.WriteLine("Object was " + oI.IdName.ToString() + " Action was " + action.ToString() + "Expected Text = " + ActionValue + " Actual Text = " + WebElement.Text + " Started at : " + StepStartTime + " Completed at: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:fff") + "contains verification failed");
                    }
                    break;
                case "VerifyTitle":
                    if (driver.Title.Equals(ActionValue))
                    {
                        spReporter.WriteLine("Waiting Object was " + oI.IdName.ToString() + " Action was " + action.ToString() + "Expected Text = " + ActionValue + " Actual Text = " + driver.Title + " Started at : " + StepStartTime + " Completed at: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:fff") + "title verification passed");
                    }
                    else
                    {
                        ProjectDetails["CurrentTestResult"] = "Fail";
                        spReporter.WriteLine("Object was " + oI.IdName.ToString() + " Action was " + action.ToString() + "Expected Text = " + ActionValue + " Actual Text = " + driver.Title + " Started at : " + StepStartTime + " Completed at: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:fff") + "title verification failed");
                    }
                    break;
                case "SendKeys":
                    WebElement.SendKeys(ActionValue);
                    spReporter.WriteLine("Object was " + oI.IdName.ToString() + " Action was " + action.ToString() + " Value is " + ActionValue + " Started at : " + StepStartTime + " Completed at: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:fff"));
                    break;
                case "ClearAndSendKeys":
                    WebElement.Clear();
                    WebElement.SendKeys(ActionValue);
                    spReporter.WriteLine("Object was " + oI.IdName.ToString() + " Action was " + action.ToString() + " Value is " + ActionValue + " Started at : " + StepStartTime + " Completed at: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:fff"));
                    break;
                case "ClearAndSendKeysAndTab":
                    WebElement.Clear();
                    WebElement.SendKeys(ActionValue);
                    WebElement.SendKeys(Keys.Tab);
                    spReporter.WriteLine("Object was " + oI.IdName.ToString() + " Action was " + action.ToString() + " Value is " + ActionValue + " Started at : " + StepStartTime + " Completed at: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:fff"));
                    break;
                case "SelectByIndex":                    
                    new SelectElement(WebElement).SelectByIndex(Int32.Parse(ActionValue));
                    System.Threading.Thread.Sleep(250);
                    spReporter.WriteLine("Object was " + oI.IdName.ToString() + " Action was " + action.ToString() + "Started at : " + StepStartTime + " Completed at: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:fff") + " Action was SelectByText(" + ActionValue + ")");
                    break;
                case "SelectByText":
                    new SelectElement(WebElement).SelectByText(ActionValue);
                    System.Threading.Thread.Sleep(250);
                    spReporter.WriteLine("Object was " + oI.IdName.ToString() + " Action was " + action.ToString() + "Started at : " + StepStartTime + " Completed at: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:fff") + " Action was SelectByText(" + ActionValue + ")");
                    break;
                case "SelectByValue":
                    new SelectElement(WebElement).SelectByValue(ActionValue);
                    System.Threading.Thread.Sleep(250);
                    spReporter.WriteLine("Object was " + oI.IdName.ToString() + " Action was " + action.ToString() + "Started at : " + StepStartTime + " Completed at: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:fff") + " Action was SelectByText(" + ActionValue + ")");
                    break;
                case "SetProperty":
                    JS = (IJavaScriptExecutor)driver;
                    JS.ExecuteScript("document."+ oI.jsId + oI.IdValue + "\").style." + oI.IdProperty + "=\"" + oI.IdPropertyValue + "\";");                    
                    spReporter.WriteLine("Object was " + oI.IdName.ToString() + " Action was " + action.ToString() + " Started at : " + StepStartTime + " Completed at: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:fff"));
                    break;
                case "Check":
                    try
                    {
                        if (!WebElement.GetAttribute("checked").Equals("true"))
                        {
                            WebElement.Click();
                        }
                    }
                    catch { }
                    spReporter.WriteLine("Started at : " + StepStartTime + " Completed at: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:fff") + " Action was Checked(" + ActionValue + ")");
                    break;
                case "Displayed":
                    int synccounter = 0;
                    while (!WebElement.Displayed)
                    {
                        System.Threading.Thread.Sleep(100);
                        synccounter = synccounter + 1;
                        if (synccounter > 5)
                        {
                            ActionValue = "Not Displayed";
                            break;
                        }
                    }
                    spReporter.WriteLine("Object was " + oI.IdName.ToString() + " Action was " + action.ToString() + "Started at : " + StepStartTime + " Completed at: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:fff") + " Action was CheckDisplayed(" + ActionValue + ")");
                    break;
                case "WaitResolveStaleElementAndClick":
                    for (int i = 0; i < 60; i++)
                    {
                        try
                        {
                            WebElement.Click();
                            i = 60;
                        }
                        catch (Exception e)
                        {
                            if (e.Message.Contains("stale element"))
                            {
                                System.Threading.Thread.Sleep(100);
                                WebElement = getElement(oI);
                            }
                            else { i = 60; }
                        }
                    }                    
                    spReporter.WriteLine("Object was " + oI.IdName.ToString() + " Action was " + action.ToString() + " Started at : " + StepStartTime + " Completed at: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:fff"));
                    break;
                case "Uncheck":
                    WebElement.Click();
                    spReporter.WriteLine("Object was " + oI.IdName.ToString() + " Action was " + action.ToString() + "Started at : " + StepStartTime + " Completed at: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:fff") + " Action was Uncheck(" + ActionValue + ")");
                    break;
                case "ClickHandleModal":
                    WebElement.Click();
                    spReporter.WriteLine("Object was " + oI.IdName.ToString() + " Action was " + action.ToString() + "Started at : " + StepStartTime + " Completed at: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:fff") + " Action was ClickHandleModal() ");
                    break;
                case "Submit":
                    WebElement.Submit();
                    spReporter.WriteLine("Object was " + oI.IdName.ToString() + " Action was " + action.ToString() + "Started at : " + StepStartTime + " Completed at: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:fff") + " Action was ClickHandleModal() ");
                    break;
                default:
                    break;
            }
        }

        #endregion


        #region Suppliementary Selenium methods
        public DataTable getWebHtmlTable(objIdentifier obj)
        {
            DataTable dt = new DataTable();
            IWebElement iElement = getElement(obj);
            IList<IWebElement> trElement = iElement.FindElements(By.TagName("tr"));
            IList<IWebElement> thElement = iElement.FindElements(By.TagName("th"));
            int counter = 0;
            foreach (IWebElement idc in thElement)
            {
                dt.Columns.Add(idc.Text, typeof(string));
            }

            foreach (IWebElement idr in trElement)
            {
                if (counter != 0)
                {
                    int colindex = 0;
                    DataRow dr = dt.NewRow();
                    foreach (IWebElement dc in idr.FindElements(By.TagName("td")))
                    {
                        dr[colindex] = dc.Text;
                        colindex++;
                    }
                    dt.Rows.Add(dr);     
                }
                
                counter++;
            }

            return dt;
        }
        #endregion

        #region Screenshot Capture
        public void TakeDriverScreenShot(string fileName)
        {
            OpenQA.Selenium.Screenshot sc = new Screenshot(Convert.ToBase64String(new byte[] { }));
            try
            {
                switch (ProjectDetails["BrowserType"])
                {
                    case "1":
                        sc = ((FirefoxDriver)driver).GetScreenshot();
                        break;
                    case "2":
                        sc = ((InternetExplorerDriver)driver).GetScreenshot();
                        break;
                    case "3":
                        sc = ((ChromeDriver)driver).GetScreenshot();
                        break;
                    case "4":
                        sc = ((ITakesScreenshot)driver).GetScreenshot();
                        break;
                    default:
                        sc = ((FirefoxDriver)driver).GetScreenshot();
                        break;
                }
                sc.SaveAsFile(ProjectDetails["TestResultFolder"] + "\\" + fileName);                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

        #endregion
    }

    public class objIdentifier
    {
        public string IdName { get; set; }
        public string IdType { get; set; }
        public string IdValue { get; set; }
        public string IdProperty { get; set; }
        public string IdPropertyValue { get; set; }
        public string jsId { get; set; }
        public objIdentifier(string idName, string idType, string idValue)
        {
            IdName = idName;
            IdType = idType;
            IdValue = idValue;
        }
        public objIdentifier(string idType, string idValue)
        {            
            IdType = idType;
            IdValue = idValue;
        }
    }
}

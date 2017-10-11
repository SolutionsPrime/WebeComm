using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Data;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommSite.SolutionsPrime;

namespace eCommSite.Scripts
{
    public enum iTypes { Id, Name, CssSelector, XPath, TagName, LinkText, Link }

    public class Register : spWrapper
    {
        public objIdentifier ObjSignInBtn = new objIdentifier("ObjSignInBtn", iTypes.CssSelector.ToString(), ".login");
        public objIdentifier ObjemailAddressTxt = new objIdentifier("ObjemailAddressTxt", iTypes.Id.ToString(), "email_create");
        public objIdentifier ObjcreateAccountBtn = new objIdentifier("ObjcreateAccountBtn", iTypes.Id.ToString(), "SubmitCreate");
        public objIdentifier ObjMrRbtn = new objIdentifier("ObjMrRbtn", iTypes.Id.ToString(), "id_gender1");
        public objIdentifier ObjMrsRbtn = new objIdentifier("ObjMrsRbtn", iTypes.Id.ToString(), "id_gender2");
        public objIdentifier ObjCustNameTxt = new objIdentifier("ObjCustNameTxt", iTypes.Id.ToString(), "customer_firstname");
        public objIdentifier ObjLastNameTxt = new objIdentifier("ObjLastNameTxt", iTypes.Id.ToString(), "customer_lastname");
        public objIdentifier ObjemailAddressExtTxt = new objIdentifier("ObjemailAddressVyTxt", iTypes.Id.ToString(), "email");
        public objIdentifier ObjPasswordTxt = new objIdentifier("ObjPasswordTxt", iTypes.Id.ToString(), "passwd");
        public objIdentifier ObjDOBddSel = new objIdentifier("ObjDOBddSel", iTypes.Id.ToString(), "days");
        public objIdentifier ObjDOBmmSel = new objIdentifier("ObjDOBmmSel", iTypes.Id.ToString(), "months");
        public objIdentifier ObjDOByyyySel = new objIdentifier("ObjDOByyyySel", iTypes.Id.ToString(), "years");
        public objIdentifier ObjSignUpNewsLetter = new objIdentifier("ObjSignUpNewsLetter", iTypes.Id.ToString(), "newsletter");
        public objIdentifier ObjOptin = new objIdentifier("ObjOptin", iTypes.Id.ToString(), "optin");
        public objIdentifier ObjFirstName = new objIdentifier("ObjFirstName", iTypes.Id.ToString(), "firstname");
        public objIdentifier ObjLastName = new objIdentifier("ObjLastName", iTypes.Id.ToString(), "lastname");
        public objIdentifier ObjCompany = new objIdentifier("ObjCompany", iTypes.Id.ToString(), "company");
        public objIdentifier ObjAddressL1 = new objIdentifier("ObjAddressL1", iTypes.Id.ToString(), "address1");
        public objIdentifier ObjAddressL2 = new objIdentifier("ObjAddressL2", iTypes.Id.ToString(), "address2");
        public objIdentifier ObjCity = new objIdentifier("ObjCity", iTypes.Id.ToString(), "city");
        public objIdentifier ObjState = new objIdentifier("ObjState", iTypes.Id.ToString(), "id_state");
        public objIdentifier ObjPostCode = new objIdentifier("ObjPostCode", iTypes.Id.ToString(), "postcode");
        public objIdentifier ObjCountry = new objIdentifier("ObjCountry", iTypes.Id.ToString(), "country");
        public objIdentifier ObjAdditionalInfo = new objIdentifier("ObjAdditionalInfo", iTypes.Id.ToString(), "other");
        public objIdentifier ObjPhone = new objIdentifier("ObjPhone", iTypes.Id.ToString(), "phone");
        public objIdentifier ObjMobile = new objIdentifier("ObjMobile", iTypes.Id.ToString(), "phone_mobile");
        public objIdentifier ObjAlias = new objIdentifier("ObjAlias", iTypes.Id.ToString(), "alias");
        public objIdentifier ObjRegisterBtn = new objIdentifier("ObjRegisterBtn", iTypes.Id.ToString(), "submitAccount");
        public objIdentifier ObjSubmitLoginBtn = new objIdentifier("ObjSubmitLoginBtn", iTypes.Id.ToString(), "SubmitLogin");
        public objIdentifier ObjWindowTitle = new objIdentifier("ObjWindowTitle", iTypes.TagName.ToString(), "title");

        public objIdentifier ObjMenuWoman = new objIdentifier("ObjMenuWoman", iTypes.CssSelector.ToString(), "a.sf-with-ul");

        public objIdentifier ObjColorWhite = new objIdentifier("ObjColorWhite", iTypes.Id.ToString(), "color_8");
        public objIdentifier ObjColorYellow = new objIdentifier("ObjColorYellow", iTypes.Id.ToString(), "color_16");
        public objIdentifier ObjColorPink = new objIdentifier("ObjColorPink", iTypes.Id.ToString(), "color_24");
        public objIdentifier ObjColorBlack = new objIdentifier("ObjColorBlack", iTypes.Id.ToString(), "color_11");
        public objIdentifier ObjColorBlue = new objIdentifier("ObjColorBlue", iTypes.Id.ToString(), "color_13");
        public objIdentifier ObjColorBeige = new objIdentifier("ObjColorBeige", iTypes.Id.ToString(), "color_7");
        public objIdentifier ObjColorOrange = new objIdentifier("ObjColorOrange", iTypes.Id.ToString(), "color_14");

        public objIdentifier ObjItemSize = new objIdentifier("ObjItemSize", iTypes.Id.ToString(), "group_1");

        public objIdentifier ObjAddCart = new objIdentifier("ObjAddCart", iTypes.CssSelector.ToString(), ".exclusive");
        public objIdentifier ObjContinueShopping = new objIdentifier("ObjContinueShopping", iTypes.CssSelector.ToString(), ".continue.btn.btn-default.button.exclusive-medium>span");

        public objIdentifier ObjCart = new objIdentifier("ObjCart", iTypes.CssSelector.ToString(), ".shopping_cart>a");
        public objIdentifier ObjCartTotalProducts = new objIdentifier("ObjCartTotalProducts", iTypes.Id.ToString(), "total_product");
        public objIdentifier ObjCartTotalShipping = new objIdentifier("ObjCartTotalShipping", iTypes.Id.ToString(), "total_shipping");
        public objIdentifier ObjCartTotalWithoutTax = new objIdentifier("ObjCartTotalWithoutTax", iTypes.Id.ToString(), "total_price_without_tax");
        public objIdentifier ObjCartTotalTax = new objIdentifier("ObjCartTotalTax", iTypes.Id.ToString(), "total_tax");
        public objIdentifier ObjCartTotal = new objIdentifier("ObjCartTotal", iTypes.Id.ToString(), "total_price");

        public objIdentifier ObjProceedToCheckOutSC = new objIdentifier("ObjProceedToCheckOutSC", iTypes.CssSelector.ToString(), ".button.btn.btn-default.standard-checkout.button-medium>span");
        public objIdentifier ObjProceedToCheckOutDA = new objIdentifier("ObjProceedToCheckOutDA", iTypes.Name.ToString(), "processAddress");
        public objIdentifier ObjAgreeToS = new objIdentifier("ObjAgreeToS", iTypes.Id.ToString(), "cgv");
        public objIdentifier ObjProceedToCheckOutToS = new objIdentifier("ObjProceedToCheckOutToS", iTypes.CssSelector.ToString(), ".button.btn.btn-default.standard-checkout.button-medium");
        public objIdentifier ObjBankWire = new objIdentifier("ObjBankWire", iTypes.CssSelector.ToString(), ".bankwire");
        public objIdentifier ObjConfirmOrder = new objIdentifier("ObjConfirmOrder", iTypes.CssSelector.ToString(), "#cart_navigation>button");

        public objIdentifier ObjOrderSuccessMsg = new objIdentifier("ObjOrderSuccessMsg", iTypes.CssSelector.ToString(), ".dark");

        public objIdentifier ObjOrderHistory = new objIdentifier("ObjOrderHistory", iTypes.CssSelector.ToString(), "a[title='Orders']");
        public objIdentifier ObjOrderHistoryTable = new objIdentifier("ObjOrderHistoryTable", iTypes.CssSelector.ToString(), "#order-list");
        public objIdentifier ObjReorder = new objIdentifier("ObjReorder", iTypes.CssSelector.ToString(), "#submitReorder");
        public objIdentifier ObjOrderMessageTxt = new objIdentifier("ObjOrderMessageTxt", iTypes.CssSelector.ToString(), "textarea[name='msgText']");
        public objIdentifier ObjSendBtn = new objIdentifier("", iTypes.CssSelector.ToString(), "button.btn.btn-default.button-medium");
        public objIdentifier ObjAlertSuccess = new objIdentifier("ObjAlertSuccess", iTypes.CssSelector.ToString(), ".alert.alert-success");

        public Register()
        {            

        }

        public void QuickViewProduct(string ProductId,string ProducName, string ProductImg)
        {
            objIdentifier ObjQuickView = new objIdentifier("QuickView",iTypes.CssSelector.ToString(), "a[rel='http://automationpractice.com/index.php?id_product=" + ProductId + "&controller=product'][class='quick-view']");
            objIdentifier ObjImgView = new objIdentifier("ObjImgView",iTypes.CssSelector.ToString(),  "img[src='"+ ProductImg + "'][title='" + ProducName + "']");
            try
            {
                //IWebElement awe = driver.FindElement(By.CssSelector(imgView));
                //OpenQA.Selenium.Interactions.Actions actions = new OpenQA.Selenium.Interactions.Actions(driver);
                //actions.MoveToElement(awe);
                //actions.Perform();
                ElementAction(ObjImgView, eActions.NavigateToElement);
            }
            catch(Exception e)
            {
                Console.Write(e.Message);
            }
            ElementAction(ObjQuickView, eActions.jsClick);
            //driver.FindElement(By.CssSelector(quickView)).jsClick();


            //IList<IWebElement> iwe = driver.FindElements(By.ClassName("product-container"));
            //foreach (IWebElement we in iwe)
            //{
            //    if(we.FindElement(By.CssSelector("a[href='http://automationpractice.com/index.php?id_product=6&controller=product']")).GetAttribute("title").Equals("Printed Summer Dress"))
            //    {
            //        we.FindElement(By.ClassName("quick-view")).Click();
            //    }
            //}
        }
        public void registerAccount()
        {
            ElementAction(ObjSignInBtn,eActions.VerifyTitle,"My Store");
            ElementAction(ObjSignInBtn, eActions.jsClick);            
            ElementAction(ObjemailAddressTxt,eActions.VerifyTitle,"Login - My Store");
            ProjectDetails["UserName"] = "abi" + new Random().Next(10000) + "@abi.com";
            ElementAction(ObjemailAddressTxt, eActions.ClearAndSendKeys, ProjectDetails["UserName"].ToString());            
            try
            {
                if (ProjectDetails["BrowserType"].Equals("2"))
                {
                    if (driver.FindElement(By.CssSelector("#create_account_error")).GetAttribute("class").Contains("alert-danger"))
                    {
                        getElement(ObjemailAddressTxt).SendKeys(Keys.Tab);
                        getElement(ObjemailAddressTxt).SendKeys(Keys.Enter);
                    }
                }
                else
                {
                    ElementAction(ObjcreateAccountBtn, eActions.Click);
                }
            }
            catch { }
            
            ElementAction(ObjMrRbtn, eActions.jsClick);
            ElementAction(ObjCustNameTxt, eActions.ClearAndSendKeys, "Abishai");
            ElementAction(ObjLastNameTxt,eActions.ClearAndSendKeys, "Tester");
            ElementAction(ObjPasswordTxt, eActions.SendKeys, "BJSSTest");
            ElementAction(ObjDOBddSel, eActions.SelectByValue, "18");
            ElementAction(ObjDOBmmSel, eActions.SelectByValue, "8");
            ElementAction(ObjDOByyyySel, eActions.SelectByValue, "1999");
            ElementAction(ObjSignUpNewsLetter, eActions.jsClick);
            ElementAction(ObjOptin, eActions.jsClick);
            ElementAction(ObjCompany, eActions.ClearAndSendKeys, "sp");
            ElementAction(ObjAddressL1, eActions.ClearAndSendKeys, "12 road");
            ElementAction(ObjAddressL2, eActions.ClearAndSendKeys, "Mill Valley");
            ElementAction(ObjCity, eActions.ClearAndSendKeys, "Sanfrancisco");
            ElementAction(ObjState, eActions.SelectByText, "California");
            ElementAction(ObjPostCode, eActions.ClearAndSendKeys, "98789");
            ElementAction(ObjMobile, eActions.ClearAndSendKeys, "123456790");
            ElementAction(ObjAlias, eActions.ClearAndSendKeys, "com-add1");
            ElementAction(ObjRegisterBtn, eActions.jsClick);
        }

        public void verifyRegisterAccount()
        {
            ElementAction(ObjOrderHistory, eActions.VerifyTitle,"My account - My Store");
            ProjectDetails["LoggedIn"] = "true";
        }

        public void Login()
        {
            if (ProjectDetails["BrowserInitiated"].Equals("false"))
            {
                spWrapper.ProjectDetails["BaseStateURL"] = "http://automationpractice.com/";
                initBrowser(true, spWrapper.BrowserType.Chrome);
            }
        }
        public void Login(Table table)
        {
            Login();

            if (ProjectDetails["LoggedIn"].Equals("false"))
            {                
                var userDetails = table.CreateDynamicSet();
                foreach (var user in userDetails)
                {
                    spWrapper.ProjectDetails["UserName"] = user.UserName;
                    spWrapper.ProjectDetails["Password"] = user.Password;
                    //break; not needed as we have only one record.                                
                }
                //string un, pwd;
                //table.Rows[0].TryGetValue("UserName", out un);
                //table.Rows[0].TryGetValue("Password", out pwd);
                //spWrapper.ProjectDetails["UserName"] = un;
                //spWrapper.ProjectDetails["Password"] = pwd;

                ElementAction(ObjSignInBtn,eActions.VerifyTitle,"My Store");
                ElementAction(ObjSignInBtn, eActions.jsClick);
                ElementAction(ObjemailAddressExtTxt,eActions.VerifyTitle,"Login - My Store");
                ElementAction(ObjemailAddressExtTxt, eActions.ClearAndSendKeysAndTab, spWrapper.ProjectDetails["UserName"]);
                ElementAction(ObjPasswordTxt, eActions.ClearAndSendKeysAndTab, spWrapper.ProjectDetails["Password"]);
                ElementAction(ObjSubmitLoginBtn, eActions.jsClick);
                ElementAction(ObjOrderHistory,eActions.VerifyTitle,"My account - My Store");
            }

        }

        public void QuickViewAddItem(ItemInfo table)
        {
        
            ElementAction(ObjMenuWoman, eActions.jsClick);          
            QuickViewProduct(table.ItemId.ToString(), table.ItemName, table.ImgUrl);
            if (!ProjectDetails["BrowserType"].Equals("2"))
            {
                driver.SwitchTo().Frame(driver.FindElement(By.TagName("iframe")));
            }
            switch (table.ItemSize.ToString().ToUpper())
            {
                case "SHORT":
                    ElementAction(ObjItemSize, eActions.SelectByValue, "1");
                    break;
                case "MEDIUM":
                    ElementAction(ObjItemSize, eActions.SelectByValue, "2");
                    break;
                case "LONG":
                    ElementAction(ObjItemSize, eActions.SelectByValue, "3");
                    break;
                default:
                    break;
            }

            switch (table.ItemColour.ToString().ToUpper())
            {
                case "YELLOW":
                    ElementAction(ObjColorYellow, eActions.Click);                    
                    break;
                case "WHITE":
                    ElementAction(ObjColorWhite, eActions.Click);
                    break;
                case "PINK":
                    ElementAction(ObjColorPink, eActions.Click);
                    break;
                case "BEIGE":
                    ElementAction(ObjColorBeige, eActions.Click);
                    break;
                case "BLACK":
                    ElementAction(ObjColorBlack, eActions.Click);
                    break;
                case "BLUE":
                    ElementAction(ObjColorBlue, eActions.Click);
                    break;
                case "ORANGE":
                    ElementAction(ObjColorOrange, eActions.Click);
                    break;
                default:
                    break;
            }

            ElementAction(ObjAddCart, eActions.Click);
            ElementAction(ObjContinueShopping, eActions.WaitResolveStaleElementAndClick);            
        }

        public void verifyShoppingCart()
        {
            try
            {
                ElementAction(ObjCart, eActions.Click);
                ElementAction(ObjCartTotalProducts, eActions.VerifyText, "$81.49");
                ElementAction(ObjCartTotalShipping, eActions.VerifyText, "$2.00");
                ElementAction(ObjCartTotalWithoutTax, eActions.VerifyText, "$83.49");
                ElementAction(ObjCartTotalTax, eActions.VerifyText, "$0.00");                
                ElementAction(ObjCartTotal, eActions.VerifyText, "$83.49");
                
                //ElementAction(ObjProceedToCheckOutSC, eActions.Click);
                //ElementAction(ObjProceedToCheckOutDA, eActions.Click);
                //ElementAction(ObjAgreeToS, eActions.Click);
                //ElementAction(ObjProceedToCheckOutToS, eActions.Click);

                //ElementAction(ObjCartTotalProducts, eActions.VerifyText, "$81.49");
                //ElementAction(ObjCartTotalShipping, eActions.VerifyText, "$2.00");
                //ElementAction(ObjCartTotal, eActions.VerifyText, "$83.49");
                //ElementAction(ObjBankWire, eActions.Click);
                //ElementAction(ObjConfirmOrder, eActions.NavigateToElement);
                //ElementAction(ObjConfirmOrder, eActions.Click);
               
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception " + e.Message);
            }
        }

        public void ProceedCheckOutDA(Table tablle)
        {
            ElementAction(ObjProceedToCheckOutSC, eActions.Click);
            // not implemented shipping options verfications
        }

        public void ProceedCheckOutTos()
        {
            ElementAction(ObjProceedToCheckOutDA, eActions.Click);
            ElementAction(ObjAgreeToS, eActions.Click);
            ElementAction(ObjProceedToCheckOutToS, eActions.Click);
        }

        public void BankWire()
        {
            ElementAction(ObjCartTotalProducts, eActions.VerifyText, "$81.49");
            ElementAction(ObjCartTotalShipping, eActions.VerifyText, "$2.00");
            ElementAction(ObjCartTotal, eActions.VerifyText, "$83.49");
            ElementAction(ObjBankWire, eActions.Click);
            ElementAction(ObjConfirmOrder, eActions.NavigateToElement);
            ElementAction(ObjConfirmOrder, eActions.Click);
        }

        public void VerifyOrderSuccess()
        {
            ElementAction(ObjOrderSuccessMsg, eActions.VerifyText, "Your order on My Store is complete.");
        }

        public void VerifyPreviousOrders(Table table)
        {
            try
            {
                if (!driver.Url.Contains("controller=my-account"))
                {
                    driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=my-account");
                }
                ElementAction(ObjOrderHistory, eActions.jsClick);
                
                DataTable orderhistory = getWebHtmlTable(ObjOrderHistoryTable);
                foreach(TableRow tr in table.Rows)
                {
                    spReporter.WriteLine("table row order # at = " + ((string[])tr.Values)[0]);
                    foreach (DataRow tdr in orderhistory.Rows)
                    {
                        
                        if (((string[])tr.Values)[0].Equals(tdr[0].ToString()))
                        {
                            ElementAction(((string[])tr.Values)[1], tdr[1].ToString());
                            ElementAction(((string[])tr.Values)[2], tdr[2].ToString());
                            ElementAction(((string[])tr.Values)[3], tdr[3].ToString());
                            ElementAction(((string[])tr.Values)[4], tdr[4].ToString());
                          
                            ElementAction(new objIdentifier("Order " + ((string[])tr.Values)[6], iTypes.CssSelector.ToString(), "a[href*='"+ ((string[])tr.Values)[6] + "']"), eActions.jsClick);
                            System.Threading.Thread.Sleep(6000);
                            ElementAction(ObjOrderMessageTxt, eActions.SendKeys, ((string[])tr.Values)[5]);
                            ElementAction(ObjSendBtn, eActions.jsClick);                            
                            ElementAction(ObjAlertSuccess, eActions.VerifyText, "Message successfully sent");                            
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Write("");
        }
      
    }
}


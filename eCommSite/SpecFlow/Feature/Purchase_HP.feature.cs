﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.2.0.0
//      SpecFlow Generator Version:2.2.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace eCommSite.SpecFlow.Feature
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class Purchase_HPFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "Purchase_HP.feature"
#line hidden
        
        public virtual Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext
        {
            get
            {
                return this._testContext;
            }
            set
            {
                this._testContext = value;
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            eCommSite.SolutionsPrime.spWrapper.RunTestContext = testContext;
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Purchase_HP", "\tPurchase 2 Items\r\n\r\n/*\r\nThese are comments\r\n\r\n*/", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Purchase_HP")))
            {
                global::eCommSite.SpecFlow.Feature.Purchase_HPFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Microsoft.VisualStudio.TestTools.UnitTesting.TestContext>(TestContext);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify user registration")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Purchase_HP")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mytag")]
        public virtual void VerifyUserRegistration()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify user registration", new string[] {
                        "mytag"});
#line 9
this.ScenarioSetup(scenarioInfo);
#line 10
 testRunner.Given("I open the website in Chrome", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 11
 testRunner.When("I register in the website", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
 testRunner.Then("System must create an account on the website", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the system supports the purchase of items")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Purchase_HP")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mytag")]
        public virtual void VerifyTheSystemSupportsThePurchaseOfItems()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the system supports the purchase of items", new string[] {
                        "mytag"});
#line 16
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "UserName",
                        "Password"});
            table1.AddRow(new string[] {
                        "abi3520@abi.com",
                        "BJSSTest"});
#line 17
 testRunner.Given("I login to website successfully for which System displays the available items", ((string)(null)), table1, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "ItemId",
                        "ItemName",
                        "ItemSize",
                        "ItemColour",
                        "Currency",
                        "ItemPrice",
                        "ItemQuantity",
                        "ImgUrl"});
            table2.AddRow(new string[] {
                        "6",
                        "Printed Summer Dress",
                        "Medium",
                        "Yellow",
                        "$",
                        "30.50",
                        "1",
                        "http://automationpractice.com/img/p/1/6/16-home_default.jpg"});
            table2.AddRow(new string[] {
                        "4",
                        "Printed Dress",
                        "Default",
                        "Pink",
                        "$",
                        "50.99",
                        "1",
                        "http://automationpractice.com/img/p/1/0/10-home_default.jpg"});
#line 20
 testRunner.When("I quick view item, change the Item size, Add the item to the shopping cart, for w" +
                    "hich System displays quick form with Product successfully added to shopping cart" +
                    "", ((string)(null)), table2, "When ");
#line 24
 testRunner.And("I Check out and verify the shopping cart information", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "ShippingType",
                        "ShippingValue"});
            table3.AddRow(new string[] {
                        "Delivery Next Day",
                        "2.00"});
#line 25
 testRunner.And("I proceed for checkout, see delivery address saved as aliases, continue Checkout " +
                    "to shipping options", ((string)(null)), table3, "And ");
#line 28
 testRunner.And("I Agree the terms of service, continue to proceed checkout, verify the cart infor" +
                    "mation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.And("I pay by bank wire, confirm order", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.Then("system displays the order is complete message along with the order details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Review previous orders and add a message")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Purchase_HP")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mytag")]
        public virtual void ReviewPreviousOrdersAndAddAMessage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Review previous orders and add a message", new string[] {
                        "mytag"});
#line 33
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "UserName",
                        "Password"});
            table4.AddRow(new string[] {
                        "abi3520@abi.com",
                        "BJSSTest"});
#line 34
    testRunner.Given("Afer I login to website, I view previous orders", ((string)(null)), table4, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Order Reference",
                        "Order Date",
                        "Total Price",
                        "Payments",
                        "Status",
                        "Comment",
                        "OrderNo"});
            table5.AddRow(new string[] {
                        "RAIVIACLK",
                        "10/07/2017",
                        "$63.00",
                        "Bank wire",
                        "Awaiting bank wire payment",
                        "nearest to leisure center",
                        "21035"});
            table5.AddRow(new string[] {
                        "IBUJSGQUM",
                        "10/09/2017",
                        "$83.49",
                        "Bank wire",
                        "On backorder",
                        "adding more notes for test",
                        "21116"});
#line 37
 testRunner.When("I verify and select an item from the previous orders and add a comment", ((string)(null)), table5, "When ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "From",
                        "Message"});
            table6.AddRow(new string[] {
                        "Abishai Tester",
                        "nearest to leisure center"});
#line 41
 testRunner.Then("the system confirms that the comment was Successfully sent", ((string)(null)), table6, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using eCommSite.SolutionsPrime;
using eCommSite.Scripts;

namespace eCommSite.SpecFlow.StepDefinition
{
    [Binding]
    public class Purchase_HPSteps :Steps
    {
        
        Register regis = new Register();

        [Given(@"I open the website in Chrome")]
        public void GivenIOpenTheWebsiteInChrome()
        {
            regis.Login();            
        }

        [When(@"I register in the website")]
        public void WhenIRegisterInTheWebsite()
        {
            regis.registerAccount();
        }

        [Then(@"System must create an account on the website")]
        public void ThenSystemMustCreateAnAccountOnTheWebsite()
        {
            regis.verifyRegisterAccount();
        }

        [Given(@"I login to website successfully for which System displays the available items")]
        public void GivenILoginToWebsiteSuccessfullyForWhichSystemDisplaysTheAvailableItems(Table table)
        {            
            regis.Login(table);
        }

        [When(@"I quick view item, change the Item size, Add the item to the shopping cart, for which System displays quick form with Product successfully added to shopping cart")]
        public void WhenIQuickViewItemChangeTheItemSizeAddTheItemToTheShoppingCartForWhichSystemDisplaysQuickFormWithProductSuccessfullyAddedToShoppingCart(Table table)
        {
            var addProduct = table.CreateSet<ItemInfo>();
            foreach (ItemInfo product in addProduct)
            {
                regis.QuickViewAddItem(product);
            }
        }

        [When(@"I Check out and verify the shopping cart information")]
        public void WhenICheckOutAndVerifyTheShoppingCartInformation()
        {
            regis.verifyShoppingCart();
        }

        [When(@"I proceed for checkout, see delivery address saved as aliases, continue Checkout to shipping options")]
        public void WhenIProceedForCheckoutSeeDeliveryAddressSavedAsAliasesContinueCheckoutToShippingOptions(Table table)
        {
            regis.ProceedCheckOutDA(table);
        }     

        [When(@"I Agree the terms of service, continue to proceed checkout, verify the cart information")]
        public void WhenIAgreeTheTermsOfServiceContinueToProceedCheckoutVerifyTheCartInformation()
        {
            regis.ProceedCheckOutTos();
        }
        [When(@"I pay by bank wire, confirm order")]
        public void WhenIPayByBankWireConfirmOrder()
        {
            regis.BankWire();
        }

        [Then(@"system displays the order is complete message along with the order details")]
        public void ThenSystemDisplaysTheOrderIsCompleteMessageAlongWithTheOrderDetails()
        {
            
        }
        
        [Given(@"Afer I login to website, I view previous orders")]
        public void GivenAferILoginToWebsiteIViewPreviousOrders(Table table)
        {
            // Calling  existing step
            Given("I login to website successfully for which System displays the available items",table);
        }


        [When(@"I verify and select an item from the previous orders and add a comment")]
        public void WhenIVerifyAndSelectAnItemFromThePreviousOrdersAndAddAComment(Table table)
        {
            regis.VerifyPreviousOrders(table);
        }

        [Then(@"the system confirms that the comment was Successfully sent")]
        public void ThenTheSystemConfirmsThatTheCommentWasSuccessfullySent(Table table)
        {
           
        }



    }
}

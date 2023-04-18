using commands.pageObjects;
using tests.Support;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using commands.selenium;

namespace tests.StepDefinitions
{
    [Binding]
    public class SwagLabsStepDefinitions
    {
        ISpecFlowOutputHelper _specFlowOutputHelper;

        public SwagLabsStepDefinitions(ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _specFlowOutputHelper = specFlowOutputHelper;
        }

        [Given(@"a shopping website navigated through '([^']*)' url")]
        public void GivenAShoppingWebsiteNavigatedThroughUrl(string p0)
        {
            try
            {
                SeleniumWebDriver.RootURL = @$"{p0}";
                SeleniumWebDriver.goToURL();
            }
            catch (Exception e)
            {
                _specFlowOutputHelper.addErrorLog(e);
                throw;
            }
        }


        [Given(@"I am logged as '([^']*)' with password '([^']*)' in the products page")]
        public void GivenIAmLoggedAsWithPasswordInTheProductsPage(string p0, string p1)
        {
            try
            {
                var loginPage = new LoginPage();
                var inventoryPage = loginPage.login(p0, p1);
            }
            catch (Exception e)
            {
                _specFlowOutputHelper.addErrorLog(e);
                throw;
            }
        }

        [When(@"I sort the products by '([^']*)'")]
        public void WhenISortTheProductsBy(string p0)
        {
            try
            {
                var inventoryPage = new InventoryPage();
                inventoryPage.sortProductsBy(p0);
            }
            catch (Exception e)
            {
                _specFlowOutputHelper.addErrorLog(e);
                throw;
            }
        }

        [When(@"I click in '([^']*)' product")]
        public void WhenIClickInProduct(string p0)
        {
            try
            {
                var inventoryPage = new InventoryPage();
                var inventoryItemPage = inventoryPage.clickProduct(p0);
            }
            catch (Exception e)
            {
                _specFlowOutputHelper.addErrorLog(e);
                throw;
            }
        }

        [Then(@"the '([^']*)' product description should be '([^']*)'")]
        public void ThenTheProductDescriptionShouldBe(string p0, string p1)
        {
            try
            {
                var inventoryItemPage = new InventoryItemPage();
                inventoryItemPage.assertProductTitle(p0);
                inventoryItemPage.assertProductDescription(p1);
            }
            catch (Exception e)
            {
                _specFlowOutputHelper.addErrorLog(e);
                throw;
            }
        }

        [When(@"I add '([^']*)' product to the cart")]
        public void WhenIAddProductToTheCart(string p0)
        {
            try
            {
                var inventoryPage = new InventoryPage();
                inventoryPage.addToCart(p0);
            }
            catch (Exception e)
            {
                _specFlowOutputHelper.addErrorLog(e);
                throw;
            }
        }

        [When(@"I click on the cart")]
        public void WhenIClickOnTheCart()
        {
            try
            {
                var inventoryPage = new InventoryPage();
                var cartPage = inventoryPage.goToCart();
            }
            catch (Exception e)
            {
                _specFlowOutputHelper.addErrorLog(e);
                throw;
            }
        }

        [When(@"I proceed to checkout")]
        public void WhenIProceedToCheckout()
        {
            try
            {
                var cartPage = new CartPage();
                var checkout = cartPage.goToCheckout();
            }
            catch (Exception e)
            {
                _specFlowOutputHelper.addErrorLog(e);
                throw;
            }
        }

        [When(@"I fill the step one with my information")]
        public void WhenIFillTheStepOneWithMyInformation()
        {
            try
            {
                var checkoutStep1 = new CheckoutYourInformationPage();
                checkoutStep1.fillYourInformation("Gandalf", "The Grey", "12345678");
            }
            catch (Exception e)
            {
                _specFlowOutputHelper.addErrorLog(e);
                throw;
            }
        }

        [When(@"I proceed to continue checkout")]
        public void WhenIProceedToContinueCheckout()
        {
            try
            {
                var checkoutStep1 = new CheckoutYourInformationPage();
                var checkoutStep2 = checkoutStep1.continueToOverview();
            }
            catch (Exception e)
            {
                _specFlowOutputHelper.addErrorLog(e);
                throw;
            }
        }


        [Then(@"the '([^']*)' product should be listed in the products")]
        public void ThenTheProductShouldBeListedInTheProducts(string p0)
        {
            try
            {
                var checkoutStep2 = new CheckoutOverviewPage();
                checkoutStep2.assertCheckoutProductTitle(p0);
            }
            catch (Exception e)
            {
                _specFlowOutputHelper.addErrorLog(e);
                throw;
            }
        }

        [AfterScenario("@cart")]
        public void AfterCartScenarios()
        {
            new SharedComponentsBetweenPages(false).resetAppState();
            _specFlowOutputHelper.addLog($"Cart reset!");
        }
    }
}

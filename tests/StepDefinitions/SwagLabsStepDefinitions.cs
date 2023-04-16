using commands.pageObjects;
using tests.Support;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

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

        [Given(@"I am logged as '([^']*)' with password '([^']*)' in the products page")]
        public void GivenIAmLoggedAsWithPasswordInTheProductsPage(string p0, string p1)
        {
            try
            {
                var home = new LoginPage().login("standard_user", "secret_sauce");
                _specFlowOutputHelper.addLog("testing inside");
            }
            catch (Exception e)
            {
                _specFlowOutputHelper.addErrorLog(e);
                _specFlowOutputHelper.addScreenshot();
                throw;
            }
        }

        [When(@"I sort the products by '([^']*)'")]
        public void WhenISortTheProductsBy(string p0)
        {
            try
            {
                throw new Exception("error woololo");
            }
            catch (Exception e)
            {
                _specFlowOutputHelper.addErrorLog(e);
                _specFlowOutputHelper.addScreenshot();
                throw;
            }
        }

        [When(@"I click in '([^']*)' product")]
        public void WhenIClickInProduct(string p0)
        {
            throw new PendingStepException();
        }

        [Then(@"the '([^']*)' product description should be '([^']*)'")]
        public void ThenTheProductDescriptionShouldBe(string p0, string p1)
        {
            throw new PendingStepException();
        }

        [When(@"I add '([^']*)' product to the cart")]
        public void WhenIAddProductToTheCart(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"I click on the cart")]
        public void WhenIClickOnTheCart()
        {
            throw new PendingStepException();
        }

        [When(@"I proceed to checkout")]
        public void WhenIProceedToCheckout()
        {
            throw new PendingStepException();
        }

        [When(@"I fill the step one with my information")]
        public void WhenIFillTheStepOneWithMyInformation()
        {
            throw new PendingStepException();
        }

        [Then(@"the '([^']*)' product should be listed in the products")]
        public void ThenTheProductShouldBeListedInTheProducts(string p0)
        {
            throw new PendingStepException();
        }
    }
}

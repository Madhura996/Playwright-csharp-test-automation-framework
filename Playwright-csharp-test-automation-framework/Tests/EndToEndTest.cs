using Test_automation_PageObjectModel.Pages;

namespace Playwright_csharp_test_automation_framework.Tests
{
    internal class EndToEndTest : BaseTest
    {
        [Test]
        [Category("Positive")]
        public async Task SwagLabs_EndToEndTest()
        {
            // Login to Swag Labs
            LoginPage loginPage = new LoginPage(pageDriver, BaseUrl);
            await loginPage.GotoAsync();
            await loginPage.WaitForURLAsync(loginPage.url);
            await loginPage.Username.SetTextAsync("standard_user");
            await loginPage.Password.SetTextAsync("secret_sauce");
            await loginPage.Login.ClickAsync();
            Assert.That(pageDriver.Url, Is.EqualTo($"{BaseUrl}/inventory.html"));

            // Add fleece jacket to cart
            InventoryPage inventoryPage = new InventoryPage(pageDriver, BaseUrl);
            await inventoryPage.AddToCart.ClickAsync();
            Assert.That(await inventoryPage.ShoppingCartItems.GetTextAsync(), Is.EqualTo("1"));
            Assert.That(await inventoryPage.Remove.IsVisible(), Is.True);

            // Verify item in cart
            await inventoryPage.ShoppingCart.ClickAsync();
            Assert.That(pageDriver.Url, Is.EqualTo($"{BaseUrl}/cart.html"));
            Assert.That(await inventoryPage.Remove.IsVisible(), Is.True);

            // Proceed to checkout step one
            CartPage cartPage = new CartPage(pageDriver, BaseUrl);
            Assert.That(await cartPage.ContinueShopping.IsVisible(), Is.True);
            await cartPage.Checkout.ClickAsync();
            Assert.That(pageDriver.Url, Is.EqualTo($"{BaseUrl}/checkout-step-one.html"));

            // Enter checkout information and continue to checkout step two
            CheckoutStepOnePage checkoutStepOnePage = new CheckoutStepOnePage(pageDriver, BaseUrl);           
            Assert.That(await checkoutStepOnePage.Cancel.IsVisible(), Is.True);
            Assert.That(await checkoutStepOnePage.Continue.IsVisible(), Is.True);
            await checkoutStepOnePage.FirstName.SetTextAsync("John");
            await checkoutStepOnePage.LastName.SetTextAsync("Doe");
            await checkoutStepOnePage.PostalCode.SetTextAsync("12345");
            await checkoutStepOnePage.Continue.ClickAsync();
            Assert.That(pageDriver.Url, Is.EqualTo($"{BaseUrl}/checkout-step-two.html"));

            // Verify payment and shipping information and click finish to complete checkout
            CheckoutStepTwoPage checkoutStepTwoPage = new CheckoutStepTwoPage(pageDriver, BaseUrl);
            Assert.That(await checkoutStepTwoPage.Cancel.IsVisible(), Is.True);
            Assert.That(await checkoutStepTwoPage.Finish.IsVisible(), Is.True);
            Assert.That(await checkoutStepTwoPage.PaymentInfoValue.GetTextAsync(), Is.EqualTo("SauceCard #31337"));
            Assert.That(await checkoutStepTwoPage.ShoppingInfoValue.GetTextAsync(), Is.EqualTo("Free Pony Express Delivery!"));
            Assert.That(await checkoutStepTwoPage.SubTotal.GetTextAsync(), Is.EqualTo("Item total: $49.99"));
            Assert.That(await checkoutStepTwoPage.Tax.GetTextAsync(), Is.EqualTo("Tax: $4.00"));
            Assert.That(await checkoutStepTwoPage.TotalValue.GetTextAsync(), Is.EqualTo("Total: $53.99"));
            await checkoutStepTwoPage.Finish.ClickAsync();
            Assert.That(pageDriver.Url, Is.EqualTo($"{BaseUrl}/checkout-complete.html"));

            // Verify checkout complete page and click back home
            CheckoutCompletePage checkoutCompletePage = new CheckoutCompletePage(pageDriver, BaseUrl);
            Assert.That(await checkoutCompletePage.CheckoutCompleteThankYou.GetTextAsync(), Is.EqualTo("Thank you for your order!"));
            Assert.That(await checkoutCompletePage.OrderDispatched.GetTextAsync(), Is.EqualTo("Your order has been dispatched, and will arrive just as fast as the pony can get there!"));
            await checkoutCompletePage.BackHome.ClickAsync();
            Assert.That(pageDriver.Url, Is.EqualTo($"{BaseUrl}/inventory.html"));
        }

        //[Test]
        [Category("Positive")]
        public async Task AddFleeceJacketToCart_ShouldDisplayItemInCart()
        {                   
        }

        //[Test]
        [Category("Positive")]
        public async Task VerifyItemInCartAndProceedToCheckout_ShouldDisplayItemInCart()
        {
        }

        //[Test]
        [Category("Positive")]
        public async Task EnterCheckoutInformationAndContinue_ShouldRedirectToCheckoutOverview()
        {           
        }

        //[Test]
        [Category("Positive")]
        public async Task VerifyPaymentAndShippingInformationAndClickFinish_ShouldRedirectToCheckoutComplete()
        {
        }
    }
}

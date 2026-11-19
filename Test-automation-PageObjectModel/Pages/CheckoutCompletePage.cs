using Microsoft.Playwright;
using Test_automation_PageObjectModel.Components;

namespace Test_automation_PageObjectModel.Pages
{
    public class CheckoutCompletePage : BasePage
    {
        public HeaderComponent CheckoutCompleteThankYou { get; }
        public Label OrderDispatched { get; }
        public Button BackHome { get; }

        public CheckoutCompletePage(IPage pageDriver, string baseUrl) : base(pageDriver, baseUrl, "/checkout-complete.html")
        {
            CheckoutCompleteThankYou = new HeaderComponent(pageDriver, "complete-header");
            OrderDispatched = new Label(pageDriver, "complete-text");
            BackHome = new Button(pageDriver, "back-to-products");
        }
    }
}

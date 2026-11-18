using Microsoft.Playwright;
using Test_automation_PageObjectModel.Components;

namespace Test_automation_PageObjectModel.Pages
{
    public class CartPage : BasePage
    {
        public Button ContinueShopping { get; }
        public Button Checkout { get; }
        public Button Remove { get; }

        public CartPage(IPage pageDriver, string baseUrl, string path) : base(pageDriver, baseUrl, "/cart.html")
        {
            ContinueShopping = new Button(pageDriver, "continue-shopping");
            Checkout = new Button(pageDriver, "checkout");
            Remove = new Button(pageDriver, "remove-sauce-labs-fleece-jacket");
        }
    }
}

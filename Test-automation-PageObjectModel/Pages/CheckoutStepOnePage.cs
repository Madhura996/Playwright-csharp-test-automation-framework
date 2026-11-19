using Microsoft.Playwright;
using Test_automation_PageObjectModel.Components;

namespace Test_automation_PageObjectModel.Pages
{
    public class CheckoutStepOnePage : BasePage
    {
        public TextField FirstName { get; }
        public TextField LastName { get; }
        public TextField PostalCode { get; }
        public Button Cancel { get; }
        public Button Continue { get; }

        public CheckoutStepOnePage(IPage pageDriver, string baseUrl) : base(pageDriver, baseUrl, "/checkout-step-one.html")
        {
            FirstName = new TextField(pageDriver, "firstName");
            LastName = new TextField(pageDriver, "lastName");
            PostalCode = new TextField(pageDriver, "postalCode");
            Cancel = new Button(pageDriver, "cancel");
            Continue = new Button(pageDriver, "continue");
        }
    }
}

using Microsoft.Playwright;
using Test_automation_PageObjectModel.Components;

namespace Test_automation_PageObjectModel.Pages
{
    public class CheckoutStepTwoPage : BasePage
    {
        public Label PaymentInfo { get; }
        public Label PaymentInfoValue { get; }
        public Label ShoppingInfo { get; }
        public Label ShoppingInfoValue { get; }
        public Label TotalInfo { get; }
        public Label SubTotal { get; }
        public Label Tax { get; }
        public Label TotalValue { get; }
        public Button Cancel { get; }
        public Button Finish { get; }

        public CheckoutStepTwoPage(IPage pageDriver, string baseUrl, string path) : base(pageDriver, baseUrl, "/checkout-step-two.html")
        {
            PaymentInfo = new Label(pageDriver, "payment-info-label");
            PaymentInfoValue = new Label(pageDriver, "payment-info-value");
            ShoppingInfo = new Label(pageDriver, "shipping-info-label");
            ShoppingInfoValue = new Label(pageDriver, "shipping-info-value");
            TotalInfo = new Label(pageDriver, "total-info-label");
            SubTotal = new Label(pageDriver, "subtotal-label");
            Tax = new Label(pageDriver, "tax-label");
            TotalValue = new Label(pageDriver, "total-label");
            Cancel = new Button(pageDriver, "cancel");
            Finish = new Button(pageDriver, "finish");
        }
    }
}

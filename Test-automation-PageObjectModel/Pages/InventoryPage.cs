using Microsoft.Playwright;
using Test_automation_PageObjectModel.Components;

namespace Test_automation_PageObjectModel.Pages
{
    public class InventoryPage : BasePage
    {
        public Link ShoppingCart { get; }
        public Label ShoppingCartItems { get; }
        public Button Menu { get; }
        public StaticDropdown SortProducts { get; }
        public Button AddToCart { get; }
        public Button Remove { get; }

        public InventoryPage(IPage pageDriver, string baseUrl, string path) : base(pageDriver, baseUrl, "/inventory.html")
        {
            ShoppingCart = new Link(pageDriver, "shopping-cart-link");
            ShoppingCartItems = new Label(pageDriver, "shopping-cart-badge");
            Menu = new Button(pageDriver, "open-menu");
            SortProducts = new StaticDropdown(pageDriver, "product-sort-container");
            AddToCart = new Button(pageDriver, "add-to-cart-sauce-labs-backpack");
            Remove = new Button(pageDriver, "remove-sauce-labs-backpack");
        }
    }
}

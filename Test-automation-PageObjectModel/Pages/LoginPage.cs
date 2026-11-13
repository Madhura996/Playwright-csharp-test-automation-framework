using Microsoft.Playwright;
using Test_automation_PageObjectModel.Components;

namespace Test_automation_PageObjectModel.Pages
{
    public class LoginPage : BasePage
    {
        public TextField Username { get; }
        public TextField Password { get; }
        public Button Login { get; }
        public HeaderComponent Error { get; }


        public LoginPage(IPage pageDriver, string baseUrl) : base(pageDriver, baseUrl, string.Empty)
        {
            Username = new TextField(pageDriver, "username");
            Password = new TextField(pageDriver, "password");
            Login = new Button(pageDriver, "login-button");
            Error = new HeaderComponent(pageDriver, "error");
        }
    }
}

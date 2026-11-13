using Test_automation_PageObjectModel.Pages;

namespace Playwright_csharp_test_automation_framework.Tests
{
    public class LoginPageTests : BaseTest
    {
        [Test]
        public async Task EnterValidLoginCredentials_ShouldAuthenticateUser()
        {
            LoginPage loginPage = new LoginPage(pageDriver, BaseUrl);
            await loginPage.GotoAsync();
            await loginPage.WaitForURLAsync(loginPage.url);
            await loginPage.Username.SetTextAsync("standard_user");
            await loginPage.Password.SetTextAsync("secret_sauce");
            await loginPage.Login.ClickAsync();
            Assert.That(pageDriver.Url, Is.EqualTo($"{BaseUrl}inventory.html"));
        }
    }
}

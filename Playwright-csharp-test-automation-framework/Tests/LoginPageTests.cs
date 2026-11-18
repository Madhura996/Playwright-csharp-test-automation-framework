using Test_automation_PageObjectModel.Pages;

namespace Playwright_csharp_test_automation_framework.Tests
{
    public class LoginPageTests : BaseTest
    {
        [Test]
        [Category("Positive")]
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

        [Test]
        [Category("Negative")]
        public async Task EnterLockedOutUserLoginCredentials_ShouldDisplayError()
        {
            LoginPage loginPage = new LoginPage(pageDriver, BaseUrl);
            await loginPage.GotoAsync();
            await loginPage.WaitForURLAsync(loginPage.url);
            await loginPage.Username.SetTextAsync("locked_out_user");
            await loginPage.Password.SetTextAsync("secret_sauce");
            await loginPage.Login.ClickAsync();
            Assert.That(await loginPage.Error.GetTextAsync(), Is.EqualTo("Epic sadface: Sorry, this user has been locked out."));
        }
    }
}

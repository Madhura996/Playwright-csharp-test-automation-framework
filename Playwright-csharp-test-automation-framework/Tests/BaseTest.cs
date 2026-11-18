using Microsoft.Playwright;

namespace Playwright_csharp_test_automation_framework.Tests
{
    public abstract class BaseTest
    {
        private IPlaywright _playwright;
        private IBrowser? _browser;
        private IBrowserContext _browserContext;
        protected IPage pageDriver;

        protected static string BaseUrl =>
            Environment.GetEnvironmentVariable("URL")
            ?? TestContext.Parameters["Url"]
            ?? throw new InvalidOperationException("Missing test run parameter 'Url'. Ensure that local.runsettings is selected.");

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _playwright = await Playwright.CreateAsync();
        }

        [SetUp]
        public async Task TestSetup()
        {
            // setting Chrome as default browser
            var platform = TestContext.Parameters["RunLocalPlatform"] ?? "Chrome";

            // BrowserStack SDK automatically launches the correct remote browser based on yml, and ignores the local browser.
            // LaunchAsync() method should be available
            switch (platform)
            {
                case "Chrome":
                    _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions()
                    {
                        Headless = false
                    });
                    break;

                case "Firefox":
                    _browser = await _playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions()
                    {
                        Headless = false
                    });
                    break;

                case "Webkit":
                    _browser = await _playwright.Webkit.LaunchAsync(new BrowserTypeLaunchOptions()
                    {
                        Headless = false
                    });
                    break;

                default:
                    throw new Exception("Invalid RunLocalPlatform value in the .csproj file. Please set it to 'Chrome', 'Firefox' or 'Webkit'.");
            }

            _browserContext = await _browser.NewContextAsync();
            pageDriver = await _browserContext.NewPageAsync();
                       
        }

        [TearDown]
        public async Task TestCleanup()
        {
            await _browserContext.CloseAsync();

            if (_browser != null)
            {
                await _browser.CloseAsync();
            }
        }

        [OneTimeTearDown]
        public async Task GlobalCleanup()
        {
            _playwright.Dispose();
        }

    }
}

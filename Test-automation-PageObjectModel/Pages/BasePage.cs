using Microsoft.Playwright;

namespace Test_automation_PageObjectModel.Pages
{
    public abstract class BasePage
    {
        public IPage pageDriver { get; set; }
        public string url { get; set; }

        public BasePage(IPage pageDriver, string baseUrl, string path)
        {
            this.pageDriver = pageDriver;
            this.url = new Uri(new Uri(baseUrl, UriKind.Absolute), path).AbsoluteUri;
        }

        public async Task GotoAsync()
        {
            await pageDriver.GotoAsync(url, new PageGotoOptions
            {
                WaitUntil = WaitUntilState.Commit,
                Timeout = 30000
            });
        }

        public async Task WaitForURLAsync(string url)
        {
            await pageDriver.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            await pageDriver.WaitForURLAsync(url, new PageWaitForURLOptions
            {
                Timeout = 30000
            });
        }
    }
}

using Microsoft.Playwright;
using System.Data;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Test_automation_PageObjectModel.Components
{
    public abstract class BaseComponent
    {
        protected IPage pageDriver;
        protected string data_test;

        public BaseComponent(IPage pageDriver, string data_test)
        {
            this.pageDriver = pageDriver;
            this.data_test = data_test;
        }

        public async Task<ILocator> GetElement()
        {
            await pageDriver.Locator($"[data-test='{data_test}']").WaitForAsync();
            return pageDriver.Locator($"[data-test='{data_test}']");
        }

        public ILocator GetElements()
        {
            return pageDriver.Locator($"[data-test='{data_test}']");
        }

        public async Task<bool> IsVisible()
        {
            var element = pageDriver.Locator($"[data-test='{data_test}']");
            try
            {
                await pageDriver.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
                await element.WaitForAsync(new LocatorWaitForOptions
                {
                    State = WaitForSelectorState.Visible,
                    Timeout = 30000
                });

                return await element.IsVisibleAsync();
            }
            catch (TimeoutException)
            {
                return false;
            }
        }
    }
}

using Microsoft.Playwright;
using Test_automation_PageObjectModel.Interfaces;

namespace Test_automation_PageObjectModel.Components
{
    public class Link : BaseComponent, IClickable
    {
        public Link(IPage pageDriver, string data_test) : base(pageDriver, data_test)
        {
        }

        public async Task ClickAsync()
        {
            var element = await base.GetElement();
            await element.ClickAsync();
        }

        public async Task<string> GetTextAsync()
        {
            var element = await base.GetElement();
            return await element.InnerTextAsync() ?? string.Empty;
        }
    }
}

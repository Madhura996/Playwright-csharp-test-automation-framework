using Microsoft.Playwright;
using Test_automation_PageObjectModel.Interfaces;

namespace Test_automation_PageObjectModel.Components
{
    public class HeaderComponent : BaseComponent, ITextReadable
    {
        public HeaderComponent(IPage pageDriver, string data_test) : base(pageDriver, data_test)
        {
        }

        public async Task<string> GetTextAsync()
        {
            var element = await base.GetElement();
            return await element.TextContentAsync() ?? string.Empty;
        }
    }
}

using Microsoft.Playwright;

namespace Test_automation_PageObjectModel.Components
{
    public class TextField : BaseComponent
    {
        public TextField(IPage pageDriver, string data_test) : base(pageDriver, data_test)
        {
        }

        public async Task SetTextAsync(string text)
        {
            var element = await GetElement();
            await element.FillAsync(text);
        }

        public async Task<string> GetTextAsync()
        {
            var element = await GetElement();
            return await element.InputValueAsync() ?? string.Empty;
        }

        public async Task ClearAsync()
        {
            var element = await GetElement();
            await element.ClearAsync();
        }
    }
}

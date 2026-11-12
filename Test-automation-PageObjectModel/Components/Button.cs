using Microsoft.Playwright;

namespace Test_automation_PageObjectModel.Components
{
    public class Button : BaseComponent
    {
        public Button(IPage pageDriver, string data_test) : base(pageDriver, data_test)
        {
        }
    }
}

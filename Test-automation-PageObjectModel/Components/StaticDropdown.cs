using Microsoft.Playwright;

namespace Test_automation_PageObjectModel.Components
{
    public class StaticDropdown : BaseComponent
    {
        public StaticDropdown(IPage pageDriver, string data_test) : base(pageDriver, data_test)
        {
        }
    }
}

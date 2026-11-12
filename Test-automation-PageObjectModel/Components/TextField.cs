using Microsoft.Playwright;

namespace Test_automation_PageObjectModel.Components
{
    public class TextField : BaseComponent
    {
        public TextField(IPage pageDriver, string data_test) : base(pageDriver, data_test)
        {
        }
    }
}

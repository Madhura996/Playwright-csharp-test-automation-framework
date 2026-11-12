namespace Test_automation_PageObjectModel.Interfaces
{
    public interface IClickable
    {
        Task ClickAsync();
        Task<string> GetTextAsync();
    }
}

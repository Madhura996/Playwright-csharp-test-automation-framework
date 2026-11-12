namespace Test_automation_PageObjectModel.Interfaces
{
    public interface ITypable
    {
        Task SetTextAsync(string text);
        Task<string> GetTextAsync();
        Task ClearAsync();
    }
}

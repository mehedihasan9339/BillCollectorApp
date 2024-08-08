namespace BillCollectorApp.Services.Interfaces
{
    public interface ISms
    {
        Task SendSmsAsync(string destination, string message);
    }
}

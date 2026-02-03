namespace IMSIdentity.Models.Interfaces
{
    public interface IAlertRepository
    {
        Task CreateAndBroadcastAsync(string title, string message, string iconClass);
    }
}

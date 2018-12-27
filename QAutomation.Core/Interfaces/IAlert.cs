namespace QAutomation.Core.Interfaces
{
    public interface IAlert
    {
        string Text { get; }

        void Dismiss();
        void Accept();

        void SendKeys(string keysToSend);
        void SetAuthenticationCredentials(string userName, string password);
    }
}

namespace QAutomation.Selenium
{
    using OpenQA.Selenium;

    public class Alert : Core.Interfaces.IAlert
    {
        private readonly IAlert _alert;

        public Alert(IAlert alert)
        {
            _alert = alert;
        }

        public string Text => _alert.Text;
        public void Accept() => _alert.Accept();
        public void Dismiss() => _alert.Dismiss();

        public void SendKeys(string keysToSend) => _alert.SendKeys(keysToSend);
        public void SetAuthenticationCredentials(string userName, string password) => SetAuthenticationCredentials(userName, password);
    }
}

namespace QAutomation.Selenium
{
    using QAutomation.Core.Interfaces;

    public class Alert : IAlert
    {
        private readonly OpenQA.Selenium.IAlert _alert;

        public Alert(OpenQA.Selenium.IAlert alert) => _alert = alert;

        public string Text => _alert.Text;

        public void Accept() => _alert.Accept();

        public void Dismiss() => _alert.Dismiss();

        public void SendKeys(string keysToSend) => _alert.SendKeys(keysToSend);

        public void SetAuthenticationCredentials(string userName, string password) => _alert.SetAuthenticationCredentials(userName, password);
    }
}

namespace QAutomation.Selenium
{
    using QAutomation.Core.Interfaces;

    public class Alert : IAlert
    {
        private readonly OpenQA.Selenium.IAlert alert;

        public Alert(OpenQA.Selenium.IAlert alert)
        {
            this.alert = alert;
        }

        public string Text => alert.Text;

        public void Accept() => alert.Accept();

        public void Dismiss() => alert.Dismiss();

        public void SendKeys(string keysToSend) => alert.SendKeys(keysToSend);

        public void SetAuthenticationCredentials(string userName, string password) => alert.SetAuthenticationCredentials(userName, password);
    }
}

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

        public string Text => this.alert.Text;

        public void Accept() => this.alert.Accept();

        public void Dismiss() => this.alert.Dismiss();

        public void SendKeys(string keysToSend) => this.alert.SendKeys(keysToSend);

        public void SetAuthenticationCredentials(string userName, string password) 
            => this.alert.SetAuthenticationCredentials(userName, password);
    }
}

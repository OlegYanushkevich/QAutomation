namespace QAutomation.Selenium.Logged
{
    using System;
    using OpenQA.Selenium;
    using QAutomation.AspectInjector;

    [Logged]
    public class LoggedAlert : IAlert
    {
        private readonly IAlert decoratedAlert;

        public LoggedAlert(IAlert decoratedAlert)
        {
            this.decoratedAlert = decoratedAlert ?? throw new NullReferenceException(nameof(decoratedAlert));
        }

        public string Text => this.decoratedAlert.Text;

        public void Accept() => this.decoratedAlert.Accept();

        public void Dismiss() => this.decoratedAlert.Dismiss();

        public void SendKeys(string keysToSend) => this.decoratedAlert.SendKeys(keysToSend);

        public void SetAuthenticationCredentials(string userName, string password) 
            => this.decoratedAlert.SetAuthenticationCredentials(userName, password);
    }
}

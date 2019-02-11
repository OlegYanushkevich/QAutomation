namespace QAutomation.Selenium.Logged
{
    using System;
    using OpenQA.Selenium;
    using QAutomation.AspectInjector;

    [Logged]
    public class LoggedAlert : IAlert
    {
        private readonly IAlert _decoratedAlert;

        public LoggedAlert(IAlert alert)
        {
            _decoratedAlert = alert ?? throw new NullReferenceException(nameof(alert));
        }

        public string Text => _decoratedAlert.Text;

        public void Accept() => _decoratedAlert.Accept();

        public void Dismiss() => _decoratedAlert.Dismiss();

        public void SendKeys(string keysToSend) => _decoratedAlert.SendKeys(keysToSend);

        public void SetAuthenticationCredentials(string userName, string password) 
            => _decoratedAlert.SetAuthenticationCredentials(userName, password);
    }
}

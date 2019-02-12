namespace QAutomation.Selenium.Logged
{
    using System;
    using System.Collections.Generic;
    using QAutomation.AspectInjector;
    using QAutomation.Core.Interfaces;

    [Logged]
    public class LoggedCookiesService : ICookiesService
    {
        private readonly ICookiesService decoratedCookieService;

        public LoggedCookiesService(ICookiesService decoratedCookiesService)
        {
            this.decoratedCookieService = decoratedCookiesService ?? throw new NullReferenceException(nameof(decoratedCookiesService));
        }

        public IReadOnlyCollection<Core.Cookie> GetAll() => this.decoratedCookieService.GetAll();

        public Core.Cookie GetByName(string cookieName) => this.decoratedCookieService.GetByName(cookieName);

        public ICookiesService Add(Core.Cookie cookie) => this.decoratedCookieService.Add(cookie);

        public ICookiesService Delete(Core.Cookie cookie) => this.decoratedCookieService.Delete(cookie);

        public ICookiesService DeleteAll() => this.decoratedCookieService.DeleteAll();

        public ICookiesService DeleteByName(string cookieName) => this.decoratedCookieService.DeleteByName(cookieName);
    }
}

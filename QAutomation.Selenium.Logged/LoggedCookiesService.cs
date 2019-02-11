namespace QAutomation.Selenium.Logged
{
    using System.Collections.Generic;
    using QAutomation.AspectInjector;
    using QAutomation.Core.Interfaces;

    [Logged]
    class LoggedCookiesService : ICookiesService
    {
        private readonly ICookiesService _decoratedCookieService;

        public LoggedCookiesService(ICookiesService cookiesService)
        {
            _decoratedCookieService = cookiesService ?? _decoratedCookieService;
        }

        public IReadOnlyCollection<Core.Cookie> Cookies => _decoratedCookieService.Cookies;

        public ICookiesService Add(Core.Cookie cookie) => _decoratedCookieService.Add(cookie);

        public ICookiesService Delete(Core.Cookie cookie) => _decoratedCookieService.Delete(cookie);

        public ICookiesService DeleteAll() => _decoratedCookieService.DeleteAll();

        public ICookiesService DeleteByName(string cookieName) => _decoratedCookieService.DeleteByName(cookieName);

        public Core.Cookie GetByName(string cookieName) => _decoratedCookieService.GetByName(cookieName);
    }
}

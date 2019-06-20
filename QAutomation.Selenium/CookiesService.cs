namespace QAutomation.Selenium
{
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class CookiesService : ICookiesService
    {
        private readonly ICookieJar cookieJar;

        public CookiesService(ICookieJar cookieJar) => this.cookieJar = cookieJar;

        public IReadOnlyCollection<Core.Cookie> GetAll() =>
            cookieJar.AllCookies.Select(c => new Core.Cookie(c.Name, c.Value, c.Path, c.Domain, c.Expiry)).ToList().AsReadOnly();

        public Core.Cookie GetByName(string cookieName)
        {
            var cookie = cookieJar.GetCookieNamed(cookieName);
            return new Core.Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain, cookie.Expiry);
        }

        public ICookiesService Add(Core.Cookie cookie)
        {
            cookieJar.AddCookie(new Cookie(cookie.Name, cookie.Value, cookie.Domain, cookie.Expiry));
            return this;
        }

        public ICookiesService Delete(Core.Cookie cookie)
        {
            cookieJar.DeleteCookie(new Cookie(cookie.Name, cookie.Value, cookie.Domain, cookie.Expiry));
            return this;
        }

        public ICookiesService DeleteAll()
        {
            cookieJar.DeleteAllCookies();
            return this;
        }

        public ICookiesService DeleteByName(string cookieName)
        {
            cookieJar.DeleteCookieNamed(cookieName);
            return this;
        }
    }
}

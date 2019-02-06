namespace QAutomation.Selenium
{
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class CookiesService : ICookiesService
    {
        private readonly ICookieJar _cookieJar;

        public CookiesService(ICookieJar cookieJar)
        {
            _cookieJar = cookieJar;
        }

        public IReadOnlyCollection<Core.Cookie> Cookies => 
            _cookieJar.AllCookies.Select(c => new Core.Cookie(c.Name, c.Value, c.Path, c.Domain, c.Expiry)).ToList().AsReadOnly();

        public ICookiesService Add(Core.Cookie cookie)
        {
            _cookieJar.AddCookie(new Cookie(cookie.Name, cookie.Value, cookie.Domain, cookie.Expiry));
            return this;
        }

        public ICookiesService Delete(Core.Cookie cookie)
        {
            _cookieJar.DeleteCookie(new Cookie(cookie.Name, cookie.Value, cookie.Domain, cookie.Expiry));
            return this;
        }

        public ICookiesService DeleteAll()
        {
            _cookieJar.DeleteAllCookies();
            return this;
        }

        public ICookiesService DeleteByName(string cookieName)
        {
            _cookieJar.DeleteCookieNamed(cookieName);
            return this;
        }

        public Core.Cookie GetByName(string cookieName)
        {
            var sel = _cookieJar.GetCookieNamed(cookieName);
            return new Core.Cookie(sel.Name, sel.Value, sel.Path, sel.Domain, sel.Expiry);
        }
    }
}

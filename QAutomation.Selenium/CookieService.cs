namespace QAutomation.Selenium
{
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class CookieService : ICookieService
    {
        private readonly ICookieJar _cookieJar;

        public CookieService(ICookieJar cookieJar)
        {
            _cookieJar = cookieJar;
        }

        public IReadOnlyCollection<Core.Cookie> Cookies => 
            _cookieJar.AllCookies.Select(c => new Core.Cookie(c.Name, c.Value, c.Path, c.Domain, c.Expiry)).ToList().AsReadOnly();

        public ICookieService Add(Core.Cookie cookie)
        {
            _cookieJar.AddCookie(new Cookie(cookie.Name, cookie.Value, cookie.Domain, cookie.Expiry));
            return this;
        }

        public ICookieService Delete(Core.Cookie cookie)
        {
            _cookieJar.DeleteCookie(new Cookie(cookie.Name, cookie.Value, cookie.Domain, cookie.Expiry));
            return this;
        }

        public ICookieService DeleteAll()
        {
            _cookieJar.DeleteAllCookies();
            return this;
        }

        public ICookieService DeleteByName(string cookieName)
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

namespace QAutomation.Core.Interfaces
{
    using System.Collections.Generic;

    public interface ICookieService
    {
        IReadOnlyCollection<Cookie> Cookies { get; }

        ICookieService Add(Cookie cookie);
        Cookie GetByName(string cookieName);

        ICookieService DeleteByName(string cookieName);
        ICookieService Delete(Cookie cookie);
        ICookieService DeleteAll();
    }
}

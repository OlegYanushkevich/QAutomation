namespace QAutomation.Core.Interfaces
{
    using System.Collections.Generic;

    public interface ICookiesService
    {
        IReadOnlyCollection<Cookie> GetAll();

        ICookiesService Add(Cookie cookie);
        Cookie GetByName(string cookieName);

        ICookiesService DeleteByName(string cookieName);
        ICookiesService Delete(Cookie cookie);
        ICookiesService DeleteAll();
    }
}

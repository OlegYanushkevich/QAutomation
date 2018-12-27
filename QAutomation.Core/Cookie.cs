namespace QAutomation.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Cookie
    {
        private string _cookieName;
        private string _cookieValue;

        private string _cookiePath;
        private string _cookieDomain;

        private DateTime? _cookieExpiry;

        public Cookie(string name, string value, string path, string domain, DateTime? expireDate)
        {
            _cookieName = name;
            _cookieValue = value;
            _cookieDomain = domain;
            _cookiePath = path;
            _cookieExpiry = expireDate;
        }

        public string Name
        {
            get { return _cookieName; }
        }

        public string Value
        {
            get { return _cookieValue; }
        }

        public string Domain
        {
            get { return _cookieDomain; }
        }

        public virtual string Path
        {
            get { return _cookiePath; }
        }

        public virtual bool Secure
        {
            get { return false; }
        }

        public DateTime? Expiry
        {
            get { return _cookieExpiry; }
        }
    }
}

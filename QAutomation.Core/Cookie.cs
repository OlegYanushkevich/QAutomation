namespace QAutomation.Core
{
    using System;

    public class Cookie
    {
        public Cookie(string name, string value, string path, string domain, DateTime? expireDate)
        {
            Name = name;
            Value = value;

            Domain = domain;
            Path = path;

            Expiry = expireDate;
        }

        public string Name { get; }

        public string Value { get; }

        public string Domain { get; }

        public string Path { get; }

        public virtual bool Secure => false;

        public DateTime? Expiry { get; }
    }
}

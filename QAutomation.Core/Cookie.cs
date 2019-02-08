namespace QAutomation.Core
{
    using System;

    public class Cookie
    {
        public Cookie(string name, string value, string path, string domain, DateTime? expireDate)
        {
            this.Name = name;
            this.Value = value;
            this.Domain = domain;
            this.Path = path;
            this.Expiry = expireDate;
        }

        public string Name { get; }

        public string Value { get; }

        public string Domain { get; }

        public string Path { get; }

        public virtual bool Secure
        {
            get { return false; }
        }

        public DateTime? Expiry { get; }
    }
}

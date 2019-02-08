namespace QAutomation.Selenium
{
    using System;
    using System.Diagnostics;
    using OpenQA.Selenium.Support.UI;
    using QAutomation.Core.Interfaces;

    public class WaitingService : IWaitingService
    {
        private readonly IDriver driver;

        public WaitingService(IDriver driver)
        {
            this.driver = driver;
        }

        public T Until<T>(Func<IDriver, T> condition, double timeout = -1, params Type[] exceptionTypes) => this.Until(condition, timeout, 1, exceptionTypes);

        public T Until<T>(Func<IDriver, T> condition, double timeout, out double elapsed, params Type[] exceptionTypes) => this.Until(condition, timeout, 1, out elapsed, exceptionTypes);

        public T Until<T>(Func<IDriver, T> condition, double timeout, double pollingInterval, out double elapsed, params Type[] exceptionTypes)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                return this.Until(condition, timeout, pollingInterval, exceptionTypes);
            }
            finally
            {
                elapsed = sw.Elapsed.TotalSeconds;
            }
        }

        public T Until<T>(Func<IDriver, T> condition, double timeout, double pollingInterval, params Type[] exceptionTypes)
            => this.ConfigurateWaiter(timeout, pollingInterval, exceptionTypes).Until(d => condition(d));

        public bool Try<T>(Func<IDriver, T> condition, double timeout = -1, params Type[] exceptionTypes)
        {
            try
            {
                this.Until(condition, timeout, exceptionTypes);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Try<T>(Func<IDriver, T> condition, double timeout, double pollingInterval, params Type[] exceptionTypes)
        {
            try
            {
                this.Until(condition, timeout, pollingInterval, exceptionTypes);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private DefaultWait<IDriver> ConfigurateWaiter(double timeout, double pollingInterval, params Type[] exceptionTypes)
        {
            var waiter = new DefaultWait<IDriver>(this.driver)
            {
                Timeout = TimeSpan.FromSeconds(timeout),
                PollingInterval = TimeSpan.FromSeconds(pollingInterval),
            };

            waiter.IgnoreExceptionTypes(exceptionTypes);
            return waiter;
        }
    }
}

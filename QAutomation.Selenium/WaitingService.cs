namespace QAutomation.Selenium
{
    using OpenQA.Selenium.Support.UI;
    using QAutomation.Core.Interfaces;
    using System;
    using System.Diagnostics;

    public class WaitingService : IWaitingService
    {
        private readonly IDriver driver;

        public WaitingService(IDriver driver) => this.driver = driver;

        public T Until<T>(Func<IDriver, T> condition, double timeout = -1, params Type[] exceptionTypes)
            => Until(condition, timeout, 1, exceptionTypes);

        public T Until<T>(Func<IDriver, T> condition, double timeout, out double elapsed, params Type[] exceptionTypes)
            => Until(condition, timeout, 1, out elapsed, exceptionTypes);

        public T Until<T>(Func<IDriver, T> condition, double timeout, double pollingInterval, out double elapsed, params Type[] exceptionTypes)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                return Until(condition, timeout, pollingInterval, exceptionTypes);
            }
            finally
            {
                elapsed = sw.Elapsed.TotalSeconds;
            }
        }

        public T Until<T>(Func<IDriver, T> condition, double timeout, double pollingInterval, params Type[] exceptionTypes)
            => ConfigurateWaiter(timeout, pollingInterval, exceptionTypes).Until(d => condition(d));

        public bool Try<T>(Func<IDriver, T> condition, double timeout = -1, params Type[] exceptionTypes)
        {
            try
            {
                Until(condition, timeout, exceptionTypes);
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
                Until(condition, timeout, pollingInterval, exceptionTypes);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private DefaultWait<IDriver> ConfigurateWaiter(double timeout, double pollingInterval, params Type[] exceptionTypes)
        {
            var waiter = new DefaultWait<IDriver>(driver)
            {
                Timeout = timeout >= 0 ? TimeSpan.FromSeconds(timeout) : driver.Config.SearchTimeout,
                PollingInterval = pollingInterval >= 0 ? TimeSpan.FromSeconds(pollingInterval) : driver.Config.PollingInterval
            };

            waiter.IgnoreExceptionTypes(exceptionTypes);
            return waiter;
        }
    }
}

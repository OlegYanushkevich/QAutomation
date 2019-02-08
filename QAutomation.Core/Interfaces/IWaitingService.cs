namespace QAutomation.Core.Interfaces
{
    using System;

    public interface IWaitingService
    {
        T Until<T>(Func<IDriver, T> condition, double timeout = -1, params Type[] exceptionTypes);

        T Until<T>(Func<IDriver, T> condition, double timeout, out double elapsed, params Type[] exceptionTypes);

        T Until<T>(Func<IDriver, T> condition, double timeout, double pollingInterval, out double elapsed, params Type[] exceptionTypes);

        T Until<T>(Func<IDriver, T> condition, double timeout, double pollingInterval, params Type[] exceptionTypes);

        bool Try<T>(Func<IDriver, T> condition, double timeout = -1, params Type[] exceptionTypes);

        bool Try<T>(Func<IDriver, T> condition, double timeout, double pollingInterval, params Type[] exceptionTypes);
    }
}

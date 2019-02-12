namespace QAutomation.Selenium.Logged
{
    using QAutomation.AspectInjector;
    using QAutomation.Core.Interfaces;
    using System;

    [Logged]
    public class LoggedWaitingService : IWaitingService
    {
        private readonly IWaitingService decoratedWaitingService;

        public LoggedWaitingService(IWaitingService decoratedWaitingService)
        {
            this.decoratedWaitingService = decoratedWaitingService ?? throw new NullReferenceException(nameof(decoratedWaitingService));
        }

        public bool Try<T>(Func<IDriver, T> condition, double timeout = -1, params Type[] exceptionTypes)
            => decoratedWaitingService.Try<T>(condition, timeout, exceptionTypes);

        public bool Try<T>(Func<IDriver, T> condition, double timeout, double pollingInterval, params Type[] exceptionTypes)
            => decoratedWaitingService.Try<T>(condition, timeout, pollingInterval, exceptionTypes);

        public T Until<T>(Func<IDriver, T> condition, double timeout = -1, params Type[] exceptionTypes)
            => decoratedWaitingService.Until<T>(condition, timeout, exceptionTypes);

        public T Until<T>(Func<IDriver, T> condition, double timeout, out double elapsed, params Type[] exceptionTypes)
            => decoratedWaitingService.Until<T>(condition, timeout, out elapsed, exceptionTypes);

        public T Until<T>(Func<IDriver, T> condition, double timeout, double pollingInterval, out double elapsed, params Type[] exceptionTypes)
            => decoratedWaitingService.Until<T>(condition, timeout, pollingInterval, out elapsed, exceptionTypes);

        public T Until<T>(Func<IDriver, T> condition, double timeout, double pollingInterval, params Type[] exceptionTypes)
           => decoratedWaitingService.Until<T>(condition, timeout, pollingInterval, exceptionTypes);
    }
}

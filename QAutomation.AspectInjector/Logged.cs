namespace QAutomation.AspectInjector
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using global::AspectInjector.Broker;
    using QAutomation.Logging.Abstract;

    [Aspect(Scope.Global)]
    [Injection(typeof(LoggedAttribute))]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method, AllowMultiple = false)]
    public class LoggedAttribute : Attribute
    {
        private static readonly Dictionary<LogLevel, NLog.LogLevel> map = new Dictionary<LogLevel, NLog.LogLevel>
        {
            [LogLevel.DEBUG] = NLog.LogLevel.Debug,
            [LogLevel.TRACE] = NLog.LogLevel.Trace,
            [LogLevel.INFO] = NLog.LogLevel.Info,
            [LogLevel.ERROR] = NLog.LogLevel.Error,
            [LogLevel.FATAL] = NLog.LogLevel.Fatal
        };

        [Advice(Kind.Around, Targets = Target.Method)]
        public object HandleMethod
        (
            [Argument(Source.Name)] string name,
            [Argument(Source.Arguments)] object[] arguments,
            [Argument(Source.Instance)] object target,
            [Argument(Source.Target)] Func<object[], object> method
        )
        {
            var executorTypeInfo = target.GetType().GetTypeInfo();

            var descriptionAttribute = target.GetType()
                                             .GetTypeInfo()
                                             .GetMethod(name)
                                             .GetCustomAttribute<DescriptionAttribute>();

            var logger = NLog.LogManager.GetLogger(executorTypeInfo.FullName);
            var sw = Stopwatch.StartNew();

            logger?.Trace($"Executing the '{executorTypeInfo.Name}.{name}' method.");
            try
            {
                if (descriptionAttribute != null)
                {
                    logger?.Log(map[descriptionAttribute.Level], descriptionAttribute.Description);
                }

                var result = method(arguments);
                //logger?.Trace("'{@executor}' method returned {@result}", new[] { $"{executorTypeInfo.Name}.{name}", result });

                return method(arguments);
            }
            catch (Exception ex)
            {
                logger?.Error(ex);
                throw;
            }
            finally
            {
                sw.Stop();
                logger?.Trace($"The method '{executorTypeInfo.Name}.{name}' worked in {sw.Elapsed.TotalSeconds} second(s).");
            }
        }
    }
}

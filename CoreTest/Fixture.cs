namespace Test
{
    using Autofac;
    using NUnit.Framework;
    using System;
    using System.Threading;

    public abstract class BaseTestFixture : IDisposable
    {
        protected ThreadLocal<ILifetimeScope> _threadLocalResolver = new ThreadLocal<ILifetimeScope>();

        protected bool disposed = false;

        protected ILifetimeScope LifetimeScope
        {
            get { return _threadLocalResolver.Value; }
            private set { _threadLocalResolver.Value = value; }
        }

        [SetUp]
        public virtual void SetUp()
        {
            var resolver = Test.DependencyResolver.GetResolver();

            //Log = resolver.Resolve<ILogger>(
            //    new TypedParameter(typeof(string), TestContext.CurrentContext.Test.FullName));

            LifetimeScope = resolver.BeginLifetimeScope(builder =>
            {
                IContainer container = null;

                builder.Register(_ => container).AsSelf();
                builder.RegisterBuildCallback(c => container = c);
            });

        }

        [TearDown]
        public virtual void TearDown() { }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _threadLocalResolver.Dispose();
                }
            }

            disposed = true;
        }
    }
}

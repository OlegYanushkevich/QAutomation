namespace QAutomation.Observe.Concrete
{
    using System.Collections.Generic;
    using System.Reflection;

    public class NUnitExecutionSubject : ITestExecutionSubject
    {
        private readonly List<ITestBehaviorObserver> _observers;

        public NUnitExecutionSubject()
        {
            _observers = new List<ITestBehaviorObserver>();
        }

        public void Attach(ITestBehaviorObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(ITestBehaviorObserver observer)
        {
            _observers.Remove(observer);
        }

        public void PostTestCleanup(TestContext context, MemberInfo memberInfo)
        {
            this._observers.ForEach(o => o.PostTestCleanup(context, memberInfo));
        }

        public void PostTestInit(TestContext context, MemberInfo memberInfo)
        {
            this._observers.ForEach(o => o.PostTestInit(context, memberInfo));
        }

        public void PreTestCleanup(TestContext context, MemberInfo memberInfo)
        {
            this._observers.ForEach(o => o.PreTestCleanup(context, memberInfo));
        }

        public void PreTestInit(TestContext context, MemberInfo memberInfo)
        {
            this._observers.ForEach(o => o.PreTestInit(context, memberInfo));
        }

        public void TestInstantiated(MemberInfo memberInfo)
        {
            this._observers.ForEach(o => o.TestInstantiated(memberInfo));
        }
    }
}

using System;
using System.Reflection;
using Unity.Injection;
using Unity.Policy;
using Unity.ResolverPolicy;

namespace QAutomation.Selenium.Unity
{
    public class NullInjectionParameterValue : InjectionParameterValue
    {
        public NullInjectionParameterValue(Type parameterType)
        {
            this.ParameterTypeName = parameterType.GetTypeInfo().Name;
        }

        public override bool MatchesType(Type t)
        {
            return !t.IsValueType || (Nullable.GetUnderlyingType(t) != null);
        }

        public override IResolverPolicy GetResolverPolicy(Type typeToBuild)
        {
            return new LiteralValueDependencyResolverPolicy(null);
        }

        public override string ParameterTypeName { get; }
    }

    public class NullInjectionParameterValue<TParameter>
        : NullInjectionParameterValue where TParameter : class
    {
        public NullInjectionParameterValue()
            : base(typeof(TParameter))
        {
        }
    }
}
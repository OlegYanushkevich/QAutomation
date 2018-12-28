namespace QAutomation.Selenium
{
    using global::Unity;
    using global::Unity.Resolution;
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Selenium.Controls;
    using System.Collections.Generic;

    public class ElementFinderService
    {
        private readonly IUnityContainer _container;

        public ElementFinderService(IUnityContainer container)
        {
            _container = container;
        }

        public TElement Find<TElement>(WebDriver driver, Core.By by)
            where TElement : IElement
        {
            var element = driver.Driver.FindElement(by.Cast());
            return Resolve<TElement>(driver, element, by);
        }

        public IEnumerable<TElement> FindAll<TElement>(WebDriver driver, Core.By by)
            where TElement : IElement
        {
            var elements = driver.Driver.FindElements(by.Cast());

            var list = new List<TElement>();

            foreach (var element in elements)
                list.Add(Resolve<TElement>(driver, element, by));

            return list;
        }

        public IEnumerable<TElement> FindAll<TElement>(Element parent, Core.By by)
            where TElement : IElement
        {
            ISearchContext context = null;

            if (parent is FrameElement frame)
            {
                frame.Switch();
                context = frame.Driver as ISearchContext;
            }
            else
                context = parent.Context;

            var elements = context.FindElements(by.Cast());

            var list = new List<TElement>();

            foreach (var element in elements)
                list.Add(Resolve<TElement>(parent.WebDriver, element, by));

            return list;
        }

        public TElement Find<TElement>(Element parent, Core.By by)
            where TElement : IElement
        {
            ISearchContext context = null;

            if (parent is FrameElement frame)
            {
                frame.Switch();
                context = frame.Driver as ISearchContext;
            }
            else
                context = parent.Context;

            var element = context.FindElement(by.Cast());
            return Resolve<TElement>(parent.WebDriver, element, by);
        }

        private TElement Resolve<TElement>(WebDriver driver, IWebElement current, Core.By by)
            where TElement : IElement
        {
            return _container.Resolve<TElement>(new ResolverOverride[]
            {
                 new ParameterOverride("driver", driver),
                 new ParameterOverride("element", current),
                 new ParameterOverride("locator", by),
                 new ParameterOverride("container", _container)
            });
        }
    }
}

namespace QAutomation.Selenium
{
    using Autofac;
    using OpenQA.Selenium;
    using QAutomation.Core;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Selenium.Controls;
    using System.Collections.Generic;

    public class ElementFinderService
    {
        private readonly ILifetimeScope _scope;

        public ElementFinderService(ILifetimeScope scope) => _scope = scope;

        public TElement Find<TElement>(WebDriver driver, Core.Locator locator)
            where TElement : IElement
        {
            var element = driver.WrappedDriver.FindElement(locator.Cast());
            return Resolve<TElement>(driver, element, locator);
        }

        public IEnumerable<TElement> FindAll<TElement>(WebDriver driver, Core.Locator locator)
            where TElement : IElement
        {
            var elements = driver.WrappedDriver.FindElements(locator.Cast());
            var list = new List<TElement>();

            for (int i = 0; i < elements.Count; i++)
            {
                IWebElement element = elements[i];
                list.Add(item: Resolve<TElement>(driver, element, locator));
            }

            return list;
        }

        public IEnumerable<TElement> FindAll<TElement>(Element parent, Core.Locator locator)
            where TElement : IElement
        {
            ISearchContext context;

            if (parent is FrameElement frame)
            {
                frame.Switch();
                context = frame.Driver as ISearchContext;
            }
            else
            {
                context = parent.Context;
            }

            var elements = context.FindElements(locator.Cast());

            var list = new List<TElement>();

            for (int i = 0; i < elements.Count; i++)
            {
                IWebElement element = elements[i];
                list.Add(item: Resolve<TElement>(parent.WebDriver, element, locator));
            }

            return list;
        }

        public TElement Find<TElement>(Element parent, Core.Locator locator)
            where TElement : IElement
        {
            ISearchContext context;

            if (parent is FrameElement frame)
            {
                frame.Switch();
                context = frame.Driver as ISearchContext;
            }
            else
            {
                context = parent.Context;
            }

            var element = context.FindElement(locator.Cast());
            return Resolve<TElement>(parent.WebDriver, element, locator);
        }

        private TElement Resolve<TElement>(WebDriver driver, IWebElement element, Locator locator) where TElement : IElement => _scope.Resolve<TElement>
                (
                    new TypedParameter(typeof(WebDriver), driver),
                    new TypedParameter(typeof(IWebElement), element),
                    new TypedParameter(typeof(Locator), locator),
                    new TypedParameter(typeof(ILifetimeScope), _scope)
                );
    }
}
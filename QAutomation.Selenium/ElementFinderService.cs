namespace QAutomation.Selenium
{
    using System.Collections.Generic;
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Selenium.Controls;
    using global::Unity;
    using global::Unity.Resolution;

    public class ElementFinderService
    {
        private readonly IUnityContainer container;

        public ElementFinderService(IUnityContainer container)
        {
            this.container = container;
        }

        public TElement Find<TElement>(WebDriver driver, Core.Locator locator)
            where TElement : IElement
        {
            var element = driver.WrappedDriver.FindElement(locator.Cast());
            return this.Resolve<TElement>(driver, element, locator);
        }

        public IEnumerable<TElement> FindAll<TElement>(WebDriver driver, Core.Locator locator)
            where TElement : IElement
        {
            var elements = driver.WrappedDriver.FindElements(locator.Cast());
            var list = new List<TElement>();

            for (int i = 0; i < elements.Count; i++)
            {
                IWebElement element = elements[i];
                list.Add(item: this.Resolve<TElement>(driver, element, locator));
            }

            return list;
        }

        public IEnumerable<TElement> FindAll<TElement>(Element parent, Core.Locator locator)
            where TElement : IElement
        {
            ISearchContext context = null;

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
                list.Add(item: this.Resolve<TElement>(parent.WebDriver, element, locator));
            }

            return list;
        }

        public TElement Find<TElement>(Element parent, Core.Locator locator)
            where TElement : IElement
        {
            ISearchContext context = null;

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
            return this.Resolve<TElement>(parent.WebDriver, element, locator);
        }

        private TElement Resolve<TElement>(WebDriver driver, IWebElement current, Core.Locator locator) where TElement : IElement
        {
            return this.container.Resolve<TElement>(new ResolverOverride[]
            {
                 new ParameterOverride("driver", driver),
                 new ParameterOverride("element", current),
                 new ParameterOverride("locator", locator),
                 new ParameterOverride("container", this.container)
            });
        }
    }
}
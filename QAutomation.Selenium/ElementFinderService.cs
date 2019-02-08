namespace QAutomation.Selenium
{
    using System.Collections.Generic;
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Selenium.Controls;
    using global::Unity;
    using global::Unity.Resolution;

    internal class ElementFinderService
    {
        private readonly IUnityContainer container;

        public ElementFinderService(IUnityContainer container)
        {
            this.container = container;
        }

        public TElement Find<TElement>(WebDriver driver, Core.Locator by)
            where TElement : IElement
        {
            var element = driver.Driver.FindElement(by.Cast());
            return this.Resolve<TElement>(driver, element, by);
        }

        public IEnumerable<TElement> FindAll<TElement>(WebDriver driver, Core.Locator by)
            where TElement : IElement
        {
            var elements = driver.Driver.FindElements(by.Cast());

            var list = new List<TElement>();

            for (int i = 0; i < elements.Count; i++)
            {
                IWebElement element = elements[i];
                list.Add(item: this.Resolve<TElement>(driver, element, by));
            }

            return list;
        }

        public IEnumerable<TElement> FindAll<TElement>(Element parent, Core.Locator by)
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

            var elements = context.FindElements(by.Cast());

            var list = new List<TElement>();

            for (int i = 0; i < elements.Count; i++)
            {
                IWebElement element = elements[i];
                list.Add(item: this.Resolve<TElement>(parent.WebDriver, element, by));
            }

            return list;
        }

        public TElement Find<TElement>(Element parent, Core.Locator by)
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

            var element = context.FindElement(by.Cast());
            return this.Resolve<TElement>(parent.WebDriver, element, by);
        }

        private TElement Resolve<TElement>(WebDriver driver, IWebElement current, Core.Locator by) where TElement : IElement
        {
            return this.container.Resolve<TElement>(new ResolverOverride[]
            {
                 new ParameterOverride("driver", driver),
                 new ParameterOverride("element", current),
                 new ParameterOverride("locator", by),
                 new ParameterOverride("container", this.container)
            });
        }
    }
}
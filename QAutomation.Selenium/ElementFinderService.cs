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

        public TElement Find<TElement>(WebDriver driver, ISearchContext context, Core.By by)
            where TElement : IElement
        {
            var current = context ?? driver.Driver;
            var element = current.FindElement(by.Cast());

            return Resolve<TElement>(driver.Driver, element, by);
        }

        public IEnumerable<TElement> FindAll<TElement>(WebDriver driver, ISearchContext context, Core.By by)
            where TElement : class, IElement
        {
            var current = context ?? driver.Driver;
            var elements = current.FindElements(by.Cast());

            var list = new List<TElement>();

            foreach (var element in elements)
                list.Add(Resolve<TElement>(driver.Driver, element, by));

            return list;
        }

        public IEnumerable<TElement> FindAll<TElement>(Element parent, Core.By by)
            where TElement : IElement
        {
            ISearchContext context = null;

            if (parent is IFrameElement frame)
            {
                parent.WebDriver.SwitchTo().Frame(parent.Locator);
                context = parent.WebDriver.Driver;
                parent.WebDriver.CurrentFrame = frame;
            }
            else
                context = parent.Context;

            var elements = context.FindElements(by.Cast());

            var list = new List<TElement>();

            foreach (var element in elements)
                list.Add(Resolve<TElement>(parent.Driver, element, by));

            return list;
        }

        public TElement Find<TElement>(Element parent, Core.By by)
            where TElement : IElement
        {
            ISearchContext context = null;

            if (parent is IFrameElement frame)
            {
                parent.WebDriver.SwitchTo().Frame(frame.Locator);
                //context = parent.Driver.SwitchTo().Frame(frame.GetAttribute("name"));
                //parent.WebDriver.CurrentFrame = frame;
            }
            else
                context = parent.Context;

            var element = context.FindElement(by.Cast());
            return Resolve<TElement>(parent.Driver, element, by);
        }

        private TElement Resolve<TElement>(IWebDriver driver, IWebElement current, Core.By by)
            where TElement : IElement
        {
            return _container.Resolve<TElement>(new ResolverOverride[]
            {
                new ParameterOverride("element", current),
                new ParameterOverride("container", _container),
                new ParameterOverride("locator", by),
                new ParameterOverride("driver", driver)
            });
        }
    }
}

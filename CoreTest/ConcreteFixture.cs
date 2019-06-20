namespace Test
{
    using Autofac;
    using NUnit.Framework;
    using QAutomation.Core;
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;

    [TestFixture]
    public class ConcreteFixture : BaseTestFixture
    {
        public override void SetUp()
        {
            base.SetUp();
            var driver = LifetimeScope.Resolve<IDriver>();

            driver.Navigate().Url("https://learn.javascript.ru/uibasic");

            driver.Find<IElement>(Locator.CssSelector(".toolbar__tool > a")).Click();

            var alert = driver.SwitchTo().Alert();

            var cookie = driver.Manage().Cookies().GetAll();

            var d = driver.SwitchTo().DefaultContent();

            var window = driver.Manage().Windows().Current;
            var title = driver.ExecuteJavaScript<string>("return document.readyState;");
        }

        [Test]
        public void Test()
        {
            var driver = LifetimeScope.Resolve<IDriver>();

            driver.Manage().Windows().Current.Maximize();

            var element = driver.Find<IElement>(Locator.CssSelector(".onliner_logo"));

            Assert.AreEqual(element.Size, new Size(140, 80));
        }

        public override void TearDown()
        {
            try
            {
                LifetimeScope.Resolve<IDriver>().Quit();
            }
            finally { base.TearDown(); }
        }
    }
}

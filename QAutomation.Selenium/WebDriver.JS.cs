namespace QAutomation.Selenium
{
    using QAutomation.Core;
    using QAutomation.Core.Interfaces;
    using QAutomation.Selenium.Controls;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public partial class WebDriver : IJavaScriptExecutor
    {
        public void ExecuteJavaScript(string script) => ExecuteJavaScript(script, (object[])null);

        public void ExecuteJavaScript(string script, object[] args)
            => ((OpenQA.Selenium.IJavaScriptExecutor)Driver).ExecuteAsyncScript(script, args);

        //public void ExecuteJavaScript(string script, By locator) => ExecuteJavaScript(script, new By[] { locator });

        //public void ExecuteJavaScript(string script, By[] locators) => ExecuteJavaScript(script, FindIWebElements(locators));
      

        public T ExecuteJavaScript<T>(string script) => ExecuteJavaScript<T>(script, (object[])null);

        //public T ExecuteJavaScript<T>(string script, By locator) => ExecuteJavaScript<T>(script, new By[] { locator });

        //public T ExecuteJavaScript<T>(string script, By[] locators) => ExecuteJavaScript<T>(script, FindIWebElements(locators));
       

        public T ExecuteJavaScript<T>(string script, object[] args)
            => (T)((OpenQA.Selenium.IJavaScriptExecutor)Driver).ExecuteAsyncScript(script, args);

        //private object[] FindIWebElements(By[] locators)
        //    => Array.ConvertAll(locators.Select(l => _finderService.Find<Element>(this, l).WrappedElement).ToArray(), e=>(object) e);
    }
}

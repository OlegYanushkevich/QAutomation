namespace QAutomation.Selenium
{
    using QAutomation.Core.Interfaces;
    using System;

    public partial class WebDriver : IJavaScriptExecutor
    {
        public void ExecuteJavaScript(string script) => ExecuteJavaScript(script, args: Array.Empty<object>());

        public void ExecuteJavaScript(string script, object[] args) => ExecuteJavaScript<object>(script, args);

        public T ExecuteJavaScript<T>(string script) => ExecuteJavaScript<T>(script, Array.Empty<object>());

        public T ExecuteJavaScript<T>(string script, object[] args) => (T)((OpenQA.Selenium.IJavaScriptExecutor)WrappedDriver).ExecuteAsyncScript(script, args);
    }
}

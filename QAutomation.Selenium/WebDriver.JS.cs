namespace QAutomation.Selenium
{
    using QAutomation.Core.Interfaces;

    public partial class WebDriver : IJavaScriptExecutor
    {
        public void ExecuteJavaScript(string script) => this.ExecuteJavaScript(script, (object[])null);

        public void ExecuteJavaScript(string script, object[] args) => this.ExecuteJavaScript<object>(script, args);

        public T ExecuteJavaScript<T>(string script) => this.ExecuteJavaScript<T>(script, (object[])null);

        public T ExecuteJavaScript<T>(string script, object[] args) => (T)((OpenQA.Selenium.IJavaScriptExecutor)WrappedDriver).ExecuteAsyncScript(script, args);
    }
}

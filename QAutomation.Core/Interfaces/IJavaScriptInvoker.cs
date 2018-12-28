namespace QAutomation.Core.Interfaces
{
    public interface IJavaScriptExecutor
    {
        void ExecuteJavaScript(string script);
        void ExecuteJavaScript(string script, object[] args);

        void ExecuteJavaScript(string script, By locator);
        void ExecuteJavaScript(string script, By[] locators);

        T ExecuteJavaScript<T>(string script);
        T ExecuteJavaScript<T>(string script, object[] args);

        T ExecuteJavaScript<T>(string script, By locator);
        T ExecuteJavaScript<T>(string script, By[] locators);
    }
}

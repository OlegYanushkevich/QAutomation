namespace QAutomation.Core.Interfaces
{
    public interface IJavaScriptExecutor
    {
        T ExecuteJavaScript<T>(string script);
    }
}

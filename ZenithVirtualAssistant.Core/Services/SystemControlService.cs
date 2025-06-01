using System.Diagnostics;

namespace ZenithVirtualAssistant.Core.Services;

public class SystemControlService
{
    public void OpenApplication(string appName)
    {
        try
        {
            Process.Start(appName);
        }
        catch
        {
            // Handle errors
        }
    }

    public void Shutdown()
    {
        Process.Start("shutdown", "/s /t 0");
    }

    public void Restart()
    {
        Process.Start("shutdown", "/r /t 0");
    }
}
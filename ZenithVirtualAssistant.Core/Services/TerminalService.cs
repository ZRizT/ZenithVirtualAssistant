using System.Diagnostics;

namespace ZenithVirtualAssistant.Core.Services;

public class TerminalService
{
    public void OpenTerminal(string terminalType)
    {
        string processName = terminalType.ToLower() switch
        {
            "cmd" => "cmd.exe",
            "powershell" => "powershell.exe",
            "gitbash" => @"C:\Program Files\Git\git-bash.exe",
            "wsl" => "wsl.exe",
            _ => "cmd.exe"
        };

        Process.Start(processName);
    }
}
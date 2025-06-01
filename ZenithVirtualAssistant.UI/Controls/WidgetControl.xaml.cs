using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using ZenithVirtualAssistant.Core.Services;

namespace ZenithVirtualAssistant.UI.Controls;

public sealed partial class WidgetControl : UserControl
{
    private readonly SystemControlService _systemService = new();
    private readonly TerminalService _terminalService = new();

    public WidgetControl()
    {
        InitializeComponent();
    }

    private void OpenTerminal_Click(object sender, RoutedEventArgs e)
    {
        _terminalService.OpenTerminal("cmd");
    }

    private void OpenNotepad_Click(object sender, RoutedEventArgs e)
    {
        _systemService.OpenApplication("notepad.exe");
    }

    private void Shutdown_Click(object sender, RoutedEventArgs e)
    {
        _systemService.Shutdown();
    }
}
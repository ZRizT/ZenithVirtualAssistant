namespace ZenithVirtualAssistant.Core.Models;

public class Command
{
    public int Id { get; set; }
    public string Trigger { get; set; } = string.Empty;
    public string Action { get; set; } = string.Empty;
    public string Response { get; set; } = string.Empty;
}
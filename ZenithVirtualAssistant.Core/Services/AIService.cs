using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ZenithVirtualAssistant.Core.Services;

public class AIService
{
    private readonly HttpClient _httpClient;
    private const string OllamaEndpoint = "http://localhost:11434/api/generate";

    public AIService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<string> ProcessCommandAsync(string command)
    {
        if (!command.StartsWith("zenith", StringComparison.OrdinalIgnoreCase))
            return string.Empty;

        if (command.Equals("zenith wake up", StringComparison.OrdinalIgnoreCase))
            return "Zenith AI is awake! How can I assist you?";

        var requestBody = new
        {
            model = "llama3",
            prompt = command.Replace("zenith", "", StringComparison.OrdinalIgnoreCase).Trim()
        };

        var content = new StringContent(
            System.Text.Json.JsonSerializer.Serialize(requestBody),
            Encoding.UTF8,
            "application/json");

        var response = await _httpClient.PostAsync(OllamaEndpoint, content);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        return responseContent; // Simplified; parse actual Ollama response as needed
    }
}
using Microsoft.Extensions.AI;

namespace Pixeval.Extensions.Translators.Ollama;

public class OllamaTranslateService
{
    public string SystemInstruction { get; set; } = "";

    public string ModelName { get; set; } = "";

    public int Port { get; set; }

    public async Task<string?> TranslateAsync(string originalStream)
    {
        var client = new OllamaChatClient(new Uri($"http://localhost:{Port}/"), ModelName);
        var response = await client.GetResponseAsync(SystemInstruction + originalStream);
        return response.Message.Text;
    }
}


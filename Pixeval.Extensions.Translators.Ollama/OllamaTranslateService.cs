using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.AI;

namespace Pixeval.Extensions.Translators.Ollama;

public class OllamaTranslateService
{
    public string SystemInstruction { get; set; } = null!;
    public string ModelName { get; set; } = null!;
    public async Task<string> TranslateAsync(string originalStream)
    {
        IChatClient client =
            new OllamaChatClient(new Uri("http://localhost:11434/"), ModelName);
        var response = await client.GetResponseAsync(SystemInstruction + originalStream);
        return response.Message.Text;
    }
}


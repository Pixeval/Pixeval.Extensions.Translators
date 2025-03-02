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
        return RemoveTags(response.Message.Text);
    }
    public static string? RemoveTags(string? input)
    {
        if (string.IsNullOrEmpty(input)) return input;
        const string startTag = "<think>";
        const string endTag = "</think>";

        if (!input.StartsWith(startTag)) return input;
        var endIndex = input.IndexOf(endTag, startTag.Length, StringComparison.Ordinal);
        return endIndex == -1 ? input : input[(endIndex + endTag.Length)..];
    }
}


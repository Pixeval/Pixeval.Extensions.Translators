using System.Text.Json.Serialization;

namespace Pixeval.Extensions.Translators.DeepLX.Translators.Network;

public class DeepLXTranslateRequest
{
    [JsonPropertyName("text")]
    public required string Text { get; set; }

    [JsonPropertyName("source_lang")]
    public string? SourceLang { get; set; }

    [JsonPropertyName("target_lang")]
    public required string TargetLang { get; set; }
}

using System.Text.Json.Serialization;

namespace Pixeval.Extensions.Translators.DeepLX.Translators.Network;

public class DeepLXTranslateResponse
{
    [JsonPropertyName("alternatives")]
    public required string[] Alternatives { get; set; }

    [JsonPropertyName("data")]
    public required string Data { get; set; }

    [JsonPropertyName("source_lang")]
    public required string SourceLang { get; set; }

    [JsonPropertyName("target_lang")]
    public required string TargetLang { get; set; }
}

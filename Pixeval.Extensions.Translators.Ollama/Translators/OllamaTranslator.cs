using System.Runtime.InteropServices.Marshalling;
using FluentIcons.Common;
using Pixeval.Extensions.Common.Commands.Transformers;
using Pixeval.Extensions.SDK.Transformers;

namespace Pixeval.Extensions.Translators.Ollama.Translators;

[GeneratedComClass]
public partial class OllamaTranslator : TextTransformerCommandExtensionBase
{
    public string TargetLanguage { get; set; } = null!;

    public override Symbol Icon => Symbol.Translate;

    public override string Label => "翻译";

    public override string Description => Label;

    public static OllamaTranslateService TranslateService { get; private set; } = null!;

    public override void OnExtensionLoaded()
    {
        TranslateService = new OllamaTranslateService();
    }

    public override void OnExtensionUnloaded()
    {
        TranslateService = null!;
    }

    public override async Task<string?> TransformAsync(string originalStream, TextTransformerType type)
    {
        return await TranslateService.TranslateAsync(originalStream);
    }
}

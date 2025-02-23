using System.Runtime.InteropServices.Marshalling;
using FluentIcons.Common;
using Pixeval.Extensions.Common.Commands.Transformers;
using Pixeval.Extensions.SDK.Transformers;

namespace Pixeval.Extensions.Translators.DeepLX.Translators;

[GeneratedComClass]
public partial class DeepLXTranslator : TextTransformerCommandExtensionBase
{
    public override Symbol Icon => Symbol.Translate;

    public override string Label => "翻译";

    public override string Description => Label;

    public override void OnExtensionLoaded()
    {
        TranslateService = new();
    }

    public override void OnExtensionUnloaded()
    {
        TranslateService = null!;
    }

    public override Task<string?> TransformAsync(string originalStream, TextTransformerType type)
    {
        return TranslateService.TranslateAsync(originalStream);
    }

    public static DeepLXTranslateService TranslateService { get; private set; } = null!;
}

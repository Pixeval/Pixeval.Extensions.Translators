using System.Globalization;
using DeepL;
using FluentIcons.Common;
using Pixeval.Extensions.Common.Commands.Transformers;
using Pixeval.Extensions.SDK.Transformers;
using System.Runtime.InteropServices.Marshalling;

namespace Pixeval.Extensions.Translators.DeepL.Translators;

[GeneratedComClass]
public partial class DeepLTranslator : TextTransformerCommandExtensionBase
{
    public static string AuthKey { get; set; } = "";

    public override Symbol Icon => Symbol.Translate;

    public override string Label => "翻译";

    public override string Description => Label;

    public override void OnExtensionLoaded()
    {
    }

    public override void OnExtensionUnloaded()
    {
    }

    public override async Task<string?> TransformAsync(string originalStream, TextTransformerType type)
    {
        var translator = new Translator(AuthKey);
        var translatedText = await translator.TranslateTextAsync(
            originalStream, null, CultureInfo.CurrentCulture.Name);
        return translatedText.Text;
    }
}

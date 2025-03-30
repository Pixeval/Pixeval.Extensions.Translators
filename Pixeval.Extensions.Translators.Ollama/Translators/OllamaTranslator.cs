using System.Runtime.InteropServices.Marshalling;
using FluentIcons.Common;
using Microsoft.Extensions.AI;
using Pixeval.Extensions.Common.Commands.Transformers;
using Pixeval.Extensions.SDK.Transformers;

namespace Pixeval.Extensions.Translators.Ollama.Translators;

[GeneratedComClass]
public partial class OllamaTranslator : TextTransformerCommandExtensionBase
{
    public static string SystemInstruction { get; set; } = "";

    public static string ModelName
    {
        get;
        set
        {
            if (field == value)
                return;
            field = value;
            DisposeClient();
        }
    } = "";

    public static int Port
    {
        get;
        set
        {
            if (field == value)
                return;
            field = value;
            DisposeClient();
        }
    }

    public override Symbol Icon => Symbol.Translate;

    public override string Label => "Ollama 翻译";

    public override string Description => Label;

    public static OllamaChatClient? TranslatorCache { get; private set; }

    public override void OnExtensionUnloaded()
    {
        DisposeClient();
    }

    public override async Task<string?> TransformAsync(string originalStream, TextTransformerType type)
    {
        TranslatorCache ??= new(new Uri($"http://localhost:{Port}/"), ModelName);
        var response = await TranslatorCache.GetResponseAsync(SystemInstruction + originalStream);
        return RemoveTags(response.Text);

        static string? RemoveTags(string? input)
        {
            if (string.IsNullOrEmpty(input))
                return input;
            const string startTag = "<think>";
            const string endTag = "</think>";

            if (!input.StartsWith(startTag))
                return input;
            var endIndex = input.IndexOf(endTag, startTag.Length, StringComparison.Ordinal);
            return endIndex is -1 ? input : input[(endIndex + endTag.Length)..];
        }
    }

    private static void DisposeClient()
    {
        TranslatorCache?.Dispose();
        TranslatorCache = null;
    }
}

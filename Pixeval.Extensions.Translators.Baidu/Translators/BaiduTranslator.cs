using System.Globalization;
using System.Runtime.InteropServices.Marshalling;
using FluentIcons.Common;
using Pixeval.Extensions.Common.Commands.Transformers;
using Pixeval.Extensions.SDK.Transformers;
using Pixeval.Extensions.Translators.Baidu.Client;
using Pixeval.Extensions.Translators.Baidu.Strings;

namespace Pixeval.Extensions.Translators.Baidu.Translators;

[GeneratedComClass]
public partial class BaiduTranslator : TextTransformerCommandExtensionBase
{
    public override Symbol Icon => Symbol.Translate;

    public override string Label => Resource.BaiduTranslatorLabel;

    public override string Description => Label;

    public override void OnExtensionLoaded()
    {
        TranslateService = new();
    }

    public override void OnExtensionUnloaded()
    {
        TranslateService.Dispose();
        TranslateService = null!;
    }

    public override async Task<string?> TransformAsync(string originalStream, TextTransformerType type)
    {
        var data = await TranslateService.Translate(originalStream, CultureInfo.CurrentCulture.Name.Split('-')[0]);
        return data.Success ? data.Trans_Result[0].Dst : data.Error_Msg;
    }

    public static BaiduTranslatorClient TranslateService { get; private set; } = null!;
}

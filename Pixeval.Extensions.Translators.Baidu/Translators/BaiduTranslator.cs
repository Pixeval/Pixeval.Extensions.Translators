using System.Globalization;
using System.Runtime.InteropServices.Marshalling;
using FluentIcons.Common;
using Pixeval.Extensions.Common.Commands.Transformers;
using Pixeval.Extensions.SDK.Transformers;
using Pixeval.Extensions.Translators.Baidu.Client;

namespace Pixeval.Extensions.Translators.Baidu.Translators;

[GeneratedComClass]
public partial class BaiduTranslator : TextTransformerCommandExtensionBase
{
    public override Symbol Icon => Symbol.Translate;

    public override string Label => "翻译";

    public override string Description => Label;

    public override async Task<string?> TransformAsync(string originalStream, TextTransformerType type)
    {
        var translator = new BaiduTranslatorClient();
        var data = await translator.Translate(originalStream, CultureInfo.CurrentCulture.Name.Split('-')[0]);
        if (!data.Success)
            return "翻译失败:" + data.Error_Msg;
        return data.Trans_Result[0].Dst;
    }
}

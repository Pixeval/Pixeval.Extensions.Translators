using System.Runtime.InteropServices.Marshalling;
using FluentIcons.Common;
using Pixeval.Extensions.SDK.Settings;
using Pixeval.Extensions.Translators.Baidu.Client;
using Pixeval.Extensions.Translators.Baidu.Strings;

namespace Pixeval.Extensions.Translators.Baidu.Settings;

[GeneratedComClass]
public partial class ApiKeySettingsExtension : StringSettingsExtensionBase
{
    public override string DefaultValue => "";

    public override void OnValueChanged(string value)
    {
        BaiduTranslatorClient.SecretKey = value;
    }

    public override string Placeholder => "API Key";

    public override Symbol Icon => Symbol.Key;

    public override string Label => Resource.ApiKeySettingsLabel;

    public override string Description => Resource.ApiKeySettingsDescription;

    public override string DescriptionUri => "https://github.com/Pixeval/Pixeval.Extensions.Translators/wiki/百度翻译密钥获取教程";

    public override string Token => "Key";
}

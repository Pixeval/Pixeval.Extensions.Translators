using System.Runtime.InteropServices.Marshalling;
using FluentIcons.Common;
using Pixeval.Extensions.SDK.Settings;

namespace Pixeval.Extensions.Translators.Baidu.Settings;

[GeneratedComClass]
public partial class ApiKeySettingsExtension : StringSettingsExtensionBase
{
    public override string DefaultValue => "";

    public override void OnValueChanged(string value)
    {
        ExtensionsHost.Current.Translator.AuthKey = value;
    }

    public override string Placeholder => "API Key";

    public override void OnExtensionLoaded()
    {
    }

    public override void OnExtensionUnloaded()
    {
    }

    public override Symbol Icon => Symbol.Key;

    public override string Label => "密钥";

    public override string Description => "百度翻译 API KEY，点击查看获取教程";

    public override string DescriptionUri => "https://github.com/Pixeval/Pixeval.Extensions.Translators/wiki/百度翻译密钥获取教程";

    public override string Token => "Key";
}

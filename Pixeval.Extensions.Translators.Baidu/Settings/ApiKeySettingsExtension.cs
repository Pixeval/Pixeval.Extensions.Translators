using System.Runtime.InteropServices.Marshalling;
using FluentIcons.Common;
using Pixeval.Extensions.Common.Settings;
using Pixeval.Extensions.SDK.Settings;

namespace Pixeval.Extensions.Translators.Baidu.Settings;

[GeneratedComClass]
public partial class ApiKeySettingsExtension:StringSettingsExtensionBase
{
    public override string GetDefaultValue() => "";

    public override void OnValueChanged(string value)
    {
        ExtensionsHost.Current.Translator.AuthKey = value;
    }

    public override string? Placeholder { get; }

    public override void OnExtensionLoaded()
    {
    }

    public override void OnExtensionUnloaded()
    {
    }

    public override Symbol Icon => Symbol.Key;
    public override string Label => "密钥";
    public override string Description => "百度翻译 API KEY，点击查看获取教程";
    public override string DescriptionUri => "https://github.com/zxbmmmmmmmmm/Pixeval.Extensions.Translators/wiki/%E7%99%BE%E5%BA%A6%E7%BF%BB%E8%AF%91%E5%AF%86%E9%92%A5%E8%8E%B7%E5%8F%96%E6%95%99%E7%A8%8B";
    public override string Token => "Key";

}
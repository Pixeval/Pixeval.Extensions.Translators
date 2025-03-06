using System.Runtime.InteropServices.Marshalling;
using FluentIcons.Common;
using Pixeval.Extensions.SDK.Settings;
using Pixeval.Extensions.Translators.Baidu.Client;

namespace Pixeval.Extensions.Translators.Baidu.Settings;

[GeneratedComClass]
public partial class AppIdSettingsExtension : StringSettingsExtensionBase
{
    public override string DefaultValue => "";

    public override void OnValueChanged(string value)
    {
        BaiduTranslatorClient.AppId = value;
    }

    public override string Placeholder => Label;

    public override Symbol Icon => Symbol.Document;

    public override string Label => "APP ID";

    public override string Description => Label;

    public override string Token => "AppID";
}

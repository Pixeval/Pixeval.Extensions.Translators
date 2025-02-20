using System.Runtime.InteropServices.Marshalling;
using FluentIcons.Common;
using Pixeval.Extensions.SDK.Settings;

namespace Pixeval.Extensions.Translators.Baidu.Settings;

[GeneratedComClass]
public partial class AppIdSettingsExtension : StringSettingsExtensionBase
{
    public override string GetDefaultValue() => "";

    public override void OnValueChanged(string value)
    {
        ExtensionsHost.Current.Translator.AppId = value;
    }

    public override string? Placeholder => "APP ID";

    public override void OnExtensionLoaded()
    {
    }

    public override void OnExtensionUnloaded()
    {
    }

    public override Symbol Icon => Symbol.Document;

    public override string Label => "APP ID";

    public override string Description => Label;

    public override string Token => "AppID";
}

using System.Runtime.InteropServices.Marshalling;
using FluentIcons.Common;
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

    public override Symbol Icon => Symbol.Document;
    public override string Label => "AppID";
    public override string Description => Label;
    public override string Token => "AppID";
}
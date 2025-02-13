using FluentIcons.Common;
using Pixeval.Extensions.SDK.Settings;
using System.Runtime.InteropServices.Marshalling;

namespace Pixeval.Extensions.Translators.DeepL.Settings;

[GeneratedComClass]
public partial class ApiKeySettingsExtension : StringSettingsExtensionBase
{
    public override string GetDefaultValue() => "";

    public override void OnValueChanged(string value)
    {
        ExtensionsHost.Current.Translator.AuthKey = value;
    }

    public override string? Placeholder => "API Key";

    public override void OnExtensionLoaded()
    {
    }

    public override void OnExtensionUnloaded()
    {
    }

    public override Symbol Icon => Symbol.Key;

    public override string Label => "API Key";

    public override string Description => "DeepL API Key";

    public override string Token => "Key";
}

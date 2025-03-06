using FluentIcons.Common;
using Pixeval.Extensions.SDK.Settings;
using System.Runtime.InteropServices.Marshalling;
using Pixeval.Extensions.Translators.DeepL.Translators;

namespace Pixeval.Extensions.Translators.DeepL.Settings;

[GeneratedComClass]
public partial class ApiKeySettingsExtension : StringSettingsExtensionBase
{
    public override string DefaultValue => "";

    public override void OnValueChanged(string value)
    {
        DeepLTranslator.AuthKey = value;
    }

    public override string Placeholder => "API Key";

    public override Symbol Icon => Symbol.Key;

    public override string Label => "API Key";

    public override string Description => "DeepL API Key";

    public override string Token => "Key";
}

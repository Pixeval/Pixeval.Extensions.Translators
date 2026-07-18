using System.Runtime.InteropServices.Marshalling;
using FluentIcons.Common;
using Pixeval.Extensions.SDK.Settings;
using Pixeval.Extensions.Translators.DeepL.Strings;
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

    public override string Placeholder => Label;

    public override Symbol Icon => Symbol.Key;

    public override string Label => Resource.ApiKeySettingsLabel;

    public override string Description => Resource.ApiKeySettingsDescription;

    public override string Token => "Key";
}

using System.Runtime.InteropServices.Marshalling;
using FluentIcons.Common;
using Pixeval.Extensions.SDK.Settings;
using Pixeval.Extensions.Translators.DeepLX.Strings;
using Pixeval.Extensions.Translators.DeepLX.Translators;

namespace Pixeval.Extensions.Translators.DeepLX.Settings;

[GeneratedComClass]
public partial class AccessTokenSettingsExtension : StringSettingsExtensionBase
{
    public override string DefaultValue => "";

    public override void OnValueChanged(string value)
    {
        DeepLXTranslator.TranslateService.AccessToken = value;
    }

    public override string Placeholder => Label;

    public override Symbol Icon => Symbol.Key;

    public override string Label => "Access Token";

    public override string Description => Resource.AccessTokenSettingsDescription;

    public override string Token => "AccessToken";
}

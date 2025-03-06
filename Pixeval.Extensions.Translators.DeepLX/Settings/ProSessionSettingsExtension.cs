
using System.Runtime.InteropServices.Marshalling;
using FluentIcons.Common;
using Pixeval.Extensions.SDK.Settings;
using Pixeval.Extensions.Translators.DeepLX.Strings;
using Pixeval.Extensions.Translators.DeepLX.Translators;

namespace Pixeval.Extensions.Translators.DeepLX.Settings;

[GeneratedComClass]
public partial class ProSessionSettingsExtension : StringSettingsExtensionBase
{
    public override string DefaultValue => "";

    public override void OnValueChanged(string value)
    {
        DeepLXTranslator.TranslateService.ProSession = value;
    }

    public override string Placeholder => Label;

    public override Symbol Icon => Symbol.PersonKey;

    public override string Label => "dl session";

    public override string Description => Resource.ProSessionSettingsDescription;

    public override string Token => "DlSession";
}

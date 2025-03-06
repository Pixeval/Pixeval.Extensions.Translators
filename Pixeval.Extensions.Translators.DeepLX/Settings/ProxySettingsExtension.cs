using System.Runtime.InteropServices.Marshalling;
using FluentIcons.Common;
using Pixeval.Extensions.SDK.Settings;
using Pixeval.Extensions.Translators.DeepLX.Strings;
using Pixeval.Extensions.Translators.DeepLX.Translators;

namespace Pixeval.Extensions.Translators.DeepLX.Settings;

[GeneratedComClass]
public partial class ProxySettingsExtension : StringSettingsExtensionBase
{
    public override string DefaultValue => "";

    public override void OnValueChanged(string value)
    {
        DeepLXTranslator.TranslateService.Proxy = value;
    }

    public override string Placeholder => Label;

    public override Symbol Icon => Symbol.Server;

    public override string Label => Resource.ProxySettingsLabel;

    public override string Description => Resource.ProxySettingsDescription;

    public override string Token => "Proxy";
}

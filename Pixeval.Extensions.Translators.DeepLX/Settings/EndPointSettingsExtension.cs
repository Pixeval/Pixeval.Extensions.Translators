using System.Runtime.InteropServices.Marshalling;
using FluentIcons.Common;
using Pixeval.Extensions.SDK.Settings;
using Pixeval.Extensions.Translators.DeepLX.Strings;
using Pixeval.Extensions.Translators.DeepLX.Translators;

namespace Pixeval.Extensions.Translators.DeepLX.Settings;

[GeneratedComClass]
public partial class EndPointSettingsExtension : StringSettingsExtensionBase
{
    public override string DefaultValue => "";

    public override void OnValueChanged(string value)
    {
        DeepLXTranslator.TranslateService.EndPoint = value;
    }

    public override string Placeholder => Label;

    public override Symbol Icon => Symbol.PointScan;

    public override string Label => Resource.EndPointSettingsLabel;

    public override string Description => Resource.EndPointSettingsDescription;

    public override string Token => "EndPoint";
}

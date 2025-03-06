using System.Runtime.InteropServices.Marshalling;
using FluentIcons.Common;
using Pixeval.Extensions.SDK.Settings;
using Pixeval.Extensions.Translators.DeepLX.Strings;
using Pixeval.Extensions.Translators.DeepLX.Translators;

namespace Pixeval.Extensions.Translators.DeepLX.Settings;

[GeneratedComClass]
public partial class TimeoutSettingsExtension : IntSettingsExtensionBase
{
    public override int DefaultValue => 180;

    public override int MinValue => 10;

    public override int MaxValue => 6000;

    public override void OnValueChanged(int value)
    {
        DeepLXTranslator.TranslateService.Timeout = value;
    }

    public override string Placeholder => Label;

    public override Symbol Icon => Symbol.Timer;

    public override string Label => Resource.TimeoutSettingsLabel;

    public override string Description => Resource.TimeoutSettingsDescription;

    public override string Token => "Timeout";
}

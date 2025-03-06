using System.Runtime.InteropServices.Marshalling;
using FluentIcons.Common;
using Pixeval.Extensions.SDK.Settings;
using Pixeval.Extensions.Translators.DeepLX.Strings;
using Pixeval.Extensions.Translators.DeepLX.Translators;

namespace Pixeval.Extensions.Translators.DeepLX.Settings;

[GeneratedComClass]
public partial class PortSettingsExtension : IntSettingsExtensionBase
{
    public override int DefaultValue => 1188;

    public override int MinValue => 1024;

    public override int MaxValue => ushort.MaxValue;

    public override void OnValueChanged(int value)
    {
        DeepLXTranslator.TranslateService.Port = value;
    }

    public override string Placeholder => Label;

    public override Symbol Icon => Symbol.SerialPort;

    public override string Label => Resource.PortSettingsLabel;

    public override string Description => Resource.PortSettingsDescription;

    public override string Token => "Port";
}

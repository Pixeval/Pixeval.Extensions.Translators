using System.Runtime.InteropServices.Marshalling;
using FluentIcons.Common;
using Pixeval.Extensions.SDK.Settings;
using Pixeval.Extensions.Translators.Ollama.Strings;
using Pixeval.Extensions.Translators.Ollama.Translators;

namespace Pixeval.Extensions.Translators.Ollama.Settings;

[GeneratedComClass]
public partial class PortSettingsExtension : IntSettingsExtensionBase
{
    public override int DefaultValue => 11434;

    public override int MinValue => 1024;

    public override int MaxValue => ushort.MaxValue;

    public override void OnValueChanged(int value)
    {
        OllamaTranslator.Port = value;
    }

    public override string Placeholder => Resource.PortSettingsLabel;

    public override Symbol Icon => Symbol.SerialPort;

    public override string Label => Resource.PortSettingsLabel;

    public override string Description => Resource.PortSettingsDescription;

    public override string Token => "Port";
}

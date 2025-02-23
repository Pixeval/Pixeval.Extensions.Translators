using System.Runtime.InteropServices.Marshalling;
using FluentIcons.Common;
using Pixeval.Extensions.SDK.Settings;
using Pixeval.Extensions.Translators.Ollama.Translators;

namespace Pixeval.Extensions.Translators.DeepLX.Settings;

[GeneratedComClass]
public partial class PortSettingsExtension : IntSettingsExtensionBase
{
    public override int DefaultValue => 11434;

    public override int MinValue => 1024;

    public override int MaxValue => ushort.MaxValue;

    public override void OnValueChanged(int value)
    {
        OllamaTranslator.TranslateService.Port = value;
    }

    public override string Placeholder => "端口号";

    public override void OnExtensionLoaded()
    {
    }

    public override void OnExtensionUnloaded()
    {
    }

    public override Symbol Icon => Symbol.SerialPort;

    public override string Label => "Ollama端口号";

    public override string Description => "Ollama本地服务器使用的端口号，默认为" + DefaultValue;

    public override string Token => "Port";
}

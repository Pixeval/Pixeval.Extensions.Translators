using System.Runtime.InteropServices.Marshalling;
using FluentIcons.Common;
using Pixeval.Extensions.SDK.Settings;
using Pixeval.Extensions.Translators.Ollama.Translators;

namespace Pixeval.Extensions.Translators.Ollama.Settings;

[GeneratedComClass]
public partial class ModelNameSettingsExtension : StringSettingsExtensionBase
{
    public override string DefaultValue => "";

    public override void OnValueChanged(string value)
    {
        OllamaTranslator.TranslateService.ModelName = value;
    }

    public override string Placeholder => "";

    public override void OnExtensionLoaded()
    {
    }

    public override void OnExtensionUnloaded()
    {
    }

    public override Symbol Icon => Symbol.Rename;

    public override string Label => "Ollama模型名称";

    public override string Description => "通过Ollama调用的模型名称";

    public override string Token => "ModelName";
}

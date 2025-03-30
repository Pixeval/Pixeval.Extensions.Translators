using System.Runtime.InteropServices.Marshalling;
using FluentIcons.Common;
using Pixeval.Extensions.SDK.Settings;
using Pixeval.Extensions.Translators.Ollama.Strings;
using Pixeval.Extensions.Translators.Ollama.Translators;

namespace Pixeval.Extensions.Translators.Ollama.Settings;

[GeneratedComClass]
public partial class ModelNameSettingsExtension : StringSettingsExtensionBase
{
    public override string DefaultValue => "";

    public override void OnValueChanged(string value)
    {
        OllamaTranslator.ModelName = value;
    }

    public override string Placeholder => "";

    public override Symbol Icon => Symbol.Box;

    public override string Label => Resource.ModelNameSettingsLabel;

    public override string Description => Resource.ModelNameSettingsDescription;

    public override string Token => "ModelName";
}

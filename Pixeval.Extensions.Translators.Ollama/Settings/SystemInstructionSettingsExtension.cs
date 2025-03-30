using System.Runtime.InteropServices.Marshalling;
using FluentIcons.Common;
using Pixeval.Extensions.SDK.Settings;
using Pixeval.Extensions.Translators.Ollama.Strings;
using Pixeval.Extensions.Translators.Ollama.Translators;

namespace Pixeval.Extensions.Translators.Ollama.Settings;

[GeneratedComClass]
public partial class SystemInstructionSettingsExtension : StringSettingsExtensionBase
{
    public override string DefaultValue => Resource.SystemInstructionSettingsDefaultValue;

    public override void OnValueChanged(string value)
    {
        OllamaTranslator.SystemInstruction = value;
    }

    public override string Placeholder => Label;

    public override Symbol Icon => Symbol.AnimalDog;

    public override string Label => Resource.SystemInstructionSettingsLabel;

    public override string Description => Resource.SystemInstructionSettingsDescription;

    public override string Token => "SystemInstruction";
}

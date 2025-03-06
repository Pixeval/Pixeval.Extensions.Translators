using System.Runtime.InteropServices.Marshalling;
using FluentIcons.Common;
using Pixeval.Extensions.SDK.Settings;
using Pixeval.Extensions.Translators.Ollama.Translators;

namespace Pixeval.Extensions.Translators.Ollama.Settings;

[GeneratedComClass]
public partial class SystemInstructionSettingsExtension : StringSettingsExtensionBase
{
    public override string DefaultValue => "您翻译用户提供的文本到中文。除了翻译文本本身，不要回复任何无关的内容。";

    public override void OnValueChanged(string value)
    {
        OllamaTranslator.TranslateService.SystemInstruction = value;
    }

    public override string Placeholder => "";

    public override Symbol Icon => Symbol.Key;

    public override string Label => "系统指令";

    public override string Description => "引导模型对话的内容";

    public override string Token => "SystemInstruction";
}

using System.Runtime.InteropServices.Marshalling;
using FluentIcons.Common;
using Pixeval.Extensions.SDK.Settings;
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

    public override string Placeholder => "超时秒数";

    public override Symbol Icon => Symbol.Key;

    public override string Label => "DeepLX请求超时时间";

    public override string Description => "DeepLX请求超时秒数";

    public override string Token => "Timeout";
}

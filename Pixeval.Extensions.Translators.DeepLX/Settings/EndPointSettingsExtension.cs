using System.Runtime.InteropServices.Marshalling;
using FluentIcons.Common;
using Pixeval.Extensions.SDK.Settings;
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

    public override string Placeholder => "代理服务器";

    public override void OnExtensionLoaded()
    {
    }

    public override void OnExtensionUnloaded()
    {
    }

    public override Symbol Icon => Symbol.PointScan;

    public override string Label => "DeepLX服务器地址";

    public override string Description => "留空则会自动创建一个服务器使用，若填入自己的DeepLX服务器地址则不会创建，且以下的设置项都无效";

    public override string Token => "EndPoint";
}

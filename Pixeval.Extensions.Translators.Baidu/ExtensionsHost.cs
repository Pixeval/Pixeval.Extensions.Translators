using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Pixeval.Extensions.Common;
using Pixeval.Extensions.SDK;
using Pixeval.Extensions.Translators.Baidu.Settings;
using Pixeval.Extensions.Translators.Baidu.Translators;

namespace Pixeval.Extensions.Translators.Baidu;

[GeneratedComClass]
public partial class ExtensionsHost:ExtensionsHostBase
{
    public static string TempDirectory { get; private set; } = "";

    public static string ExtensionDirectory { get; private set; } = "";

    public override string ExtensionName => "百度翻译";

    public override string AuthorName => "Betta_Fish";

    public override string ExtensionLink => "https://github.com/zxbmmmmmmmmm";

    public override string HelpLink => "https://github.com/zxbmmmmmmmmm";

    public override string Description => "百度翻译插件，需要手动输入API Key";

    public override byte[]? Icon
    {
        get
        {
            var stream = typeof(ExtensionsHost).Assembly.GetManifestResourceStream("logo");
            if (stream is null)
                return null;
            var array = new byte[stream.Length];
            _ = stream.Read(array);
            return array;
        }
    }

    public override string Version => "1.0.0";
    public static ExtensionsHost Current { get; } = new();

    [UnmanagedCallersOnly(EntryPoint = nameof(DllGetExtensionsHost))]
    private static unsafe int DllGetExtensionsHost(void** ppv)
    {
        return DllGetExtensionsHost(ppv, Current);
    }
    public override IExtension[] Extensions { get; }

    public BaiduTranslator Translator { get; set; }
    public override void Initialize(string cultureName, string tempDirectory, string extensionDirectory)
    {
        TempDirectory = tempDirectory;
        ExtensionDirectory = extensionDirectory;
        CultureInfo.CurrentCulture = CultureInfo.CurrentUICulture = new(cultureName);
        Translator.TargetLanguage = cultureName.Split('-').First();
    }
    public ExtensionsHost()
    {
        Translator = new BaiduTranslator();
        Extensions = [Translator, new AppIdSettingsExtension(), new ApiKeySettingsExtension()];
    }
}
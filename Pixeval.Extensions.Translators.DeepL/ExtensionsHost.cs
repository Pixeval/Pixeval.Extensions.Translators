using Pixeval.Extensions.Common;
using Pixeval.Extensions.SDK;
using Pixeval.Extensions.Translators.DeepL.Settings;
using Pixeval.Extensions.Translators.DeepL.Translators;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Pixeval.Extensions.Translators.DeepL;

[GeneratedComClass]
public partial class ExtensionsHost : ExtensionsHostBase
{
    public static string TempDirectory { get; private set; } = "";

    public static string ExtensionDirectory { get; private set; } = "";

    public override string ExtensionName => "DeepL Translator";

    public override string AuthorName => "Betta_Fish";

    public override string ExtensionLink => "https://github.com/zxbmmmmmmmmm";

    public override string HelpLink => "https://github.com/zxbmmmmmmmmm";

    public override string Description => "DeepL 翻译插件";

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
    private static unsafe int DllGetExtensionsHost(void** ppv) => DllGetExtensionsHost(ppv, Current);

    public override IExtension[] Extensions { get; }

    public DeepLTranslator Translator { get; set; }

    public override void Initialize(string cultureName, string tempDirectory, string extensionDirectory)
    {
        TempDirectory = tempDirectory;
        ExtensionDirectory = extensionDirectory;
        CultureInfo.CurrentCulture = CultureInfo.CurrentUICulture = new(cultureName);
        Translator.TargetLanguage = cultureName;
    }

    public ExtensionsHost()
    {
        Translator = new DeepLTranslator();
        Extensions = [Translator,new ApiKeySettingsExtension()];
    }
}

using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Pixeval.Extensions.Common;
using Pixeval.Extensions.SDK;
using Pixeval.Extensions.Translators.DeepLX.Settings;
using Pixeval.Extensions.Translators.DeepLX.Translators;

namespace Pixeval.Extensions.Translators.DeepLX;

[GeneratedComClass]
public partial class ExtensionsHost : ExtensionsHostBase
{
    public static string TempDirectory { get; private set; } = "";

    public static string ExtensionDirectory { get; private set; } = "";

    public override string ExtensionName => "DeepLX 翻译";

    public override string AuthorName => "扑克";

    public override string ExtensionLink => "https://github.com/Pixeval/Pixeval.Extensions.Translators";

    public override string HelpLink => "https://github.com/Poker-sang";

    public override string Description => "DeepLX 翻译扩展，无需API Key";

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

    public override IExtension[] Extensions { get; } =
    [
        new DeepLXTranslator(),
        new TimeoutSettingsExtension(),
        new EndPointSettingsExtension(),
        new PortSettingsExtension(),
        new ProxySettingsExtension(),
        new AccessTokenSettingsExtension(),
        new ProSessionSettingsExtension()
    ];

    public override void Initialize(string cultureName, string tempDirectory, string extensionDirectory)
    {
        TempDirectory = tempDirectory;
        ExtensionDirectory = extensionDirectory;
        CultureInfo.CurrentCulture = CultureInfo.CurrentUICulture = new(cultureName);
    }
}

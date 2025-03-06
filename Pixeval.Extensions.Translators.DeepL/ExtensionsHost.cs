using Pixeval.Extensions.Common;
using Pixeval.Extensions.SDK;
using Pixeval.Extensions.Translators.DeepL.Settings;
using Pixeval.Extensions.Translators.DeepL.Translators;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Pixeval.Extensions.Translators.DeepL.Strings;

namespace Pixeval.Extensions.Translators.DeepL;

[GeneratedComClass]
public partial class ExtensionsHost : ExtensionsHostBase
{
    public override string ExtensionName => Resource.ExtensionHostName;

    public override string AuthorName => "Betta_Fish";

    public override string ExtensionLink => "https://github.com/Pixeval/Pixeval.Extensions.Translators";

    public override string HelpLink => "https://github.com/zxbmmmmmmmmm";

    public override string Description => Resource.ExtensionHostDescription;

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
        new DeepLTranslator(),
        new ApiKeySettingsExtension()
    ];
}

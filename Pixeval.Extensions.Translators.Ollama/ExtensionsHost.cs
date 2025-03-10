using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Pixeval.Extensions.Common;
using Pixeval.Extensions.SDK;
using Pixeval.Extensions.Translators.Ollama.Settings;
using Pixeval.Extensions.Translators.Ollama.Strings;
using Pixeval.Extensions.Translators.Ollama.Translators;

namespace Pixeval.Extensions.Translators.Ollama;

[GeneratedComClass]
public partial class ExtensionsHost : ExtensionsHostBase
{
    public override string ExtensionName => Resource.ExtensionHostName;

    public override string AuthorName => "Betta_Fish";

    public override string ExtensionLink => "https://github.com/Pixeval/Pixeval.Extensions.Translators";

    public override string HelpLink => "https://github.com/zxbmmmmmmmmm";

    public override string Description => Resource.ExtensionHostDescription;

    public override string Version => "1.0.0";

    public static ExtensionsHost Current { get; } = new();

    [UnmanagedCallersOnly(EntryPoint = nameof(DllGetExtensionsHost))]
    private static unsafe int DllGetExtensionsHost(void** ppv) => DllGetExtensionsHost(ppv, Current);

    public override IExtension[] Extensions { get; } =
    [
        new OllamaTranslator(),
        new ModelNameSettingsExtension(),
        new SystemInstructionSettingsExtension(),
        new PortSettingsExtension(),
    ];

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
}

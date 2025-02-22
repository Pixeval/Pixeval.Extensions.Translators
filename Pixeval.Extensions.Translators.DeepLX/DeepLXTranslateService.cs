using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using System.Text.Json;
using Pixeval.Extensions.Translators.DeepLX.Translators.Network;

namespace Pixeval.Extensions.Translators.DeepLX;

public class DeepLXTranslateService : IDisposable
{
    private static string ExecutablePath => Path.Combine(ExtensionsHost.ExtensionDirectory,
        @"Pixeval.Extensions.Translators.DeepLX.Assets\deeplx_windows_amd64.exe");

    public string AccessToken
    {
        get;
        set
        {
            field = value;
            KillProcess();
        }
    } = "";

    public string ProSession
    {
        get;
        set
        {
            field = value;
            KillProcess();
        }
    } = "";

    public string Proxy
    {
        get;
        set
        {
            field = value;
            KillProcess();
        }
    } = "";

    public int Port
    {
        get;
        set
        {
            field = value;
            KillProcess();
            if (Used)
                ClearClient();
            else if (string.IsNullOrWhiteSpace(EndPoint))
                _httpClient.BaseAddress = new Uri("http://localhost:" + field);
        }
    } = 1188;

    public string EndPoint
    {
        get;
        set
        {
            field = value;
            if (Used)
                ClearClient();
            else
                _httpClient.BaseAddress = new Uri(!EndPoint.Contains("://")
                    ? "http://" + value
                    : value);
        }
    } = "";

    public int Timeout
    {
        get;
        set
        {
            field = value;
            if (Used)
                ClearClient();
            else
                _httpClient.Timeout = TimeSpan.FromSeconds(Timeout);
        }
    } = 10000;

    [MemberNotNullWhen(false, nameof(_httpClient))]
    private bool Used { get; set; } = true;

    private HttpClient? _httpClient;

    private Process? _process;

    private HttpClient CreateClient() =>
        new()
        {
            Timeout = TimeSpan.FromSeconds(Timeout),
            BaseAddress = new Uri(
                string.IsNullOrWhiteSpace(EndPoint)
                    ? "http://localhost:" + Port
                    : EndPoint.Contains("://")
                        ? EndPoint
                        : "http://" + EndPoint)
        };

    private void ClearClient()
    {
        _httpClient?.Dispose();
        _httpClient = null;
    }

    private Process CreateProcess()
    {
        var arguments = new StringBuilder($"-p {Port}");
        if (!string.IsNullOrWhiteSpace(AccessToken))
            _ = arguments.Append($"-token \"{AccessToken}\"");
        if (!string.IsNullOrWhiteSpace(ProSession))
            _ = arguments.Append($"-s \"{ProSession}\"");
        if (!string.IsNullOrWhiteSpace(Proxy))
            _ = arguments.Append($"-proxy \"{Proxy}\"");
        var process = new Process();
        process.StartInfo = new()
        {
            FileName = ExecutablePath,
            WindowStyle = ProcessWindowStyle.Hidden,
            RedirectStandardError = true,
            RedirectStandardOutput = true,
            Arguments = arguments.ToString()
        };

        _ = process.Start();
        return process;
    }

    private void KillProcess()
    {
        _process?.Dispose();
        _process = null;
    }

    public async Task<string?> TranslateAsync(string text, CancellationToken token = default)
    {
        var target = CultureInfo.CurrentCulture.Name.ToUpper();
        if (!SupportedTargets.Contains(target))
            return
                $"Target language is not supported: {target}. See also: https://developers.deepl.com/docs/resources/supported-languages";

        string jsonResultString;

        try
        {
            if (_process is null && string.IsNullOrWhiteSpace(EndPoint))
                _process = CreateProcess();
            if (_httpClient is null)
            {
                _httpClient = CreateClient();
                Used = false;
            }

            var requestBody = new DeepLXTranslateRequest
            {
                TargetLang = target,
                Text = text
            };

            var jsonRequest =
                JsonSerializer.Serialize(requestBody, typeof(DeepLXTranslateRequest), DeepLXApiContext.Default);
            using var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            using var result = await _httpClient.PostAsync("/translate", content, token).ConfigureAwait(false);
            Used = true;
            jsonResultString = await result.Content.ReadAsStringAsync(token).ConfigureAwait(false);

            result.EnsureSuccessStatusCode();
        }
        catch (OperationCanceledException ex)
            when (!ex.Message.StartsWith("The request was canceled due to the configured HttpClient.Timeout"))
        {
            return ex.Message;
        }
        catch (Exception ex)
        {
            return $"Cannot request to DeepL: {ex.Message}";
        }

        try
        {
            var responseData =
                JsonSerializer.Deserialize(jsonResultString, typeof(DeepLXTranslateResponse), DeepLXApiContext.Default)
                    as DeepLXTranslateResponse;
            return responseData?.Data;
        }
        catch
        {
            return "Cannot parse response as JSON";
        }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        ClearClient();
        KillProcess();
    }

    /// <summary>
    /// DeepL: https://developers.deepl.com/docs/resources/supported-languages
    /// </summary>
    public static HashSet<string> SupportedTargets { get; } =
    [
        "AR",
        // Bulgarian
        "BG",
        // Czech
        "CS",
        // Danish
        "DA",
        // German
        "DE",
        // Greek
        "EL",
        // English (unspecified variant for backward compatibility; please select EN-GB or EN-US instead)
        "EN",
        // English (British)
        "EN-GB",
        // English (American)
        "EN-US",
        // Spanish
        "ES",
        // Estonian
        "ET",
        // Finnish
        "FI",
        // French
        "FR",
        // Hungarian
        "HU",
        // Indonesian
        "ID",
        // Italian
        "IT",
        // Japanese
        "JA",
        // Korean
        "KO",
        // Lithuanian
        "LT",
        // Latvian
        "LV",
        // Norwegian Bokmål
        "NB",
        // Dutch
        "NL",
        // Polish
        "PL",
        // Portuguese (unspecified variant for backward compatibility; please select PT-BR or PT-PT instead)
        "PT",
        // Portuguese (Brazilian)
        "PT-BR",
        // Portuguese (all Portuguese variants excluding Brazilian Portuguese)
        "PT-PT",
        // Romanian
        "RO",
        // Russian
        "RU",
        // Slovak
        "SK",
        // Slovenian
        "SL",
        // Swedish
        "SV",
        // Turkish
        "TR",
        // Ukrainian
        "UK",
        // Chinese (unspecified variant for backward compatibility; please select ZH-HANS or ZH-HANT instead)
        "ZH",
        // Chinese (simplified)
        "ZH-HANS",
        // Chinese (traditional)
        "ZH-HANT"
    ];
}

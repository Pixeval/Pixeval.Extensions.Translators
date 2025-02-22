using System.Text.Json.Serialization;

namespace Pixeval.Extensions.Translators.DeepLX.Translators.Network;

[JsonSerializable(typeof(DeepLXTranslateRequest))]
[JsonSerializable(typeof(DeepLXTranslateResponse))]
[JsonSerializable(typeof(string[]))]
public partial class DeepLXApiContext : JsonSerializerContext;

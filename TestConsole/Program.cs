using Pixeval.Extensions.Translators.Baidu.Client;

var translator = new BaiduTranslatorClient("", "");
var result = await translator.Translate("かーわいいー！", "zh");
Console.WriteLine(result.Trans_Result.First().Dst);

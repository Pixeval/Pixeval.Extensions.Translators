using Pixeval.Extensions.Translators.Baidu.Client;
using Pixeval.Extensions.Translators.Ollama;

var translator = new OllamaTranslateService
{
    ModelName= "deepseek-r1:14b",
    SystemInstruction = "您翻译用户提供的文本到中文。除了翻译文本本身，不要回复任何无关的内容。",
};
var result = await translator.TranslateAsync("かーわいいー！");
Console.WriteLine(result);

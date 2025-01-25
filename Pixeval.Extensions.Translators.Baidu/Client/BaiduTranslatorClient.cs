﻿//https://github.com/sangyuxiaowu/Sang.Baidu.TranslateAPI/blob/main/Sang.Baidu.TranslateAPI/BaiduTranslator.cs

using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text;
using System.Security.Cryptography;

namespace Pixeval.Extensions.Translators.Baidu.Client;
#nullable disable
/// <summary>
/// 文档：https://fanyi-api.baidu.com/doc/21
/// </summary>
public class BaiduTranslatorClient
{
    /// <summary>
    /// APPID
    /// </summary>
    private string _appId;

    /// <summary>
    /// 密钥
    /// </summary>
    private string _secretKey;

    /// <summary>
    ///  翻译服务终结点
    /// </summary>
    private readonly string _endpoint;

    /// <summary>
    /// HttpClient
    /// </summary>
    private readonly HttpClient _httpClient;


    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="appId">APPID</param>
    /// <param name="secretKey">密钥</param>
    /// <param name="endpoint">翻译服务终结点</param>
    public BaiduTranslatorClient(string appId, string secretKey, string endpoint = "https://fanyi-api.baidu.com/api/trans/vip/translate")
    {
        _appId = appId;
        _secretKey = secretKey;
        _endpoint = endpoint;
        _httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(10) }; // 设置超时时间
    }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="appId">APPID</param>
    /// <param name="secretKey">密钥</param>
    /// <param name="httpClient">HttpClient</param>
    /// <param name="endpoint">翻译服务终结点</param>
    public BaiduTranslatorClient(string appId, string secretKey, HttpClient httpClient, string endpoint = "https://fanyi-api.baidu.com/api/trans/vip/translate")
    {
        _appId = appId;
        _secretKey = secretKey;
        _endpoint = endpoint;
        _httpClient = httpClient;
    }

    /// <summary>
    /// 重新设置appId 和 secretKey
    /// </summary>
    /// <param name="appId">APPID</param>
    /// <param name="secretKey">密钥</param>
    public void SetAppIdAndSecretKey(string appId, string secretKey)
    {
        _appId = appId;
        _secretKey = secretKey;
    }

    /// <summary>
    /// 翻译
    /// </summary>
    /// <param name="text">请求翻译文本，长度控制在 6000 bytes以内（汉字约为输入参数 2000 个）</param>
    /// <param name="toLanguage">翻译目标语言</param>
    /// <returns></returns>
    public async Task<BaiduTranslateResult> Translate(string text, string toLanguage)
    {
        return await Translate(text, toLanguage, "auto");
    }

    /// <summary>
    /// 翻译
    /// </summary>
    /// <param name="text">请求翻译文本，长度控制在 6000 bytes以内（汉字约为输入参数 2000 个）</param>
    /// <param name="toLanguage">翻译目标语言</param>
    /// <param name="fromLanguage">翻译源语言，可为auto，自动检测</param>
    /// <param name="salt">设置后将使用传入的随机数</param>
    /// <param name="sign">设置后将使用传入的签名结果</param>
    /// <returns></returns>
    public async Task<BaiduTranslateResult> Translate(string text, string toLanguage, string fromLanguage = "auto", string salt = "", string sign = "")
    {
        // 使用时间戳
        if (string.IsNullOrWhiteSpace(salt))
        {
            salt = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
        }
        // 使用MD5加密
        if (string.IsNullOrWhiteSpace(sign))
        {
            sign = (_appId + text + salt + _secretKey).MD5();
        }
        // 拼接URL
        string url = $"{_endpoint}?q={text}&from={fromLanguage}&to={toLanguage}&appid={_appId}&salt={salt}&sign={sign}";
        // 发送请求
        try
        {
#if NET6_0_OR_GREATER
            //return await _httpClient.GetFromJsonAsync<BaiduTranslateResult>(url);
            var response = await _httpClient.GetAsync(url);
            var options = new JsonSerializerOptions
            {
                TypeInfoResolver = SourceGenerationContext.Default,
            };
            if (response.IsSuccessStatusCode)
            {
                var str = await response.Content.ReadAsStringAsync();
                var result  = JsonSerializer.Deserialize<BaiduTranslateResult>(
                    str, SourceGenerationContext.Default.BaiduTranslateResult);
                return result;
            }
            return new BaiduTranslateResult { Error_Code = response.StatusCode.ToString(), Error_Msg = response.ReasonPhrase };
#else
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var json = JsonDocument.Parse(result);
                    var root = json.RootElement;

                    // 是否存在错误码
                    if (root.TryGetProperty("error_code", out var errorCode))
                    {
                        return new BaiduTranslateResult { Error_Code = errorCode.GetString(), Error_Msg = root.GetProperty("error_msg").GetString() };
                    }

                    var from = root.GetProperty("from").GetString();
                    var to = root.GetProperty("to").GetString();

                    var transResult = new List<TransResult>();
                    for (int i = 0; i < root.GetProperty("trans_result").GetArrayLength(); i++)
                    {
                        var item = root.GetProperty("trans_result")[i];
                        transResult.Add(new TransResult
                        {
                            Src = item.GetProperty("src").GetString(),
                            Dst = item.GetProperty("dst").GetString()
                        });
                    }

                    return new BaiduTranslateResult
                    {
                        From = from,
                        To = to,
                        Trans_Result = transResult
                    };
                }
                return new BaiduTranslateResult { Error_Code = response.StatusCode.ToString(), Error_Msg = response.ReasonPhrase };
#endif
        }
        catch (Exception ex)
        {
            return new BaiduTranslateResult { Error_Code = "Exception", Error_Msg = ex.Message };
        }
    }

    /// <summary>
    /// 释放资源
    /// </summary>
    public void Dispose()
    {
        _httpClient?.Dispose();
    }

}
[JsonSerializable(typeof(BaiduTranslateResult))]
[JsonSerializable(typeof(List<TransResult>))]
[JsonSerializable(typeof(TransResult))]
[JsonSerializable(typeof(bool))]
[JsonSerializable(typeof(string))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
}

public class BaiduTranslateResult
{
    /// <summary>
    /// 是否成功
    /// </summary>
    public bool Success => Error_Code == null;
    /// <summary>
    /// 翻译源语言
    /// </summary>
    [JsonPropertyName("from")]
    public string From { get; set; }
    /// <summary>
    /// 翻译目标语言
    /// </summary>
    [JsonPropertyName("to")]
    public string To { get; set; }
    /// <summary>
    /// 翻译结果
    /// </summary>
    [JsonPropertyName("trans_result")]
    public List<TransResult> Trans_Result { get; set; }
    /// <summary>
    /// 错误码
    /// </summary>
    [JsonPropertyName("error_code")]
    public string Error_Code { get; set; }
    /// <summary>
    /// 错误信息
    /// </summary>

    [JsonPropertyName("error_msg")] 
    public string Error_Msg { get; set; }

    /// <summary>
    /// 获取翻译结果
    /// </summary>
    /// <returns></returns>
    public string GetResult()
    {
        return Trans_Result != null && Trans_Result.Count > 0 ? Trans_Result[0].Dst : null;
    }

}

/// <summary>
/// 翻译结果
/// </summary>
public class TransResult
{
    /// <summary>
    /// 原文
    /// </summary>
    [JsonPropertyName("src")]
    public string Src { get; set; }
    /// <summary>
    /// 译文
    /// </summary>
    [JsonPropertyName("dst")]
    public string Dst { get; set; }
}
public static class Cryptography
{   

    /// <summary>
    /// MD5 计算
    /// </summary>
    /// <param name="str">待计算字符</param>
    /// <param name="isUpper">是否是大写</param>
    /// <param name="isBig">是否是32位，否则为16位</param>
    /// <returns>计算结果</returns>
    public static string MD5(this string str, bool isUpper = false, bool isBig = true)
    {
        using (var md5 = System.Security.Cryptography.MD5.Create())
        {
            var result = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            var strResult = isBig ? BitConverter.ToString(result) : BitConverter.ToString(result, 4, 8);
            return isUpper ? strResult.Replace("-", "") : strResult.Replace("-", "").ToLower();
        }
    }

    /// <summary>
    /// SHA1 计算
    /// </summary>
    /// <param name="str">待计算字符</param>
    /// <param name="isUpper">是否是大写</param>
    /// <returns>计算结果</returns>
    public static string SHA1(this string str, bool isUpper = false)
    {
        using (var sha1 = System.Security.Cryptography.SHA1.Create())
        {
            var result = sha1.ComputeHash(Encoding.UTF8.GetBytes(str));
            var strResult = BitConverter.ToString(result);
            return isUpper ? strResult.Replace("-", "") : strResult.Replace("-", "").ToLower();
        }
    }

}
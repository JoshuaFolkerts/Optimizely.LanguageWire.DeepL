using DeepL;
using DeepL.Model;
using EPiServer.Labs.LanguageManager.Models;

namespace Optimizely.LanguageWire.DeepL;

public interface IDeepLService
{
    Task<TextResult> TranslateAsync(string sourceText, string fromLanguage = LanguageCode.English, string toLanguage = "");

    TranslateTextResult Translate(string inputText, string fromLang, string toLang);
}
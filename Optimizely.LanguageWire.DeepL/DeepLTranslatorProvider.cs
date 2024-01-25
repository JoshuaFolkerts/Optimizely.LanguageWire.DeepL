using EPiServer.Labs.LanguageManager.Business.Providers;
using EPiServer.Labs.LanguageManager.Models;
using EPiServer.ServiceLocation;
using System.Globalization;

namespace Optimizely.LanguageWire.DeepL;

public class DeepLTranslatorProvider : IMachineTranslatorProvider
{
    private readonly IDeepLService _deepLService;

    public DeepLTranslatorProvider()
        : this(ServiceLocator.Current.GetInstance<IDeepLService>())
    {
    }

    public DeepLTranslatorProvider(IDeepLService deepLService)
    {
        _deepLService = deepLService;
    }

    public string DisplayName => "DeepL Translation";

    public bool Initialize(ITranslatorProviderConfig config) => true;

    public TranslateTextResult Translate(string inputText, string fromLang, string toLang)
    {
        var translateTextResult = new TranslateTextResult()
        {
            IsSuccess = true,
            Text = ""
        };

        if (string.IsNullOrWhiteSpace(inputText))
        {
            return translateTextResult;
        }

        try
        {
            var fromLanguageId = DeepLTranslationHelper.ConvertToUsableLanguageCode(new CultureInfo(fromLang).TwoLetterISOLanguageName);
            var toLanguageId = DeepLTranslationHelper.ConvertToUsableLanguageCode(new CultureInfo(toLang).TwoLetterISOLanguageName);

            var result = _deepLService.TranslateAsync(inputText, fromLanguageId, toLanguageId)
                .GetAwaiter()
                .GetResult();

            if (result != null)
            {
                translateTextResult.Text = result.Text;
                translateTextResult.IsSuccess = true;
            }
        }
        catch (Exception e)
        {
            translateTextResult.IsSuccess = false;
            translateTextResult.Text = "An unexpected error occured: " + e.Message;
        }

        return translateTextResult;
    }
}
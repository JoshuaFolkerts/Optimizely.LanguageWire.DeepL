using DeepL;
using DeepL.Model;
using Microsoft.Extensions.Options;

namespace Optimizely.LanguageWire.DeepL;

public class DeepLService : IDeepLService
{
    private readonly ITranslator _translator;

    private readonly DeepLOptions _deepLOptions;

    private readonly TextTranslateOptions _textTranslateOptions;

    public DeepLService(IOptions<DeepLOptions> optiDeepLOptions)
    {
        _deepLOptions = optiDeepLOptions.Value;

        _translator = new Translator(_deepLOptions.AuthorizationKey, new TranslatorOptions()
        {
            MaximumNetworkRetries = 3
        });

        _textTranslateOptions = new TextTranslateOptions
        {
            PreserveFormatting = _deepLOptions.PreserveFormatting,
            Formality = _deepLOptions.Formality,
            GlossaryId = _deepLOptions.GlossaryId,
            TagHandling = _deepLOptions.TagHandling,
            SentenceSplittingMode = _deepLOptions.SentenceSplittingMode,
            OutlineDetection = _deepLOptions.OutlineDetection
        };
    }

    public async Task<TextResult> TranslateAsync(string sourceText, string fromLanguage = LanguageCode.English, string toLanguage = "")
    {
        if (string.IsNullOrWhiteSpace(toLanguage))
        {
            throw new ArgumentNullException(nameof(toLanguage));
        }
        var translationOption = _textTranslateOptions;

        if (!toLanguage.Equals(LanguageCode.English, StringComparison.OrdinalIgnoreCase)
            && !toLanguage.Equals(LanguageCode.German, StringComparison.OrdinalIgnoreCase))
        {
            translationOption.Formality = Formality.Default;
        }

        if (!toLanguage.Equals(LanguageCode.German, StringComparison.OrdinalIgnoreCase))
        {
            translationOption.GlossaryId = null;
        }

        var result = await _translator.TranslateTextAsync(sourceText, fromLanguage, toLanguage, translationOption);

        return result;
    }
}
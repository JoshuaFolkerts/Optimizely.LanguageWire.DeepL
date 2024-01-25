using DeepL;
using DeepL.Model;

namespace Optimizely.LanguageWire.DeepL;

public class DeepLOptions
{
    /// <summary>Initializes a new <see cref="TextTranslateOptions" /> object.</summary>
    public DeepLOptions()
    { }

    /// <summary>Initializes a new <see cref="TextTranslateOptions" /> object including the given glossary.</summary>
    /// <param name="glossary">Glossary to use in translation.</param>
    public DeepLOptions(GlossaryInfo glossary)
        : this()
    {
        GlossaryId = glossary.GlossaryId;
    }

    /// <summary>
    /// Authorization key for making api calls.  It is required
    /// </summary>
    public string AuthorizationKey { get; set; }

    /// <summary>Controls whether translations should lean toward formal or informal language.</summary>
    /// This option is only applicable for target languages that support the formality option.
    /// <seealso cref="TargetLanguage.SupportsFormality" />
    public Formality Formality { get; set; } = Formality.Default;

    /// <summary>Specifies the ID of a glossary to use with the translation.</summary>
    public string? GlossaryId { get; set; }

    /// <summary>Specifies a list of XML tags containing content that should not be translated.</summary>
    public List<string> IgnoreTags { get; } = new List<string>();

    /// <summary>Specifies a list of XML tags that should not be used to split text into sentences.</summary>
    public List<string> NonSplittingTags { get; } = new List<string>();

    /// <summary>Set to <c>false</c> to disable automatic tag detection, default is <c>true</c>.</summary>
    public bool OutlineDetection { get; set; } = true;

    /// <summary>
    ///   Set to <c>true</c> to prevent the translation engine from correcting some formatting aspects, and instead leave the
    ///   formatting unchanged, default is <c>false</c>.
    /// </summary>
    public bool PreserveFormatting { get; set; } = true;

    /// <summary>Specifies how input translation text should be split into sentences.</summary>
    /// <seealso cref="SentenceSplittingMode" />
    public SentenceSplittingMode SentenceSplittingMode { get; set; } = SentenceSplittingMode.All;

    /// <summary>Specifies a list of XML tags that should be used to split text into sentences.</summary>
    public List<string> SplittingTags { get; } = new List<string>();

    /// <summary>Type of tags to parse before translation, only "xml" and "html" are currently available.</summary>
    public string? TagHandling { get; set; } = "html";
}
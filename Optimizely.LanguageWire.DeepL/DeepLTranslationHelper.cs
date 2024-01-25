using DeepL;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.ServiceLocation;
using EPiServer.SpecializedProperties;
using EPiServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimizely.LanguageWire.DeepL;

public class DeepLTranslationHelper
{
    public static string ConvertToUsableLanguageCode(string languageCode)
    {
        if (languageCode.Equals("no", StringComparison.OrdinalIgnoreCase))
        {
            languageCode = LanguageCode.Norwegian;
        }
        return languageCode;
    }
}
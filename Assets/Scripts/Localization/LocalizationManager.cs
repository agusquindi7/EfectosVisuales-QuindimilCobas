using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager instance;

    public LocalizationLang language;
    public LocalizationData[] data;

    Dictionary<LocalizationLang, Dictionary<string, string>> _translate;

    public void Awake()
    {
        instance = this;
        _translate = LanguageU.GetTranslate(data);
    }
    #region Set Language for Buttons
    public void SetLocalizationLanguage(LocalizationLang lang)
    {
        language = lang;
    }

    public void SetLanguageToSpanish()
    {
        SetLocalizationLanguage(LocalizationLang.Spanish);
    }

    public void SetLanguageToEnglish()
    {
        SetLocalizationLanguage(LocalizationLang.English);
    }

    public void SetLanguageToSwedish()
    {
        SetLocalizationLanguage(LocalizationLang.Swedish);
    }

    #endregion 

    public string Translate(string id)
    {
        if (!_translate.ContainsKey(language))
            return "No Lang";
        if (!_translate[language].ContainsKey(id))
            return "No ID";
        return _translate[language][id];
    }
}
public enum LocalizationLang
{
    Spanish,
    English,
    Swedish
}
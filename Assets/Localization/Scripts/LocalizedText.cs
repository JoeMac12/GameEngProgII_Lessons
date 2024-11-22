using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class LocalizedText : MonoBehaviour
{
    [SerializeField] private string tableReference;
    [SerializeField] private string localizationKey;

    private LocalizedString localizedStr;
    private Text textComponent;

    void Start()
    {
        textComponent = GetComponent<Text>();
        localizedStr = new LocalizedString { TableReference = tableReference, TableEntryReference = localizationKey };
        LocalizationSettings.SelectedLocaleChanged += UpdateText;

        var frenchLocale = LocalizationSettings.AvailableLocales.GetLocale("fr"); // Start in en or fr
        LocalizationSettings.SelectedLocale = frenchLocale;
        UpdateText(frenchLocale);
    }

    private void OnDestroy()
    {
        LocalizationSettings.SelectedLocaleChanged -= UpdateText;
    }

    void UpdateText(Locale locale)
    {
        textComponent.text = localizedStr.GetLocalizedString(); // Translation logic
    }
}

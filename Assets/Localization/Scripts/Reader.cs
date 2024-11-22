using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Language
{
    public string lang;
    public string title;
    public string play;
    public string quit;
    public string options;
    public string credits;
    public string gameplayMessage;
    public string gameStatTitle;
    public string gameStatCount;
    public string currentLevelTitle;
    public string currentLevelID;
}

public class LanguageData
{
    public Language[] languages;
}

public class Reader : MonoBehaviour
{
    public TextAsset jsonFile;
    public string currentLanguage = "en";
    private LanguageData languageData;

    public Text titleText;
    public Text playText;
    public Text optionsText;
    public Text quitText;
    public Text creditsText;

    public Text gameplayMessageText;
    public Text gameStatTitleText;
    public Text gameStatCountText;
    public Text currentLevelTitleText;
    public Text currentLevelIDText;

    private void Start()
    {
        languageData = JsonUtility.FromJson<LanguageData>(jsonFile.text);
        SetLanguage(currentLanguage);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            ToggleLanguage();
        }
    }

    private void ToggleLanguage()
    {
        // Toggle between English and French
        currentLanguage = currentLanguage.ToLower() == "en" ? "fr" : "en";
        SetLanguage(currentLanguage);
    }

    public void SetLanguage(string newLanguage)
    {
        foreach (Language lang in languageData.languages)
        {
            if (lang.lang.ToLower() == newLanguage.ToLower())
            {
                titleText.text = lang.title;
                playText.text = lang.play;
                optionsText.text = lang.options;
                quitText.text = lang.quit;
                creditsText.text = lang.credits;

                gameplayMessageText.text = lang.gameplayMessage;
                gameStatTitleText.text = lang.gameStatTitle;
                gameStatCountText.text = lang.gameStatCount;
                currentLevelTitleText.text = lang.currentLevelTitle;
                currentLevelIDText.text = lang.currentLevelID;
                return;
            }
        }
    }
}

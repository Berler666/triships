using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SettingsManager : MonoBehaviour
{

    public Toggle fullscreenToggle;
    public Dropdown ResolutionDropdown;
    public Dropdown textureQualityDropdown;
    public Dropdown antiialiasingDropdown;
    public Dropdown VsyncDropdown;
    public Button applyButton;

    public Resolution[] resolitions;
    public GameSettings gameSettings;

    void OnEnable()
    {
        gameSettings = new GameSettings();

        fullscreenToggle.onValueChanged.AddListener(delegate { OnFullscreenToggle(); });
        ResolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        textureQualityDropdown.onValueChanged.AddListener(delegate { OnTextureQualityChnage(); });
        antiialiasingDropdown.onValueChanged.AddListener(delegate { OnAntialiasingChnage(); });
        VsyncDropdown.onValueChanged.AddListener(delegate { OnVsyncChange(); });
        applyButton.onClick.AddListener(delegate { ApplySettingsButton(); });

        resolitions = Screen.resolutions;
        foreach(Resolution resolution in resolitions)
        {
            ResolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }

        LoadSettings();
    }

    public void OnFullscreenToggle()
    {
        
       gameSettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
    }

    public void OnResolutionChange()
    {
        Screen.SetResolution(resolitions[ResolutionDropdown.value].width, resolitions[ResolutionDropdown.value].height, Screen.fullScreen);
        gameSettings.resolutionIndex = ResolutionDropdown.value;
    }

    public void OnTextureQualityChnage()
    {
        QualitySettings.masterTextureLimit = gameSettings.textureQuality = textureQualityDropdown.value;
        
    }


    public void OnAntialiasingChnage()
    {
        QualitySettings.antiAliasing = gameSettings.antialiasing = (int)Mathf.Pow(2f, antiialiasingDropdown.value);
    }

    public void OnVsyncChange()
    {
        QualitySettings.vSyncCount = gameSettings.vsync = VsyncDropdown.value;
    }

    public void SaveSettings()
    {
        string jsonData = JsonUtility.ToJson(gameSettings, true);
        File.WriteAllText(Application.persistentDataPath + "/gamesettings.json", jsonData);
    }

    public void LoadSettings()
    {
        gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));

        antiialiasingDropdown.value = gameSettings.antialiasing;
        VsyncDropdown.value = gameSettings.vsync;
        textureQualityDropdown.value = gameSettings.textureQuality;
        ResolutionDropdown.value = gameSettings.resolutionIndex;
        fullscreenToggle.isOn = gameSettings.fullscreen;

        ResolutionDropdown.RefreshShownValue();
        Screen.fullScreen = gameSettings.fullscreen;
    }

    public void ApplySettingsButton()
    {
        SaveSettings();
    }

}

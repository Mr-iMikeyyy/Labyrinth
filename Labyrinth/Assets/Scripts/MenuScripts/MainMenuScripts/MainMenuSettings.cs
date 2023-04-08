using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class MainMenuSettings : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource buttonHover;
    public AudioSource buttonClicks;
    public Slider musicSlider;
    public Slider sfxSlider;
    public TextMeshProUGUI musicText;
    public TextMeshProUGUI sfxText;
    public GameObject settingsMenu;

    private float prevMusicVolume;
    private float prevSFXVolume;
    private float tempMusicVolume;
    private float tempSFXVolume;
    private const string musicPrefKey = "musicVolume";
    private const string sfxPrefKey = "sfxVolume";

    void Start()
    {
        // Load saved volume settings from PlayerPrefs
        if (PlayerPrefs.HasKey(musicPrefKey))
        {
            musicSlider.value = PlayerPrefs.GetFloat(musicPrefKey);
        }
        else
        {
            musicSlider.value = 0.25f;
        }
        
        if (PlayerPrefs.HasKey(sfxPrefKey))
        {
            sfxSlider.value = PlayerPrefs.GetFloat(sfxPrefKey);
        }
        else
        {
            sfxSlider.value = 0.25f;
        }

        // Save initial volume values
        prevMusicVolume = musicSlider.value;
        prevSFXVolume = sfxSlider.value;

        // Update temporary volume values
        tempMusicVolume = musicSlider.value;
        tempSFXVolume = sfxSlider.value;

        // Set the volume of the audio sources to the default values
        backgroundMusic.volume = musicSlider.value;
        buttonHover.volume = sfxSlider.value;
        buttonClicks.volume = sfxSlider.value;

        // Update text values
        UpdateTextValues();
    }



    public void SetMusicVolume(float volume)
    {
        backgroundMusic.volume = volume;
        UpdateTextValues();
        tempMusicVolume = volume;
        PlayerPrefs.SetFloat(musicPrefKey, volume);
    }

    public void SetSFXVolume(float volume)
    {
        buttonHover.volume = volume;
        buttonClicks.volume = volume;
        UpdateTextValues();
        tempSFXVolume = volume;
        PlayerPrefs.SetFloat(sfxPrefKey, volume);
    }


    // Open settings menu
    public void OpenSettingsMenu()
    {
        // Save current volume values
        tempMusicVolume = musicSlider.value;
        tempSFXVolume = sfxSlider.value;

        settingsMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(GameObject.Find("ApplyButton"));
    }

    // Close settings menu
    public void CloseSettingsMenu()
    {
        if (settingsMenu.activeSelf)
        {
            // Save current slider values as previous values
            prevMusicVolume = tempMusicVolume = musicSlider.value;
            prevSFXVolume = tempSFXVolume = sfxSlider.value;

            // Reset sliders to previous values
            musicSlider.value = prevMusicVolume;
            sfxSlider.value = prevSFXVolume;

            // Update text values
            UpdateTextValues();

            settingsMenu.SetActive(false);

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(GameObject.Find("SettingsButton"));
        }
    }

    public void ResetSettings()
    {
        musicSlider.value = 0.25f;
        sfxSlider.value = 0.25f;
        UpdateTextValues();

        // Save default volume values
        prevMusicVolume = musicSlider.value;
        prevSFXVolume = sfxSlider.value;

        // Set temporary volume values to default volume values
        tempMusicVolume = musicSlider.value;
        tempSFXVolume = sfxSlider.value;

        // Apply volume changes to audio sources
        backgroundMusic.volume = prevMusicVolume;
        buttonHover.volume = prevSFXVolume;
        buttonClicks.volume = prevSFXVolume;

        CloseSettingsMenu();

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(GameObject.Find("SettingsButton"));
    }


    // Apply settings changes
    public void ApplySettings()
    {
        // Set previous volume values to temporary volume values
        prevMusicVolume = tempMusicVolume;
        prevSFXVolume = tempSFXVolume;

        // Update previous volume values
        prevMusicVolume = musicSlider.value;
        prevSFXVolume = sfxSlider.value;

        // Apply volume changes to audio sources
        backgroundMusic.volume = prevMusicVolume;
        buttonHover.volume = prevSFXVolume;
        buttonClicks.volume = prevSFXVolume;

        CloseSettingsMenu();
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(GameObject.Find("SettingsButton"));
    }

    // Update text values based on slider values
    private void UpdateTextValues()
    {
        musicText.text = Mathf.Round(musicSlider.value * 100) + "%";
        sfxText.text = Mathf.Round(sfxSlider.value * 100) + "%";
    }
}
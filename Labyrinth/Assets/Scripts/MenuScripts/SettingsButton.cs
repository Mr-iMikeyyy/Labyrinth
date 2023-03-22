using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsButton : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Slider sfxSlider;
    public TextMeshProUGUI musicText;
    public TextMeshProUGUI sfxText;
    public GameObject settingsMenu;

    private float prevMusicVolume;
    private float prevSFXVolume;
    private float tempMusicVolume;
    private float tempSFXVolume;
    private float ConvertToDecibels(float volume)
    {
     if (volume == 0)
        {
        return -80f;
        }
        else
        {
        return Mathf.Log10(volume) * 20f;
        }
    }

    void Start()
    {
        // Set default slider values
        musicSlider.value = 0.5f;
        sfxSlider.value = 0.5f;

        // Save initial volume values
        prevMusicVolume = musicSlider.value;
        prevSFXVolume = sfxSlider.value;

        // Update text values
        UpdateTextValues();
    }

    // Set music volume
    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", ConvertToDecibels(volume));
        UpdateTextValues();
        tempMusicVolume = volume; // update tempMusicVolume
    }

    // Set SFX volume
    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", ConvertToDecibels(volume));
        UpdateTextValues();
        tempSFXVolume = volume; // update tempSFXVolume
    }

    // Open settings menu
    public void OpenSettingsMenu()
    {
        // Save current volume values
        tempMusicVolume = musicSlider.value;
        tempSFXVolume = sfxSlider.value;

        settingsMenu.SetActive(true);
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
        }
    }


    // Reset settings to default
    public void ResetSettings()
    {
        audioMixer.SetFloat("MusicVolume", ConvertToDecibels(0.5f));
        audioMixer.SetFloat("SFXVolume", ConvertToDecibels(0.5f));
        musicSlider.value = 0.5f;
        sfxSlider.value = 0.5f;
        UpdateTextValues();

        // Save default volume values
        prevMusicVolume = musicSlider.value;
        prevSFXVolume = sfxSlider.value;

        // Set temporary volume values to default volume values
        tempMusicVolume = musicSlider.value;
        tempSFXVolume = sfxSlider.value;
    }

    // Apply settings changes
    public void ApplySettings()
    {
        // Set previous volume values to temporary volume values
        prevMusicVolume = tempMusicVolume;
        prevSFXVolume = tempSFXVolume;

        // Apply volume changes to AudioMixer
        audioMixer.SetFloat("MusicVolume", ConvertToDecibels(prevMusicVolume));
        audioMixer.SetFloat("SFXVolume", ConvertToDecibels(prevSFXVolume));

        // Update previous volume values
        prevMusicVolume = musicSlider.value;
        prevSFXVolume = sfxSlider.value;

        CloseSettingsMenu();
    }



    // Update text values based on slider values
    private void UpdateTextValues()
    {
        musicText.text = Mathf.Round(musicSlider.value * 100) + "%";
        sfxText.text = Mathf.Round(sfxSlider.value * 100) + "%";
    }

    //
}
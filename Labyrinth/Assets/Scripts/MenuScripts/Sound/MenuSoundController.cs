using UnityEngine;
using System;

public class MenuSoundController : MonoBehaviour
{
    private MenuAudio menuAudioSettings;
    
    void Start()
    {
        try {
            menuAudioSettings = GetComponent<MenuAudio>();
            menuAudioSettings.ambientMusic.volume = PlayerPrefs.GetFloat("musicVolume", 0.25f);
            menuAudioSettings.buttonClick.volume = PlayerPrefs.GetFloat("sfxVolume", 0.25f);
            menuAudioSettings.buttonHover.volume = PlayerPrefs.GetFloat("sfxVolume", 0.25f);
        } catch (Exception e) {
            Debug.Log(e);
        }
    }

}

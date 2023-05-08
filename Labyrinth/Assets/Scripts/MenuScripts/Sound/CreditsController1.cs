using UnityEngine;
using System;


public class CreditsController1 : MonoBehaviour
{
    private CreditsAudio1 audioSettings;
    
    void Start()
    {
        try {
            audioSettings = GetComponent<CreditsAudio1>();
            audioSettings.music.volume = PlayerPrefs.GetFloat("musicVolume", 0.01f);
        } catch (Exception e) {
            Debug.Log(e);
        }
    }
}

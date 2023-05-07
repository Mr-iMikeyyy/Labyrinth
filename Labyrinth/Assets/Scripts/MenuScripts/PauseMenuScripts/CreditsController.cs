using UnityEngine;
using System;


public class CreditsController : MonoBehaviour
{
    private CreditsAudio audioSettings;
    
    void Start()
    {
        try {
            audioSettings = GetComponent<CreditsAudio>();
            audioSettings.music.volume = PlayerPrefs.GetFloat("musicVolume", 0.25f);
        } catch (Exception e) {
            Debug.Log(e);
        }
    }
}

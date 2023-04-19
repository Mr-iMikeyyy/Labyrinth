using UnityEngine;

public class SoundController_2 : MonoBehaviour
{
    public AudioSettings audioSettings;
    
    void Start()
    {
        audioSettings.ambientMusic.volume = PlayerPrefs.GetFloat("musicVolume", 0.25f);
        audioSettings.buttonClick.volume = PlayerPrefs.GetFloat("sfxVolume", 0.25f);
        audioSettings.buttonHover.volume = PlayerPrefs.GetFloat("sfxVolume", 0.25f);
        audioSettings.footsteps.volume = PlayerPrefs.GetFloat("sfxVolume", 0.25f);
        audioSettings.sprintFootsteps.volume = PlayerPrefs.GetFloat("sfxVolume", 0.25f); 
        audioSettings.breathing.volume = PlayerPrefs.GetFloat("sfxVolume", 0.25f);
        audioSettings.noStaminaBreathing.volume = PlayerPrefs.GetFloat("sfxVolume", 0.25f);
    }

}

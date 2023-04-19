using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    public AudioSource ambientMusic;
    public AudioSource buttonClick;
    public AudioSource buttonHover;
    public AudioSource footsteps;
    public AudioSource sprintFootsteps;
    public AudioSource breathing;
    public AudioSource noStaminaBreathing;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}

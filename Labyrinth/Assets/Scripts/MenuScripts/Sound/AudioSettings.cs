using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    public AudioSource ambientMusic;
    public AudioSource buttonClick;
    public AudioSource buttonHover;
    public AudioSource footsteps;
    public AudioSource sprintFootsteps;
    public AudioSource runBreathing;
    public AudioSource exhaustedBreathing;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}

using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource ambientMusic;
    public AudioSource buttonClick;
    public AudioSource buttonHover;
    public AudioSource footsteps;
    public AudioSource sprintFootsteps;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}

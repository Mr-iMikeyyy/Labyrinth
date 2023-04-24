using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    public AudioSource ambientMusic;
    public AudioSource buttonClick;
    public AudioSource buttonHover;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}

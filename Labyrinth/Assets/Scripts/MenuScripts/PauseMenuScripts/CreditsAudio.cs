using UnityEngine;

public class CreditsAudio : MonoBehaviour
{
    public AudioSource music;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}

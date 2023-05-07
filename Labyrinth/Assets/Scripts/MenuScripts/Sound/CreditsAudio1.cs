using UnityEngine;

public class CreditsAudio1 : MonoBehaviour
{
    public AudioSource music;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}

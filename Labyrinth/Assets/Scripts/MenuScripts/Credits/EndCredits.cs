using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCredits : MonoBehaviour
{
    private float timer = 0f;
    private const float sceneChangeDelay = 20f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= sceneChangeDelay)
        {
            SceneManager.LoadScene("MainMenu2");
        }
    }
}

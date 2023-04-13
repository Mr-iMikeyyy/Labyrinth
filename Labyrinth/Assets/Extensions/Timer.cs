using UnityEngine;

public class Timer : MonoBehaviour
{
    float time = 0.0f;
    bool isTiming = false;

    // Cleans up the timer when the scene is loaded and starts the timer.
    private void Start()
    {
        time = 0.0f;
        isTiming = true;
    }

    void Update()
    {
        if (isTiming)
            time += Time.deltaTime;
        // Debug.Log(time);
        // Debug.Log(isTiming);
    }

    public void StartTiming()
    {
        isTiming = true;
    }

    public void PauseTiming()
    {
        isTiming = false;
    }
    
    public void ResetTimer()
    {
        time = 0.0f;
    }

}
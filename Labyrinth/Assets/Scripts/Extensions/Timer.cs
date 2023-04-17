using UnityEngine;
using System.Collections.Generic;


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

    public float GetTime()
    {
        return time;
    }

    public void SaveLevelTime(string name, int level)
    {
        string scores = PlayerPrefs.GetString("HighScores");
        
        List<HighScore> highScores = new List<HighScore>();
        highScores = JsonUtility.FromJson<List<HighScore>>(scores);
        
        // Add new score
        highScores.Add(new HighScore(name, level, time));
        
        // bubble sort the high scores
        for (int i = 0; i < highScores.Count; i++)
        {
            for (int j = 0; j < highScores.Count - 1; j++)
            {
                if (highScores[j].time > highScores[j + 1].time)
                {
                    HighScore temp = highScores[j];
                    highScores[j] = highScores[j + 1];
                    highScores[j + 1] = temp;
                }
            }
        }

        // save the high scores
        scores = JsonUtility.ToJson(highScores);
        PlayerPrefs.SetString("HighScores", scores);
    }
}
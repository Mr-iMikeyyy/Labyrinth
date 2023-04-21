using UnityEngine;
using System.Collections.Generic;

public class Timer : MonoBehaviour
{
    float time = 0.0f;
    bool isTiming = false;
    private const int MAX_HIGH_SCORES = 3;

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
        HighScoreCollection highScoreCollection = new HighScoreCollection();

        string scores = PlayerPrefs.GetString("HighScores");
        if (!string.IsNullOrEmpty(scores))
        {
            highScoreCollection = JsonUtility.FromJson<HighScoreCollection>(scores);
        }

        // Add new score
        highScoreCollection.highScores.Add(new HighScore(name, level, time));

        // bubble sort the high scores
        for (int i = 0; i < highScoreCollection.highScores.Count; i++)
        {
            for (int j = 0; j < highScoreCollection.highScores.Count - 1; j++)
            {
                if (highScoreCollection.highScores[j].time > highScoreCollection.highScores[j + 1].time)
                {
                    HighScore temp = highScoreCollection.highScores[j];
                    highScoreCollection.highScores[j] = highScoreCollection.highScores[j + 1];
                    highScoreCollection.highScores[j + 1] = temp;
                }
            }
        }

        // remove scores exceeding max count
        if (highScoreCollection.highScores.Count > MAX_HIGH_SCORES)
        {
            highScoreCollection.highScores.RemoveRange(MAX_HIGH_SCORES, highScoreCollection.highScores.Count - MAX_HIGH_SCORES);
        }

        // Save the high scores
        string updatedScores = JsonUtility.ToJson(highScoreCollection);
        PlayerPrefs.SetString("HighScores", updatedScores);
        Debug.Log("These are the current scores: " + updatedScores);
    }
}

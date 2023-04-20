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
        List<HighScore> highScores = new List<HighScore>();

        string scores = PlayerPrefs.GetString("HighScores");
        if (!string.IsNullOrEmpty(scores))
        {
            highScores = JsonUtility.FromJson<List<HighScore>>(scores);
        }

        // Add new score
        highScores.Add(new HighScore(name, level, time));

        // debug the highScores list
        foreach(HighScore hs in highScores)
        {
            Debug.Log("Name: " + hs.name + ", Level: " + hs.level + ", Time: " + hs.time);
        }

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

        // debugging
        for (int i = 0; i < highScores.Count; i++)
        {
            Debug.Log("Name: " + highScores[i].name + ", Level: " + highScores[i].level + ", Time: " + highScores[i].time);
        }
        if (highScores.Count > MAX_HIGH_SCORES)
        {
            highScores.RemoveAt(MAX_HIGH_SCORES);
        }

        // Save the high scores
        string updatedScores = JsonUtility.ToJson(highScores);
        PlayerPrefs.SetString("HighScores", updatedScores);
        Debug.Log("These are the current scores: " + updatedScores);
    }

}
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

    public void SaveLevelTime(string name, float totalTime)
    {
        HighScoreCollection highScoreCollection = new HighScoreCollection();

        string scores = PlayerPrefs.GetString("HighScores");
        if (!string.IsNullOrEmpty(scores))
        {
            highScoreCollection = JsonUtility.FromJson<HighScoreCollection>(scores);
        }

        // Only add the score if the player has completed the maximum level
        if (PlayerStats.getCurrentLevel() == PlayerStats.getMaxLevel())
        {
            // Create a new high score and add it to the collection
            HighScore newHighScore = new HighScore(name, totalTime);
            highScoreCollection.highScores.Add(newHighScore);

            // Sort the high scores in ascending order based on total time
            highScoreCollection.highScores.Sort((a, b) => a.totalTime.CompareTo(b.totalTime));

            // Remove any excess scores beyond the maximum allowed
            if (highScoreCollection.highScores.Count > MAX_HIGH_SCORES)
            {
                highScoreCollection.highScores.RemoveRange(MAX_HIGH_SCORES, highScoreCollection.highScores.Count - MAX_HIGH_SCORES);
            }

            // Save the updated high score collection to PlayerPrefs
            string updatedScores = JsonUtility.ToJson(highScoreCollection);
            PlayerPrefs.SetString("HighScores", updatedScores);
            Debug.Log("These are the current scores: " + updatedScores);
        }
    }
}
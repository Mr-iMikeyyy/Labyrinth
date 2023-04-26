using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SeeHighScores : MonoBehaviour
{
    public TextMeshProUGUI[] highScoreTexts;
    public GameObject highScoreListPanel;
    //bool scoresCleared = false;
    private List<HighScore> highScores = new List<HighScore>();

    private void Start()
    {
        LoadHighScores();
        //UN-COMMENT ME TO DELETE HIGH SCORES

        /*if (!scoresCleared)
        {
            PlayerPrefs.DeleteKey("HighScores");
            scoresCleared = true;
        }*/
    }

    public void LoadHighScores()
    {
        string scores = PlayerPrefs.GetString("HighScores");
        Debug.Log("Loaded high scores: " + scores);
        if (!string.IsNullOrEmpty(scores))
        {
            HighScoreCollection highScoreCollection = JsonUtility.FromJson<HighScoreCollection>(scores);
            highScores = highScoreCollection.highScores;
        }
    }

    private void UpdateHighScoreTexts()
    {
        for (int i = 0; i < highScoreTexts.Length; i++)
        {
            if (i < highScores.Count)
            {
                string formattedScore = GetFormattedScore(highScores[i]);
                highScoreTexts[i].text = formattedScore;
                Debug.Log("Formatted Score: " + formattedScore);
            }
            else
            {
                highScoreTexts[i].text = "-";
            }
        }
        Debug.Log("Updated high score texts");
    }


    private string GetFormattedScore(HighScore highScore)
    {
        string timeString = string.Format("{0:00}:{1:00}", Mathf.FloorToInt(highScore.totalTime / 60f), Mathf.FloorToInt(highScore.totalTime % 60f));
        return string.Format("{0,-15}{1}{2}", highScore.name, "Total Time: ", timeString);
    }

    public void OpenHighScoreList()
    {
        highScoreListPanel.SetActive(true);

        UpdateHighScoreTexts();

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(GameObject.Find("HighScoreBack"));
    }

    public void CloseHighScoreList()
    {
        highScoreListPanel.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(GameObject.Find("SeeHighScoresButton"));
    }
}

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

    private List<HighScore> highScores = new List<HighScore>();
    //UN-COMMENT ME TO DELETE HIGH SCORES bool scoresCleared = false;

    private void Start()
    {
        LoadHighScores();
        //UN-COMMENT ME TO DELETE HIGH SCORES
    /*  if (!scoresCleared)
        {
            PlayerPrefs.DeleteKey("HighScores");
            scoresCleared = true;
        } */
    }

    public void LoadHighScores()
    {
        string scores = PlayerPrefs.GetString("HighScores");
        if (!string.IsNullOrEmpty(scores))
        {
            HighScoreCollection highScoreCollection = JsonUtility.FromJson<HighScoreCollection>(scores);
            highScores = highScoreCollection.highScores;
        }
        Debug.Log("Loaded high scores: " + scores);
    }

    private void UpdateHighScoreTexts()
    {
        for (int i = 0; i < highScoreTexts.Length; i++)
        {
            if (i < highScores.Count)
            {
                highScoreTexts[i].text = GetFormattedScore(highScores[i]);
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
        string timeString = string.Format("{0:00}:{1:00}", Mathf.FloorToInt(highScore.time / 60f), Mathf.FloorToInt(highScore.time % 60f));
        return string.Format("{0} - Level {1} - {2}", highScore.name, highScore.level, timeString);
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

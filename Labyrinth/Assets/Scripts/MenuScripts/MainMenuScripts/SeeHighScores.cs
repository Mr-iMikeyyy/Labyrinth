using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SeeHighScores : MonoBehaviour
{
    public GameObject highScoreListPanel;
    public TextMeshProUGUI[] highScoreTexts = new TextMeshProUGUI[3];

    private List<HighScore> highScores = new List<HighScore>();
    private const int MAX_HIGH_SCORES = 3;

    private void LoadHighScores()
    {
        string scores = PlayerPrefs.GetString("HighScores");

        if (string.IsNullOrEmpty(scores))
        {
            highScores = new List<HighScore>();
        }
        else
        {
            highScores = JsonUtility.FromJson<List<HighScore>>(scores);
        }
        Debug.Log("Loaded high scores: " + scores);
        UpdateHighScoreTexts();
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

        LoadHighScores();
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
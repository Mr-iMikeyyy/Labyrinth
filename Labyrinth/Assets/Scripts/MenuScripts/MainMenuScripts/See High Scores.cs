using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreList : MonoBehaviour
{
    public GameObject highScoreListPanel;
    public Button highScoreButton;

    public Text[] highScoreTexts = new Text[5];

    private List<int> highScores = new List<int>();
    private const int MAX_HIGH_SCORES = 5;

    private void Start()
    {
        highScoreButton.onClick.AddListener(OpenHighScoreList);
        highScoreListPanel.SetActive(false);

        for (int i = 0; i < MAX_HIGH_SCORES; i++)
        {
            highScores.Add(0);
        }

        // Load saved high scores from player prefs
        for (int i = 0; i < MAX_HIGH_SCORES; i++)
        {
            if (PlayerPrefs.HasKey("highScore" + i))
            {
                highScores[i] = PlayerPrefs.GetInt("highScore" + i);
            }
        }

        UpdateHighScoreTexts();
    }

    private void UpdateHighScoreTexts()
    {
        for (int i = 0; i < MAX_HIGH_SCORES; i++)
        {
            highScoreTexts[i].text = highScores[i].ToString();
        }
    }

    public void AddHighScore(int score)
    {
        for (int i = 0; i < MAX_HIGH_SCORES; i++)
        {
            if (score > highScores[i])
            {
                highScores.Insert(i, score);
                highScores.RemoveAt(MAX_HIGH_SCORES);
                UpdateHighScoreTexts();
                SaveHighScores();
                break;
            }
        }
    }

    private void SaveHighScores()
    {
        for (int i = 0; i < MAX_HIGH_SCORES; i++)
        {
            PlayerPrefs.SetInt("highScore" + i, highScores[i]);
        }
    }

    public void OpenHighScoreList()
    {
        highScoreListPanel.SetActive(true);
    }

    public void CloseHighScoreList()
    {
        highScoreListPanel.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using PlayerInformation;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

namespace PlayerInformation
{
    public class LevelCompleted : MonoBehaviour
    {
        [SerializeField] private GameObject levelCompleteMenu;
        private GameObject playerCamera;
        public TMP_Text CompletedTime;

        private bool isCompleted = false;

        void Start()
        {
            playerCamera = GameObject.Find("Main Camera");
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Something has entered the trigger volume.");
            if (other.CompareTag("Player") && !isCompleted)
            {
                isCompleted = true;
                Debug.Log("Player has entered the trigger volume.");
                ShowLevelCompleteMenu();
            }
        }
        private void ShowLevelCompleteMenu()
        {
            // Upon level completion the player's time is saved and the level complete menu is shown.
            PlayerStats.getTimer().PauseTiming();
            float completedLevelTime = PlayerStats.getTimer().GetTime();
            float totalRunTime = completedLevelTime;
            int currentLevel = PlayerStats.getCurrentLevel();
            string playerName = PlayerStats.Name;

            // If player reached the maximum level, save total run time
            if (currentLevel == PlayerStats.getMaxLevel())
            {
                float level1Time = PlayerPrefs.GetFloat("Level1Time");
                totalRunTime += level1Time;
                PlayerPrefs.SetFloat("Level1Time", 0f);
                PlayerPrefs.SetFloat("Level2Time", 0f);
                PlayerPrefs.SetFloat("TotalRunTime", totalRunTime);
                Debug.Log("Total Run Time: " + totalRunTime);
                SceneManager.LoadScene("Credits");
            }
            else
            {
                // Save the completed level time to playerprefs
                PlayerPrefs.SetFloat("Level" + currentLevel + "Time", completedLevelTime);
                Debug.Log("Level " + currentLevel + " Time: " + completedLevelTime);

                // Save the completed level time to high scores
                FindObjectOfType<Timer>().SaveLevelTime(playerName, completedLevelTime);
            }

            // Display the completed level time in level completed menu
            levelCompleteMenu.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(GameObject.Find("NextLevelButton"));
            CompletedTime.text = string.Format(
                "{0:00}:{1:00}",
                Mathf.FloorToInt(completedLevelTime / 60f),
                Mathf.FloorToInt(completedLevelTime % 60f)
            );
            Debug.Log(string.Format("Timer Format: {0:00}:{1:00}", Mathf.FloorToInt(completedLevelTime / 60f), Mathf.FloorToInt(completedLevelTime % 60f)));
        }

    }
}

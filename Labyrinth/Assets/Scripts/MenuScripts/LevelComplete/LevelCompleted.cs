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
            PlayerStats.getTimer().SaveLevelTime(PlayerStats.Name, PlayerStats.getCurrentLevel());

            if (PlayerStats.getCurrentLevel() >= PlayerStats.getMaxLevel()) {
                SceneManager.LoadScene("Credits");
            } else{
                levelCompleteMenu.SetActive(true);
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(GameObject.Find("NextLevelButton"));
                CompletedTime.text = string.Format(
                    "{0:00}:{1:00}:{2:00}",
                    PlayerStats.getTimer().GetTime() / 3600,
                    PlayerStats.getTimer().GetTime() / 60,
                    PlayerStats.getTimer().GetTime() % 60
                );
            }
        }
    }
}

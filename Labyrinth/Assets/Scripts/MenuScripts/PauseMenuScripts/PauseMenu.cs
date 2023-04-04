using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

    public class PauseMenu : MonoBehaviour
    {
        public GameObject pauseMenu;
        public GameObject playerCamera;

        private bool isPaused = false;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7))
            {
                isPaused = !isPaused;

                if (isPaused)
                {
                    pauseMenu.SetActive(true);
                    EventSystem.current.SetSelectedGameObject(GameObject.Find("ResumeGameButton"));
                    Time.timeScale = 0;
                }
                else
                {
                
                    pauseMenu.SetActive(false);
                
                    Time.timeScale = 1;
                }
            }
        }

        public void OnResumeButtonClicked()
        {
        
            pauseMenu.SetActive(false);

            Time.timeScale = 1;

            isPaused = false;
        }
    }
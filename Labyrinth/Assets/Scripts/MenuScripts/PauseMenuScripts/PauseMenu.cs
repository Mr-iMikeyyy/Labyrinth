using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

    public class PauseMenu : MonoBehaviour
    {
        public GameObject pauseMenu;
        public GameObject playerCamera;

        private bool isPaused = false;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = !isPaused;

                if (isPaused)
                {
                    pauseMenu.SetActive(true);

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
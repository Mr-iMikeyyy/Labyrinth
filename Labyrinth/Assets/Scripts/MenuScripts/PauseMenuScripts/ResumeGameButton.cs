using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeGameButton : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject playerCamera;

    void Start()
    {
        // Hide the pause menu on start
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        // Check for the ESC key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle the pause menu
            TogglePauseMenu();
        }
    }

    public void OnResumeButtonClicked()
    {
        // Hide the pause menu
        pauseMenu.SetActive(false);

        // Unlock the player's view
        playerCamera.GetComponent<MouseLook>().enabled = true;

        // Unpause the game
        Time.timeScale = 1;
    }

    private void TogglePauseMenu()
    {
        if (pauseMenu.activeSelf)
        {
            // Hide the pause menu
            pauseMenu.SetActive(false);

            // Unlock the player's view
            playerCamera.GetComponent<MouseLook>().enabled = true;

            // Unpause the game
            Time.timeScale = 1;
        }
        else
        {
            // Show the pause menu
            pauseMenu.SetActive(true);

            // Lock the player's view
            playerCamera.GetComponent<MouseLook>().enabled = false;

            // Pause the game
            Time.timeScale = 0;
        }
    }
}

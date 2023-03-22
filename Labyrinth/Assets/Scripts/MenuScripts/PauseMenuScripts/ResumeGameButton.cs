using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeGameButton : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject playerCamera;

    public void ResumeGame()
    {
        // Hide the pause menu
        pauseMenu.SetActive(false);


        // Unpause the game
        Time.timeScale = 1;
    }
}

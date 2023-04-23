using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeGameButton : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject playerCamera;

    public void ResumeGame()
    {
        Time.timeScale = 1;
        PlayerStats.timer.StartTiming();
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}

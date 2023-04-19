using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class NextLevelButton : MonoBehaviour
{
    public GameObject confirmationMenu;
    

    
    public void OpenConfirmationBox()
    {
        confirmationMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(GameObject.Find("NextLevelYes"));
    }

    public void OpenNextLevel()
    {
        if (PlayerStats.getCurrentLevel() >= PlayerStats.getMaxLevel() ) {
            SceneManager.LoadScene("Credits");
        } else {
            DontDestroyOnLoad(PlayerStats.getTimerObject());
            // Reset the timer and increment the current level.
            PlayerStats.getTimer().ResetTimer();
            PlayerStats.incrementCurrentLevel();
            SceneManager.LoadScene("Maze Gen Test");
        }
    }

    public void CloseConfirmationBox()
    {
        confirmationMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(GameObject.Find("NextLevelButton"));
    }
}

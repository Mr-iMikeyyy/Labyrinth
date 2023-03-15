using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject mainMenuConfirmationMenu;

    private void Start()
    {
        pauseMenu.SetActive(false);
        mainMenuConfirmationMenu.SetActive(false);
    }

    public void OpenMainMenuConfirmationMenu()
    {
        pauseMenu.SetActive(false);
        mainMenuConfirmationMenu.SetActive(true);
    }

    public void CloseMainMenuConfirmationMenu()
    {
        pauseMenu.SetActive(true);
        mainMenuConfirmationMenu.SetActive(false);
    }

    public void ConfirmMainMenu()
    {
        // Load the main menu scene
        SceneManager.LoadScene("MainMenu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public GameObject mainMenuConfirmationMenu;

    private void Start()
    {
        mainMenuConfirmationMenu.SetActive(false);
    }

    public void OpenMainMenuConfirmationMenu()
    {
       
        mainMenuConfirmationMenu.SetActive(true);
    }

    public void CloseMainMenuConfirmationMenu()
    {
       
        mainMenuConfirmationMenu.SetActive(false);
    }

    public void ConfirmMainMenu()
    {
        
        SceneManager.LoadScene("MainMenu");
    }
}

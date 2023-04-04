using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

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
        EventSystem.current.SetSelectedGameObject(GameObject.Find("MainMenuYes"));
    }

    public void CloseMainMenuConfirmationMenu()
    {
       
        mainMenuConfirmationMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(GameObject.Find("MainMenuButton"));
    }

    public void ConfirmMainMenu()
    {
        
        SceneManager.LoadScene("MainMenu");
    }
}

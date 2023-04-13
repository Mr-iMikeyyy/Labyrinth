using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SaveMainMenu : MonoBehaviour
{
    public GameObject confirmationMenu;

    public void OpenConfirmationBox()
    {
        confirmationMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(GameObject.Find("MainMenuYes"));
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void CloseConfirmationBox()
    {
       
        confirmationMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(GameObject.Find("MainMenuButton"));
    }
}

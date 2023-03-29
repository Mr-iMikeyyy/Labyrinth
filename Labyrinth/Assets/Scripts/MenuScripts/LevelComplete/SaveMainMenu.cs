using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveMainMenu : MonoBehaviour
{
    public GameObject confirmationMenu;

    public void OpenConfirmationBox()
    {
        confirmationMenu.SetActive(true);
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void CloseConfirmationBox()
    {
       
        confirmationMenu.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    public GameObject confirmationMenu;

    public void OpenConfirmationBox()
    {
        confirmationMenu.SetActive(true);
    }

    public void OpenNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CloseConfirmationBox()
    {
        confirmationMenu.SetActive(false);
    }
}

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CloseConfirmationBox()
    {
        confirmationMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(GameObject.Find("NextLevelButton"));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ExitGameButton : MonoBehaviour
{
    public GameObject exitConfirmation;

    void Start()
    {
        CloseExitConfirmation();
    }

    public void OpenExitConfirmation()
    {
        exitConfirmation.SetActive(true);
        EventSystem.current.SetSelectedGameObject(GameObject.Find("ExitGameYes"));
    }

    public void CloseExitConfirmation()
    {
        exitConfirmation.SetActive(false);
        EventSystem.current.SetSelectedGameObject(GameObject.Find("ExitGameButton"));

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

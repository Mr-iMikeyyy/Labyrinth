using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    }

    public void CloseExitConfirmation()
    {
        exitConfirmation.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
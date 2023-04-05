using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class RestartGameButton : MonoBehaviour
{
    public GameObject confirmationDialog;

    public void OpenRestartConfirmationMenu()
    {
        confirmationDialog.SetActive(true);
        EventSystem.current.SetSelectedGameObject(GameObject.Find("RestartYes"));
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CloseRestartConfirmationMenu()
    {
        confirmationDialog.SetActive(false);
        EventSystem.current.SetSelectedGameObject(GameObject.Find("RestartGameButton"));
    }
}

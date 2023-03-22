using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGameButton : MonoBehaviour
{
    public GameObject confirmationDialog;

    private void Start()
    {
        confirmationDialog.SetActive(false);
    }

    public void OpenRestartConfirmationMenu()
    {
        confirmationDialog.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CloseRestartConfirmationMenu()
    {
        confirmationDialog.SetActive(false);
    }
}

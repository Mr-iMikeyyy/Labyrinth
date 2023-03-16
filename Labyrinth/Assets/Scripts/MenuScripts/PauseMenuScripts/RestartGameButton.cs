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

    public void OnClick()
    {
        confirmationDialog.SetActive(true);
    }

    public void OnConfirm()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnCancel()
    {
        confirmationDialog.SetActive(false);
    }
}

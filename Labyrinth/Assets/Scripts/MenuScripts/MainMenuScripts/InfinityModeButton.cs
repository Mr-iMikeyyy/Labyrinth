using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfinityModeButton : MonoBehaviour
{
    public GameObject confirmationBox;

    public void ShowConfirmationBox()
    {
        confirmationBox.SetActive(true);
    }

    public void CloseConfirmationBox()
    {
        confirmationBox.SetActive(false);
    }

    public void StartInfinityMode()
    {
        SceneManager.LoadScene("InfinityModeScene");
    }
}

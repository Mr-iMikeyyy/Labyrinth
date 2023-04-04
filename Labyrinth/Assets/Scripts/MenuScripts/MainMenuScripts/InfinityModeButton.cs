using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class InfinityModeButton : MonoBehaviour
{
    public GameObject confirmationBox;

    public void Start()
    {
        CloseConfirmationBox();
    }

    public void ShowConfirmationBox()
    {
        confirmationBox.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(GameObject.Find("InfinityYes"));
    }

    public void CloseConfirmationBox()
    {
        confirmationBox.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(GameObject.Find("InfinityModeButton"));
    }

    public void StartInfinityMode()
    {
        SceneManager.LoadScene("InfinityModeScene");
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using UnityEngine;

public class NewGameButton : MonoBehaviour
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

    public void StartNewGame()
    {
        MazeParams.setSize(15);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Maze gen test");
    }
}


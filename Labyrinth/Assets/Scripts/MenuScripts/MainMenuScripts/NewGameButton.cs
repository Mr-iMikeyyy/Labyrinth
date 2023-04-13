using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewGameButton : MonoBehaviour
{
    public GameObject confirmationBox;
    
    public void OpenConfirmationBox()
    {
        confirmationBox.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(GameObject.Find("NewGameYes"));
    }

        
    public void CloseConfirmationBox()
    {
        confirmationBox.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(GameObject.Find("NewGameButton"));
    }

    public void StartNewGame()
    {
        MazeParams.setSize(15);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
    }
}


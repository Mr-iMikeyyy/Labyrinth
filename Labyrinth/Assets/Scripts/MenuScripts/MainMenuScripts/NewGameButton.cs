using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class NewGameButton : MonoBehaviour
{
    public GameObject confirmationBox;
    public GameObject InputCanvas;
    public GameObject NameCoinfirmationButton;
    public Button ExitInputButton;
    public TMP_InputField NameInputField;
    
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


    // Handle player name
    public void ShowNameInput()
    {
        confirmationBox.SetActive(false);
        InputCanvas.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(GameObject.Find("InputName"));
    }

    public void HideNameInput()
    {
        InputCanvas.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(GameObject.Find("NewGameButton"));
    }

    public void ValidateName()
    {
        // PlayerStats.Name = NameInputField.text;
        // if (PlayerStats.Name == "")
        // {
        //     // make input box outlined in red and say "Please enter a name"
        //     NameInputField.text = "Please enter a name";
        //     NameInputField.textComponent.color = Color.red;
        //     return;
        // }
        StartNewGame();
    }


    // Start new maze
    public void StartNewGame()
    {
        MazeParams.setSize();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Maze gen test");
        // Start timer
        
        // Start timer
        PlayerStats.timer.StartTiming();
    }
}


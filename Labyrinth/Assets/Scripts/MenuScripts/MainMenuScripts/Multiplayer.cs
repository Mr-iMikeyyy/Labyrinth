using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using Mirror;

public class Multiplayer : MonoBehaviour
{
    public GameObject MpMenu;
    public Button JoinButton;
    public Button HostButton;
    public Button ExitButton;
    public TMP_InputField serverIp;


    //Multiplayer menu
    public void ShowMenu()
    {
        MpMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(GameObject.Find("Server"));
    }

    public void HideMenu()
    {
        MpMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(GameObject.Find("NewGameButton"));
    }

    public void JoinGame()
    {
        string ipAddress = serverIp.text;

        if (!string.IsNullOrEmpty(ipAddress))
        {
            NetworkManager.singleton.networkAddress = ipAddress;
            NetworkManager.singleton.StartClient();
        }
        else
        {
            Debug.LogError("Invalid IP address");
        }
    }

    public void HostGame()
    {
        NetworkManager.singleton.StartHost();
    }
}

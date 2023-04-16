using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using PlayerInformation;
using UnityEngine.EventSystems;

namespace PlayerInformation
{
    public class LevelCompleted : MonoBehaviour
    {
        [SerializeField] private GameObject levelCompleteMenu;
        private GameObject playerCamera;

        private bool isCompleted = false;

        void Start()
        {
            playerCamera = GameObject.Find("Main Camera");

        }
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Something has entered the trigger volume.");
            if (other.CompareTag("Player") && !isCompleted)
            {
                isCompleted = true;
                Debug.Log("Player has entered the trigger volume.");
                ShowLevelCompleteMenu();
            }
        }

        private void ShowLevelCompleteMenu()
        {
            levelCompleteMenu.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(GameObject.Find("NextLevelButton"));
        }
    }
}

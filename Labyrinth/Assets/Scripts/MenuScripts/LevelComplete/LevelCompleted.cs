using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using PlayerInformation;

namespace PlayerInformation
{
    public class LevelCompleted : MonoBehaviour
    {
        public GameObject levelCompleteMenu;
        public GameObject playerCamera;

        private bool isCompleted = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && !isCompleted)
            {
                isCompleted = true;

                ShowLevelCompleteMenu();
            }
        }

        private void ShowLevelCompleteMenu()
        {
            levelCompleteMenu.SetActive(true);
        }
    }
}

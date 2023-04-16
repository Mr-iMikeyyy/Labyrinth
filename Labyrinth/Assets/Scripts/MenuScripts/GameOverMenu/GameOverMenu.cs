using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject playerCamera;

    private bool isGameOver = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isGameOver = true;
            Time.timeScale = 0;
            playerCamera.SetActive(false);
            gameOverMenu.SetActive(true);

            EventSystem.current.SetSelectedGameObject(GameObject.Find("ReturnButton"));
        }
    }

    private void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            ReturnToMainMenu();
        }
    }

    public void GotoMainMenu()
    {
        ReturnToMainMenu();
    }

    private void ReturnToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu2");
    }
}

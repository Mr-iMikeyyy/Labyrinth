using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenuContainer;
    private GameObject gameOverMenu;

    private bool isGameOver = false;

    void Start() {
        gameOverMenu = gameOverMenuContainer.transform.GetChild(0).gameObject;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isGameOver = true;
            Time.timeScale = 0;
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

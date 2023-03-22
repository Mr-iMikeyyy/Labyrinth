using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject playerCamera;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                // Show the pause menu
                pauseMenu.SetActive(true);

 

                // Pause the game
                Time.timeScale = 0;
            }
            else
            {
                // Hide the pause menu
                pauseMenu.SetActive(false);

         

                // Unpause the game
                Time.timeScale = 1;
            }
        }
    }

    public void OnResumeButtonClicked()
    {
        // Hide the pause menu
        pauseMenu.SetActive(false);



        // Unpause the game
        Time.timeScale = 1;

        // Reset the isPaused variable
        isPaused = false;
    }
}

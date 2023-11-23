using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isGamePaused = false;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0; // Pause the game by setting the time scale to 0
        isGamePaused = true;
        pauseMenu.SetActive(true); // Show the pause menu UI
    }

    public void Resume()
    {
        Time.timeScale = 1; // Resume the game by setting the time scale to 1 (normal)
        isGamePaused = false;
        pauseMenu.SetActive(false); // Hide the pause menu UI
    }

    public void Home()
    {
        Time.timeScale = 1f; // Ensure the time scale is normal before loading the main menu
        SceneManager.LoadScene("MainMenu");
    }
}

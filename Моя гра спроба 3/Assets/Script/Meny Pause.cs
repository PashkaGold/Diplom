using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenyPause : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log(7765);
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        // Скидання стану паузи перед завантаженням головного меню
        Resume();
        SceneManager.LoadScene("MainMenu"); // Замість "MainMenu" використовуйте ім'я вашої сцени головного меню
    }

    public void QuitGame()
    {
        // Скидання стану паузи перед завантаженням попередньої сцени
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    // Викликайте цей метод при завантаженні сцени гри, щоб переконатися, що гра не залишається в паузі
    void OnEnable()
    {
        Resume();
    }
}

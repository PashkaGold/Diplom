using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject shopMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

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
        shopMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        shopMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
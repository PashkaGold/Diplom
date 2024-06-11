using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Maymeny : MonoBehaviour
{
    public int sceneIndex;
    public void PlayGame()
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void ExitGame()
    {
        Debug.Log("Ігра закрилась ");
        Application.Quit();
    }
}

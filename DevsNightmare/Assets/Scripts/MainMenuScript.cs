using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void HTP()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting...");
    }

}

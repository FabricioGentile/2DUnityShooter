using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    private GUISkin newSkin;

    private void Start()
    {
        newSkin = Resources.Load("Menu Skin") as GUISkin;
    }
    private void OnGUI()
    {
        const int buttonWidth = 160;
        const int buttonHeight = 50;

        GUI.skin = newSkin;

        //Retry
        if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2),
                               (Screen.height / 3 * 2) - (buttonWidth / 2),
                               buttonWidth, buttonHeight), "Retry"))
        {
            ScoreScript.scoreValue = 0;
            SceneManager.LoadScene("Level1");
        }

        //Back to menu
        if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2),
                              (Screen.height / 3 * 3) - (buttonWidth / 2),
                              buttonWidth, buttonHeight), "Menu"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}

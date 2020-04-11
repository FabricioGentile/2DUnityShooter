using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    private GUISkin newSkin;

    private void Start()
    {
        newSkin = Resources.Load("Menu Skin") as GUISkin;
    }
    private void OnGUI()
    {
        const int buttonWidth = 150;
        const int buttonHeight = 50;

        GUI.skin = newSkin;
        
        if (GUI.Button(new Rect(Screen.width/2 - (buttonWidth/2),
                               (Screen.height/3*2 ) - (buttonWidth/2), 
                               buttonWidth, buttonHeight), "Start!")){
            SceneManager.LoadScene("Level1");
        }

        Debug.Log(Screen.height);
        if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2),
                       (Screen.height /3 * 2 + 60) - (buttonWidth / 2),
                       buttonWidth, buttonHeight), "Options")) 
        {
            SceneManager.LoadScene("Menu");
        }

        if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2),
                     (Screen.height / 3 * 3 + 10) - (buttonWidth / 2),
                     buttonWidth, buttonHeight), "Quit"))
        {
            Application.Quit();
        }
    }
}

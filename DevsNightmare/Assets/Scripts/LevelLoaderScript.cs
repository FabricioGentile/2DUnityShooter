using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderScript : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    
    public void LoadNextLevel()
    {
        //load the next scene based on index 
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //play animation
        transition.SetTrigger("Start");

        //pause for an amount of time (wait) 
        yield return new WaitForSeconds(transitionTime);

        //load scene
        SceneManager.LoadScene(levelIndex);
    }

} 

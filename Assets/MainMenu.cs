using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    void Start()
    {

    }
    public void playFirstScene(string sceneName)
    {
        SceneManager.LoadScene("AnimacionIntro");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
}

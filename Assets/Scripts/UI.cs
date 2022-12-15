using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    private int currentScene;
   

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex; // gets current scene / level
        

    }

   


    public void QuitButton()
    {
        Application.Quit();
    }

    public void Reload()
    {

        Time.timeScale = 1;
        SceneManager.LoadScene(currentScene);
       
    }
}

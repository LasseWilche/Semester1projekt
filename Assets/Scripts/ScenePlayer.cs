using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenePlayer : MonoBehaviour
{
    Scene currentScene;
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }
    
    public void NextScene()
    {
        SceneManager.LoadScene(currentScene.buildIndex+1);
    }

    public void FirstLevel()
    {
        SceneManager.LoadScene("Level1.2");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void StartTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}

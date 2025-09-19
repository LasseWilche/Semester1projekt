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
        SceneManager.LoadSceneAsync(currentScene.buildIndex+1);
    }
}

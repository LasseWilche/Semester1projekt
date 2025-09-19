using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenePlayer : MonoBehaviour
{
    private Scene currentScene;
    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    public void NextScene()
    {
        SceneManager.LoadSceneAsync(currentScene.buildIndex+1);
    }
}

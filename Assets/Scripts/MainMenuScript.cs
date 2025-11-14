using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public ScenePlayer ScenePlayer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScenePlayer = GetComponent<ScenePlayer>();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

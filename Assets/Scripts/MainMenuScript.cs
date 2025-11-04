using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public ScenePlayer ScenePlayer;
    public GameObject CreditsCanvas;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScenePlayer = GetComponent<ScenePlayer>();
    }

    public void CreditsPressed()
    {
        CreditsCanvas.SetActive(true);
    }

    public void CreditsClose()
    {
        CreditsCanvas.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

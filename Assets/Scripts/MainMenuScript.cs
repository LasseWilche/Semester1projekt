using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public ScenePlayer ScenePlayer;
    public GameObject OptionsPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScenePlayer = GetComponent<ScenePlayer>();
    }

    public void OptionsPressed()
    {
        OptionsPanel.SetActive(true);
    }

    public void OptionsClose()
    {
        OptionsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

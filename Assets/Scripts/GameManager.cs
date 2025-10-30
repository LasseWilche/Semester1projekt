using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool bothAlive = true;
    public ScenePlayer scenePlayer;
    private void Start()
    {
        scenePlayer = GetComponent<ScenePlayer>();
    }
    public void GameOver()
    {
        scenePlayer.MainMenu();
    }
    public void Victory()
    {
        scenePlayer.MainMenu();
    }
}

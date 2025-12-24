using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool bothAlive = true;
    ScenePlayer scenePlayer;
    private void Start()
    {
        scenePlayer = GetComponent<ScenePlayer>();
    }
    public void GameOver()
    {
        scenePlayer.GameOver();
    }
    public void Victory()
    {
        scenePlayer.MainMenu();
    }
}

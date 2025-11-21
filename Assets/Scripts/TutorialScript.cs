using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    [SerializeField] TutorialScript otherTutorial;
    [SerializeField] EnemySpawnManager Spawner;
    public bool ready;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")==true)
        {
            if (otherTutorial.ready == true) StartCoroutine(Spawner.TutorialLoop());
            else ready = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true) ready = false;
    }
}

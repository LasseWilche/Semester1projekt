using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    [SerializeField] TutorialScript otherTutorial;
    [SerializeField] EnemySpawnManager Spawner;
    public bool ready;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            if (otherTutorial.ready == true && Spawner.tutorialRunning == false) StartCoroutine(Spawner.TutorialLoop());
            else ready = true;
        }
    }
    private void OnTriggerEnter2D(Collision2D collision)
    {

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true) ready = false;
    }
}

using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    [SerializeField] TutorialScript otherTutorial;
    [SerializeField] EnemySpawnManager Spawner;
    [SerializeField] GameObject text1;
    [SerializeField] GameObject text2;
    public bool ready;

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            if (otherTutorial.ready == true && Spawner.tutorialRunning == false)
            {
                text1.SetActive(false);
                text2.SetActive(false);
                StartCoroutine(Spawner.TutorialLoop());
            }
            else ready = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true) ready = false;
    }
}

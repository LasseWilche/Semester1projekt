using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class BossScript : MonoBehaviour
{
    //Boss Patrol variables
    public float moveSpeed;
    public Transform[] patrolPoints;
    public float waitTime;
    int currentPointIndex;
    bool once;

    //Boss Animation variables
    [SerializeField] private Animator bossAnimator;

    //BOSS ATTACK VARIABLES
    //Makes sure bullet gets destroyed after time


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position != patrolPoints[currentPointIndex].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, moveSpeed * Time.deltaTime);
        }
        else
        {
            if (once == false)
            {
                once = true;
                StartCoroutine(Wait());
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        if (currentPointIndex + 1 < patrolPoints.Length)
        {
            currentPointIndex++;
        }
        else
        {
            currentPointIndex = 0;
        }
        once = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Knockback player
            
        }
    }
}

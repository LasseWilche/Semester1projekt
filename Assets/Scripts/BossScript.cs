using System.Collections;
using UnityEditor.Callbacks;
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
    private Rigidbody2D rb;

    //Boss Animation variables
    [SerializeField] private Animator bossAnimator;

    //BOSS ATTACK VARIABLES

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();   //For knockback
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

       void OnTriggerEnter2D(Collider2D collision)   //For knockback
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss"))
        {
            KnockbackPlayer(collision.transform, 10f);

        }
    }

    public void KnockbackPlayer(Transform playerTransform, float knockbackForce)    //For knockback
    {
        Vector2 direction = (transform.position - playerTransform.position).normalized;
        rb.linearVelocity= direction * knockbackForce;
    }
}

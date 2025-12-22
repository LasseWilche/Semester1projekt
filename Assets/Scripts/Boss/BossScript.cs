using System.Collections;
using System.Net;
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
    int previousPointIndex;
    bool once;
    private Rigidbody2D rb;

    //Boss Animation variables
    [SerializeField] private Animator bossAnimator;

    //BOSS ATTACK VARIABLES

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bossAnimator = GetComponent<Animator>();
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
        BossMovement();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        if (currentPointIndex + 1 < patrolPoints.Length)
        {
            previousPointIndex = currentPointIndex;
            currentPointIndex = Random.Range(1, patrolPoints.Length);
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

    private void BossMovement()
    {
        switch (previousPointIndex, currentPointIndex)
        {
            case (0, 1):
                bossAnimator.SetBool("bossIsWalking", true);
                bossAnimator.SetFloat("BossX", -1);
                bossAnimator.SetFloat("BossY", 0);
                break;
            case (0, 2):
                bossAnimator.SetBool("bossIsWalking", true);
                bossAnimator.SetFloat("BossX", -1);
                bossAnimator.SetFloat("BossY", -1);
                break;
            case (0, 3):
                bossAnimator.SetBool("bossIsWalking", true);
                bossAnimator.SetFloat("BossX", 0);
                bossAnimator.SetFloat("BossY", -1);
                break;
            case (0, 4):
                bossAnimator.SetBool("bossIsWalking", true);
                bossAnimator.SetFloat("BossX", -1);
                bossAnimator.SetFloat("BossY", -1);
                break;
            case (1, 0):
                bossAnimator.SetBool("bossIsWalking", true);
                bossAnimator.SetFloat("BossX", 1);
                bossAnimator.SetFloat("BossY", 0);
                break;
            case (1, 2):
                bossAnimator.SetBool("bossIsWalking", true);
                bossAnimator.SetFloat("BossX", 0);
                bossAnimator.SetFloat("BossY", -1);
                break;
            case (1, 3):
                bossAnimator.SetBool("bossIsWalking", true);
                bossAnimator.SetFloat("BossX", 1);
                bossAnimator.SetFloat("BossY", -1);
                break;
            case (1, 4):
                bossAnimator.SetBool("bossIsWalking", true);
                bossAnimator.SetFloat("BossX", 1);
                bossAnimator.SetFloat("BossY", -1);
                break;
            case (2, 0):
                bossAnimator.SetBool("bossIsWalking", true);
                bossAnimator.SetFloat("BossX", 1);
                bossAnimator.SetFloat("BossY", 1);
                break;
            case (2, 1):
                bossAnimator.SetBool("bossIsWalking", true);
                bossAnimator.SetFloat("BossX", 0);
                bossAnimator.SetFloat("BossY", 1);
                break;
            case (2, 3):
                bossAnimator.SetBool("bossIsWalking", true);
                bossAnimator.SetFloat("BossX", 1);
                bossAnimator.SetFloat("BossY", 0);
                break;
            case (2, 4):
                bossAnimator.SetBool("bossIsWalking", true);
                bossAnimator.SetFloat("BossX", 1);
                bossAnimator.SetFloat("BossY", 1);
                break;
            case (3, 0):
                bossAnimator.SetBool("bossIsWalking", true);
                bossAnimator.SetFloat("BossX", 0);
                bossAnimator.SetFloat("BossY", 1);
                break;
            case (3, 1):
                bossAnimator.SetBool("bossIsWalking", true);
                bossAnimator.SetFloat("BossX", -1);
                bossAnimator.SetFloat("BossY", 1);
                break;
            case (3, 2):
                bossAnimator.SetBool("bossIsWalking", true);
                bossAnimator.SetFloat("BossX", -1);
                bossAnimator.SetFloat("BossY", 0);
                break;
            case (3, 4):
                bossAnimator.SetBool("bossIsWalking", true);
                bossAnimator.SetFloat("BossX", -1);
                bossAnimator.SetFloat("BossY", 1);
                break;
            case (4, 0):
                bossAnimator.SetBool("bossIsWalking", true);
                bossAnimator.SetFloat("BossX", 1);
                bossAnimator.SetFloat("BossY", 1);
                break;
            case (4, 1):
                bossAnimator.SetBool("bossIsWalking", true);
                bossAnimator.SetFloat("BossX", -1);
                bossAnimator.SetFloat("BossY", 1);
                break;
            case (4, 2):
                bossAnimator.SetBool("bossIsWalking", true);
                bossAnimator.SetFloat("BossX", -1);
                bossAnimator.SetFloat("BossY", -1);
                break;
            case (4, 3):
                bossAnimator.SetBool("bossIsWalking", true);
                bossAnimator.SetFloat("BossX", 1);
                bossAnimator.SetFloat("BossY", -1);
                break;
        }
    }
}

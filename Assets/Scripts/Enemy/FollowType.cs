using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;
public class FollowType : EnemyBaseClass
{
    public FollowType() : base()
    {
    }

    public override IEnumerator AttackScript(Collision2D collision)
    {
        animator.Play("Melee");
        yield return new WaitForSeconds(0.5f);
        if (collision.gameObject.GetComponent<PlayerHealthManager>() != null)
        {
            collision.gameObject.GetComponent<PlayerHealthManager>().TakeDamage(1);
        }
        else Debug.Log("Player has no health manager");
    }
    public override void MovementScript()
    {
        base.MovementScript();
        angle = target.position - myrb.transform.position;  //finds the difference between our position, and the target position
        angle.Normalize();      //normalizes the angle (makes it into a 1vector)
        myrb.transform.position += (movementSpeed * Time.deltaTime * angle);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && alive)
        {
            Debug.Log("touching");
            StartCoroutine(AttackScript(collision));
            cooldown = 3;
        }
    }
}
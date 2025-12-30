using NUnit.Framework.Internal.Filters;
using System.Collections;
using UnityEngine;
public class FollowType : EnemyBaseClass
{
    public FollowType() : base()
    {
    }

    public override IEnumerator AttackScript()
    {

        animator.Play("Melee");
        yield return new WaitForSeconds(0.5f);
        if (target != null)
        {
            if (target.gameObject.GetComponent<PlayerHealthManager>() != null)
            {
                target.gameObject.GetComponent<PlayerHealthManager>().TakeDamage(1);
            }
            else Debug.Log("Player has no health manager");
        }
        else Debug.Log("Attacking no target");
    }
    public override void MovementScript()
    {
        base.MovementScript();
        if (target != null)
        {
            angle = target.position - myrb.transform.position;  //finds the difference between our position, and the target position
            angle.Normalize();      //normalizes the angle (makes it into a 1vector)
            myrb.linearVelocity = movementSpeed * angle;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && alive)
        {
            StartCoroutine(AttackScript());
            cooldown = 3;
        }
    }
}
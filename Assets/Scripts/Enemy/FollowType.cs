using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;
public class FollowType : EnemyBaseClass
{
    public FollowType() : base()
    {
    }

    public override IEnumerator AttackScript(Collision collision)
    {
        animator.Play("Melee");
        yield return new WaitForSeconds(0.5f);
        collision.gameObject.GetComponent<PlayerHealthManager>().TakeDamage(1);
    }
    public override void MovementScript()
    {
        base.MovementScript();
        angle = target.position - myrb.transform.position;  //finds the difference between our position, and the target position
        angle.Normalize();      //normalizes the angle (makes it into a 1vector)
        myrb.transform.position += (movementSpeed * Time.deltaTime * angle);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")||alive)
        {
            AttackScript(collision);
            cooldown = 3;
        }
    }
}
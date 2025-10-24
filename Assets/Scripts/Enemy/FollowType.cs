using UnityEditor.Rendering;
using UnityEngine;
public class FollowType : EnemyBaseClass
{
    readonly int damage;

    public FollowType() : base()
    {
        damage = 1;
    }

    public override void AttackScript(Collision collision)
    {
        animator.Play("Melee");
        
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
        if (collision.gameObject.CompareTag("Player"))
        {
            AttackScript(collision);
            cooldown = 3;
        }
    }
}
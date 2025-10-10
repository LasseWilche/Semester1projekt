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
        Debug.Log("I dealt "+ damage + " damage");
        //collision.gameObject.GetComponent<PlayerHealthManager>().TakeDamage(damage);
    }
    public override void MovementScript()
    {
        if (Vector2.Distance(p1.transform.position, myrb.transform.position) <
            Vector2.Distance(p2.transform.position, myrb.transform.position)) //finds the closest player
        {
            target = p1.transform;     //if p1 is closest, our target is p1
        }
        else
        {
            target = p2.transform;     //if p2 is closest, our target is p2
        }
        angle = target.position - myrb.transform.position;  //finds the difference between our position, and the target position
        angle.Normalize();      //normalizes the angle (makes it into a 1vector)
        myrb.transform.position += (movementSpeed * Time.deltaTime *angle);
    }
}
using UnityEngine;

public class EnemySniper : EnemyBaseRanged
{
    public EnemySniper() : base(1, 1, 20, 0)
    {
        cooldown = 5;
        movementSpeed = 2.5f;
    }
    /*public override void Update()
    {
        base.Update();
        animator.Play("Moving");
        //else animator.Play("Idle");
    }*/
}

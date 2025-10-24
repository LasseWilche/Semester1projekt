using UnityEngine;

public class StandardBulletEnemy : EnemyBaseRanged
{
    public StandardBulletEnemy() : base(1, 1, 8, 5)
    {
        movementSpeed = 4;
        cooldown = 4;
    }
}

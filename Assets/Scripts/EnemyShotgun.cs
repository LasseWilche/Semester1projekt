using UnityEngine;

public class EnemyShotgun : EnemyBaseRanged
{
    public EnemyShotgun() : base(1, 5, 5, 15)
    {
        cooldown = 5;
        movementSpeed = 3;
    }
}

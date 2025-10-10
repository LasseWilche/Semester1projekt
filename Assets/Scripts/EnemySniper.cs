using UnityEngine;

public class EnemySniper : EnemyBaseRanged
{
    public EnemySniper() : base(1, 1, 20, 0)
    {
        cooldown = 5;
        movementSpeed = 2.5f;
    }
    private void Awake()
    {
        shootingAngle = this.transform.Find("ShootingAngle").gameObject;
    }
}

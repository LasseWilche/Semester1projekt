using UnityEngine;
using UnityEngine.Audio;

public class EnemyShotgun : EnemyBaseRanged
{
 
    public EnemyShotgun() : base(5, 5, 15)
    {
        

        cooldown = 5;
        movementSpeed = 3;
    }
}

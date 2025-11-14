using UnityEngine;
using UnityEngine.Audio;

public class EnemyShotgun : EnemyBaseRanged
{
    public AudioClip shotsound1;
    public AudioClip shotsound2;
    public EnemyShotgun() : base(5, 5, 15)
    {
        int i = Random.Range(0, 3);
        AudioClip randomClip = (i == 0) ? MeleeSound1 : (i == 1) ? MeleeSound2 : MeleeSound3;
        audioSource.PlayOneShot(randomClip);

        cooldown = 5;
        movementSpeed = 3;
    }
}

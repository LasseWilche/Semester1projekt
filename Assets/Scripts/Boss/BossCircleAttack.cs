using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline.Actions;

public class BossCircleAttack : MonoBehaviour
{
    //Variables for boss circle attack
    private float waitStart;
    public GameObject bossBulletPrefab;
    public int bulletCount = 12;
    public float radius = 5f;
    public float bulletSpeed = 5;
    public float spawnInterval = 5f;
    public BossHealthManager bossHM;

    private float angleStep;

    [SerializeField] private Animator bossAnimator;
    [Tooltip("Optional parent for instantiated bullets (keeps hierarchy clean)")]
    public Transform bulletParent;
    [Tooltip("Destroy instantiated bullets after this many seconds as a safety fallback (0 = disabled)")]
    public float bulletLifetime = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Sets anglestep between bullet spawn points
        waitStart = 5;
        angleStep = 360f / bulletCount;
        StartCoroutine(FireCircleAttack());
    }
    public IEnumerator FireCircleAttack()
    {
        yield return new WaitForSeconds(waitStart);
        bossHM.invincible = false;
        waitStart = 0;
        while (bossHM.bossIsAlive == true)
        {
            /*
            bossAnimator.SetBool("IsCircleAttacking", true);
            yield return new WaitForSeconds(0.5f);
            bossAnimator.SetBool("IsCircleAttacking", false);
            */
            for (int i = 0; i < bulletCount; i++)
            {
                float angle = angleStep * i;
                float x = transform.position.x + radius * Mathf.Cos(Mathf.Deg2Rad * angle);
                float y = transform.position.y + radius * Mathf.Sin(Mathf.Deg2Rad * angle);
                Vector3 spawnPos = new Vector3(x, y, 0f);

                GameObject bullet = Instantiate(bossBulletPrefab, spawnPos, Quaternion.identity, bulletParent);

                Vector2 dir = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle));
                if (bullet.transform.up.sqrMagnitude > 0f)
                    bullet.transform.up = new Vector3(dir.x, dir.y, 0f);

                var bulletComp = bullet.GetComponent<BossBullet>();
                if (bulletComp != null)
                {
                    bulletComp.Initialize(bulletSpeed, dir);
                }else
                {
                    Debug.LogWarning($"BossCircleAttack: bullet prefab is missing component 'BossBullet' on {bullet.name}");
                }
                if (bulletLifetime > 0f)
                    Destroy(bullet, bulletLifetime);
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void StopAttacking()
    {
        CancelInvoke(nameof(FireCircleAttack));
    }
}

using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class BossCircleAttack : MonoBehaviour
{
    //Variables for boss circle attack
    public GameObject bossBulletPrefab;
    public int bulletCount = 12;
    public float radius = 5f;
    public float bulletSpeed = 10;
    public float spawnInterval = 5f;

    private float angleStep;
    private List<GameObject> bulletPool = new List<GameObject>();

    [SerializeField] private Animator bossAnimator;
    public float animWaitTime = 4f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Sets anglestep between bullet spawn points
        angleStep = 360f / bulletCount;
        InitializeBulletPool();
        TriggerAttack();
    }

    void InitializeBulletPool()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject bullet = Instantiate(bossBulletPrefab);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }

    public void FireCircleAttack()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject bullet = GetPooledBullet();
            if (bullet != null)
            {
                //Makes spawn point for bullets with equal spacing placed on a circle by multiplying angleStep by i
                float angle = i * angleStep;
                float x = transform.position.x + radius * Mathf.Cos(Mathf.Deg2Rad * angle);
                float y = transform.position.y + radius * Mathf.Sin(Mathf.Deg2Rad * angle);

                //Applies force to bullet in direction "forward" based on bullet position on circle
                bullet.transform.position = new Vector3(x, y, 0);
                float directionX = Mathf.Cos(Mathf.Deg2Rad * angle);
                float directionY = Mathf.Sin(Mathf.Deg2Rad * angle);

                bullet.GetComponent<BossBullet>().Initialize(bulletSpeed, new Vector2(directionX, directionY));
                bullet.SetActive(true);
            }
        }
    }

    GameObject GetPooledBullet()
    {
       foreach (GameObject bullet in bulletPool)
        {
            if (!bullet.activeInHierarchy)
            {
                return bullet;
            }
        }
        return null;
    }

    public void TriggerAttack()
    {
        InvokeRepeating("FireCircleAttack", 5f, spawnInterval);
    }
}
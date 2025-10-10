using System.Collections.Generic;
using System.Numerics;
using UnityEngine;


public class BossBulletScript : MonoBehaviour
{
    //VARIABLES FOR BOSS CIRCLE ATTACK
    public GameObject bulletPrefab;
    public int bulletCount = 12;
    public float radius = 5f;
    public float bulletSpeed = 10;
    public float spawnInterval = 5f;

    private float angleStep;
    private List<GameObject> bulletPool = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Sets angelstep between bullet spawn points
        angleStep = 360f / bulletCount;
        InitializeBulletPool();
    }

    void InitializeBulletPool()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }

    void FireCircleAttack()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject bullet = GetPooledBullet();
            if (bullet != null)
            {
                //Makes spawn point for bullets with equal spacing placed on a circle by multiplying anglestep to i.
                float angle = i * angleStep;
                float x = transform.position.x + radius * Mathf.Cos(Mathf.Deg2Rad * angle);
                float y = transform.position.y + radius * Mathf.Sin(Mathf.Deg2Rad * angle);

                //Applies force to bullet in direction "forward" based on the bullet position on circle.
                bullet.transform.position = new UnityEngine.Vector3(x, y, 0);
                float directionX = Mathf.Cos(Mathf.Deg2Rad * angle);
                float directionY = Mathf.Sin(Mathf.Deg2Rad * angle);

                bullet.GetComponent<Bullet>().Initialize(bulletSpeed, new UnityEngine.Vector2(directionX, directionY));
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
        InvokeRepeating("FireCircleAttack", 0f, spawnInterval);
    } 
}
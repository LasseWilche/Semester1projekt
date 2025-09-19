using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class ShootScript : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    void Start()
    {
        StartCoroutine(spawndelay());
    }

    private IEnumerator spawndelay()
    {
        for (int i = 0; i < 50; i++)
        {
            yield return new WaitForSeconds(1);
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().linearVelocity = bulletSpawnPoint.up * bulletSpeed;
        }
    }
    

   /* void Update()
     {
         //if (Input.GetKeyDown(KeyCode.Space))
         for(int i=0; i<8; i++)
         {
             var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
             bullet.GetComponent<Rigidbody2D>().linearVelocity = bulletSpawnPoint.up * bulletSpeed;

             Thread.Sleep(1000); //ms
         }
     } */
}
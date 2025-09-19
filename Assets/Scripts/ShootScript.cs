using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class ShootScript : MonoBehaviour
{
    public Transform bulletSpawnPoint; // Public class through which you can assign a spawn point with an empty gameObject
    public GameObject bulletPrefab; // Public class through which you can assign a gameObject to be the bullet
    public float bulletSpeed = 10; // Public value for the speed of the bullets

    void Start()
    {
        StartCoroutine(spawndelay()); // Coroutine is used for a Unity-based delay system, I define spawndelay() within it
    }

    private IEnumerator spawndelay() //IEnumerator is used for the Coroutine to work, I don't know why, it's pretty complicated
    {
        for (int i = 0; i < 50; i++) // For loop that runs 50 times
        {
            yield return new WaitForSeconds(1); // Coroutine function that adds a delay of 1 second per loop
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().linearVelocity = bulletSpawnPoint.up * bulletSpeed; // This how the bullet works yep
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
     
     // Code that didnt work above here lol
}
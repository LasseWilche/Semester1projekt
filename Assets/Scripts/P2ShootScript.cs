using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using Mono.Cecil.Cil;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;

public class P2ShootScript : MonoBehaviour
{
    public Transform bulletSpawnPointUp; // Public class through which you can assign a spawn point with an empty gameObject
    public Transform bulletSpawnPointLeft;
    public Transform bulletSpawnPointDown;
    public Transform bulletSpawnPointRight;
    public GameObject bulletPrefab; // Public class through which you can assign a gameObject to be the bullet
    public float bulletSpeed = 10; // Public value for the speed of the bullets
    private int direction;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            direction = 1;
            
            else if (Input.GetKeyDown(KeyCode.A))
                direction = 2;

            else if (Input.GetKeyDown(KeyCode.S))
                direction = 3;
        
            else if (Input.GetKeyDown(KeyCode.D))
                direction = 4;
        

        if (Input.GetKeyDown(KeyCode.E))
            if (direction == 1)
            {
                var bullet = Instantiate(bulletPrefab, bulletSpawnPointUp.position, bulletSpawnPointUp.rotation);
                bullet.GetComponent<Rigidbody2D>().linearVelocity = bulletSpawnPointUp.up * bulletSpeed;
            }

            else if (direction == 2)
            {
                var bullet = Instantiate(bulletPrefab, bulletSpawnPointLeft.position, bulletSpawnPointLeft.rotation);
                bullet.GetComponent<Rigidbody2D>().linearVelocity = -bulletSpawnPointLeft.right * bulletSpeed;
            }

            else if (direction == 3)
            {
                var bullet = Instantiate(bulletPrefab, bulletSpawnPointDown.position, bulletSpawnPointDown.rotation);
                bullet.GetComponent<Rigidbody2D>().linearVelocity = -bulletSpawnPointDown.up * bulletSpeed;
            }

            else if (direction == 4)
            {
                var bullet = Instantiate(bulletPrefab, bulletSpawnPointRight.position, bulletSpawnPointRight.rotation);
                bullet.GetComponent<Rigidbody2D>().linearVelocity = bulletSpawnPointRight.right * bulletSpeed;
            }

    }

    void Start()
    {

    }
}
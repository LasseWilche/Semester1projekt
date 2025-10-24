using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using Mono.Cecil.Cil;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;

public class NewP2ShootScript : MonoBehaviour
{
    public Transform bulletSpawnPoint; // Public class through which you can assign a spawn point with an empty gameObject
    public GameObject bulletPrefab; // Public class through which you can assign a gameObject to be the bullet
    public float bulletSpeed = 10; // Public value for the speed of the bullets
    private int direction;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().linearVelocity = bulletSpawnPoint.right * bulletSpeed;
        }
    }

    void Start()
    {

    }
}
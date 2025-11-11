using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class BulletSpawnScript : MonoBehaviour
{
    public float life = 3;  

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Destroy(gameObject);
        else if (collision.gameObject.tag == "OOBwalls")
            Destroy(gameObject);

        if (collision.gameObject.CompareTag("Enemy"))
        {
            var enemy = collision.gameObject.GetComponent<EnemyHealthManager>();
            if (enemy != null)
            {
                enemy.TakeDamage(1);
            }

            Destroy(gameObject);
        }
    }

    
}

// Ærligt talt idk hvordan det her shit virker
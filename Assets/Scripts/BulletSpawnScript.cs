using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnScript : MonoBehaviour
{
    public float life = 3; // Assigns a life value to the bullet

    void Awake()
    {
        Destroy(gameObject, life); // Defines a way to destroy it i think maybe
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject); // Ting der virker
    }
}

// Ærligt talt idk hvordan det her shit virker
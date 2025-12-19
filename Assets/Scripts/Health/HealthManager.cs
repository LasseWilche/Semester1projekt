using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class HealthManager : MonoBehaviour
{
    public int maxHealth;                           //Max health var that can be set in inspector
    public int currentHealth;                      //Current health var that's set to maxHealth at start
    public GameManager gameManager;
    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        currentHealth = maxHealth;
        gameManager = GameObject.Find("Main Camera").GetComponent<GameManager>();
        animator = GetComponent<Animator>();
    }
    //Function that manages health when gameobject takes dmg
    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;                    //Applies dmg value to currentHealth
        if (currentHealth <= 0)                     //Refrences Die function if currentHealth reaches 0 or less
        {
            DieAnimation();
        }
    }

    //Function that manages what to do when gameobject dies
    public abstract void DieAnimation();
    //Method that is called after animation has played
    public abstract void Dying();
    //Method that detects when we get hit
    
}

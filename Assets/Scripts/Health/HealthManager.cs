using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class HealthManager : MonoBehaviour
{
    public int maxHealth;                           //Max health var that can be set in inspector
    public int currentHealth;                      //Current health var that's set to maxHealth at start
    public SpriteRenderer spriteRenderer;          //Var that pulls the sprite renderer from enemy to manipulate it
    public Color ogcolor;                          //Var that pulls original color to manipulate it later
    public GameManager gameManager;
    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        ogcolor = spriteRenderer.color;
        gameManager = GameObject.Find("Main Camera").GetComponent<GameManager>();
        animator = GetComponent<Animator>();
    }
    //Function that manages health when gameobject takes dmg
    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;                    //Applies dmg value to currentHealth
        StartCoroutine(flashWhite());               //Refrences flashWhite function
        if (currentHealth <= 0)                     //Refrences Die function if currentHealth reaches 0 or less
        {
            DieAnimation();
        }
    }

    //Function that manages flashing the sprite of gameobject white (Mainly used for taking dmg)
    private IEnumerator flashWhite()
    {
        spriteRenderer.color = Color.white;         //Sets spriteRenderer var color to the color white
        yield return new WaitForSeconds(0.2f);      //Waits for 0.2 Seconds before continuing
        spriteRenderer.color = ogcolor;             //Sets spriteRenderer var back to original color
    }

    //Function that manages what to do when gameobject dies
    public abstract void DieAnimation();
    //Method that is called after animation has played
    public abstract void Dying();
    //Method that detects when we get hit
    
}

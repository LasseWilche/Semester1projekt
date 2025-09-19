using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyHealthManager : MonoBehaviour
{
    public int maxHealth;                           //Max health var that can be set in inspector
    private int currentHealth;                      //Current health var that's set to maxHealth at start
    private SpriteRenderer spriteRenderer;          //Var that pulls the sprite renderer from enemy to manipulate it
    private Color ogcolor;                          //Var that pulls original color to manipulate it later

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        ogcolor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.isPressed)    //Temp solution to test if damage function works and if gameobject dies when helath hits 0 and is destrotyed
        {
            TakeDamage(1);
        }
    }

    //Function that manages health when gameobject takes dmg
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;                    //Applies dmg value to currentHealth
        StartCoroutine(flashWhite());               //Refrences flashWhite function
        if (currentHealth <= 0)                     //Refrences Die function if currentHealth reaches 0 or less
        {
            Die();
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
    void Die()
    {
        Destroy(gameObject);                        //Destorys gameobject when function runs
    }
}

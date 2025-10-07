using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHealthManager : MonoBehaviour
{
    public int playerMaxHealth;         //Max health var for player
    public int playerCurrenthHealth;    //Current health var for platyer

    public HealthBar healthBar;         //Need to have access to HelathBar UI object

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCurrenthHealth = playerMaxHealth;     //Sets current health to max on start
        healthBar.SetMaxHealth(playerMaxHealth);    //Sets UI healthbar to max on start

    }

    // Update is called once per frame
    void Update()
    {
        //Test tool to see if healthbar works
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            TakeDamage(1);
        }
    }

    //Damage function that damages the player and manipulates health var and healthbar UI
    public void TakeDamage(int damage)
    {
        playerCurrenthHealth -= damage;             //Modifies current health var

        healthBar.SetHealth(playerCurrenthHealth);  //Modifies health bar UI
    }
}

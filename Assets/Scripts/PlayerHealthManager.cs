using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHealthManager : MonoBehaviour
{
    public int playerMaxHealth;
    int playerCurrenthHealth;

    public HealthBar healthBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCurrenthHealth = playerMaxHealth;
        healthBar.SetMaxHealth(playerMaxHealth);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            TakeDamage(1);
        }
    }

    void TakeDamage(int damage)
    {
        playerCurrenthHealth -= damage;
        healthBar.SetHealth(playerCurrenthHealth);
        
    }
}

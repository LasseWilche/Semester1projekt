using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHealthManager : HealthManager
{
    public HealthBar healthBar;         //Need to have access to HelathBar UI object

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();
        healthBar.SetMaxHealth(maxHealth);    //Sets UI healthbar to max on start
    }
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        healthBar.SetHealth(currentHealth);  //Modifies health bar UI
    }
    public override void DieAnimation()
    {
        animator.Play("Dying");
        Invoke("Dying", 3f); //insert length of dying animation
    }
    public override void Dying()
    {
        if (gameManager.bothAlive == true) gameManager.bothAlive = false; //End the game;
        else gameManager.GameOver();
        Destroy(gameObject);
    }
}

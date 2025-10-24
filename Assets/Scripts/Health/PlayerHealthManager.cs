using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerHealthManager : HealthManager
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
    public override void OnCollisionEnter2D(Collision2D collision)
    { //Take damage if hit by enemy or enemy bullet
        if (collision.gameObject.CompareTag("EnemyBullet") || collision.gameObject.CompareTag("Enemy")) TakeDamage(1);
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

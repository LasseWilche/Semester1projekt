using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerHealthManager : HealthManager
{
    [SerializeField] NewP2ShootScript player2;
    [SerializeField] P2ControllerWithRotationThatDidntWorkLol shootScript;
    [SerializeField] Meleescript melee;
    [SerializeField] P1Controller player1;
    [SerializeField] Image[] Health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();
        //healthBar.SetMaxHealth(maxHealth);    //Sets UI healthbar to max on start
    }
    public override void TakeDamage(int damage)
    {
        if (damage <= 0) return;
        if (currentHealth <= 0) return;

        base.TakeDamage(damage);
        //healthBar.SetHealth(currentHealth);  //Modifies health bar UI
        Health[currentHealth].gameObject.SetActive(false);
    }
    public override void DieAnimation()
    {
        if (player1 != null)
        {
            melee.Die();
            player1.Die();
        }
        else if (player2 != null)
        {
            player2.Die();
            shootScript.Die();
        }
        //animator.Play("Dying");
        Invoke("Dying", 3f); //insert length of dying animation
    }
    public override void Dying()
    {
        if (gameManager.bothAlive == true) gameManager.bothAlive = false; //End the game;
        else gameManager.GameOver();
        Destroy(gameObject);
    }
}

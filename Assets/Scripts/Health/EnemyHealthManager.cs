using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyHealthManager : HealthManager
{
    private void Awake()
    {
        currentHealth = Mathf.Max(1, maxHealth);
    }

    // KALDES fra Meleescript.OnTriggerEnter2D: enemy.TakeDamage(1);
    public override void TakeDamage(int amount)
    {
        if (currentHealth <= 0) return;

        currentHealth -= Mathf.Max(0, amount);
        if (currentHealth <= 0)
        {
            DieAnimation();
        }
    }

    public override void DieAnimation()
    {
        if (animator) animator.Play("Dying");
        Invoke(nameof(Dying), 3f); // længden af din døds-animation
    }

    public override void Dying()
    {
        Destroy(gameObject);
    }
}

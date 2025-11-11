using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyHealthManager : HealthManager
{
    // KALDES fra Meleescript.OnTriggerEnter2D: enemy.TakeDamage(1);
    // Kalder fra bullet script
    public override void TakeDamage(int amount)
    {
        if (amount <= 0) return;
        {

        }
        if (currentHealth <= 0) return;

        currentHealth -= Mathf.Max(0, amount);
        if (currentHealth <= 0)
        {
            StartCoroutine(GetComponentInChildren<EnemyBaseClass>().Death());
        }
    }

    public override void DieAnimation()
    {
        if (animator) animator.Play("Dying");
        Invoke(nameof(Dying), 0.5f); // længden af din døds-animation
    }

    public override void Dying()
    {
        Destroy(gameObject);
    }
}

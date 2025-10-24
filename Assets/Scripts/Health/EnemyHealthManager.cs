using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyHealthManager : HealthManager
{
    public override void OnCollisionEnter2D(Collision2D collision)
    { //Take damage if hit by player melee or bullet
        if (collision.gameObject.CompareTag("PlayerBullet") || collision.gameObject.CompareTag("PlayerMelee")) TakeDamage(1);
    }
    public override void DieAnimation()
    {
        animator.Play("Dying");
        //insert charge function
        Invoke("Dying", 3f); //insert length of dying animation
    }
    public override void Dying()
    {
        Destroy(gameObject);
    }
}

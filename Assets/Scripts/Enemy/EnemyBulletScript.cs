using UnityEngine;
public class EnemyBulletScript : BasicBulletScript
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealthManager playerHealthManager = collision.GetComponent<PlayerHealthManager>();
            playerHealthManager.TakeDamage(1);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Wall")) Destroy(this.gameObject);
    }
}

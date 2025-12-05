using UnityEngine;
public class EnemyBulletScript : BasicBulletScript
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("hit");
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealthManager>().TakeDamage(1);
            Destroy(this.gameObject);

        }
        else if (collision.gameObject.CompareTag("Wall")) Destroy(this.gameObject);
    }
}

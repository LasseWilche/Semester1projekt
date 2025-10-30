using UnityEngine;

public class PlayerBulletScript : BasicBulletScript
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Enemy")) Destroy(this.gameObject);
    }
}

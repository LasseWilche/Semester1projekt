using UnityEngine;

public class PlayerBulletScript : BasicBulletScript
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            Debug.Log("Enemy hit"); //if a enemy is hit we destroy the bullet
        else if (collision.gameObject.CompareTag("Player") ||
            collision.gameObject.CompareTag("Bullet")) return; //if trigger collides with player or bullet, we dont destroy
        Destroy(this.gameObject); //we hit something that is not a player or a bullet, so we get destroyed
    }
}

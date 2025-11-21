using UnityEngine;

public class ShieldBehaviour : MonoBehaviour
{
    private int shieldHP;
    private EnemyShieldManager manager;
    private GameObject enemyObject;

    public void Initialize(int hp, float opacity, float animSpeed, GameObject enemyObj)
    {
        shieldHP = hp;
        enemyObject = enemyObj;
        manager = enemyObj.GetComponent<EnemyShieldManager>();

        // Set opacity
        var sprite = GetComponent<SpriteRenderer>();
        Color c = sprite.color;
        c.a = opacity;
        sprite.color = c;

        // Animation speed
        var animator = GetComponent<Animator>();
        animator.speed = animSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Player projectiles should have tag "PlayerBullet"
        if (!collision.CompareTag("PlayerBullet"))
            return;

        shieldHP--;

        if (shieldHP <= 0)
        {
            // tell manager the shield is broken
            if (manager != null)
                manager.ShieldDestroyed();

            Destroy(this.gameObject);
        }
    }
}

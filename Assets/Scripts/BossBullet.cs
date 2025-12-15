using UnityEngine;

public class BossBullet : MonoBehaviour
{
    private float speed;
    private Vector2 direction;
    private Collider2D myCollider;

    void Start()
    {
        myCollider = GetComponent<Collider2D>();
    }

    public void Initialize(float bulletSpeed, Vector2 bulletDirection)
    {
        speed = bulletSpeed;
        direction = bulletDirection;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            var otherCol = collision.collider;
            if (myCollider != null && otherCol != null)
            {
                Physics2D.IgnoreCollision(myCollider, otherCol);
            } 
        }
    }
}

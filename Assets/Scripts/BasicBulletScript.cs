using Unity.VisualScripting;
using UnityEngine;

public abstract class BasicBulletScript : MonoBehaviour
{
    Rigidbody2D myrb;
    public float bulletSpeed;

    public BasicBulletScript()
    {
        myrb = null;
        bulletSpeed = 0.8f;
    }
    void Start()
    {
        myrb = GetComponent<Rigidbody2D>();
        myrb.gravityScale = 0;
        myrb.interpolation = RigidbodyInterpolation2D.Interpolate;
        SetStartVelocity();
    }
    void SetStartVelocity()
    {
        myrb.linearVelocity = transform.right * bulletSpeed;
    }
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
            Debug.Log("Player hit"); //if a player is hit we destroy the bullet
        else if (collision.gameObject.CompareTag("Enemy")|| 
            collision.gameObject.CompareTag("Bullet")) return; //if trigger collides with enemy or bullet, we dont destroy
        Destroy(this.gameObject); //we hit something that is not an enemy or a bullet, so we get destroyed
    }
}

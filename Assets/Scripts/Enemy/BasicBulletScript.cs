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
}

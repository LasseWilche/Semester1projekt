using Unity.VisualScripting;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    Rigidbody2D myrb;
    public float bulletSpeed = 0.8f;

    private void Start()
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

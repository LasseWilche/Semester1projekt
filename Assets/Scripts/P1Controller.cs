using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class P1Controller : MonoBehaviour

{
    public Rigidbody2D rb2d;
    public float moveSpeed;

    void Start()
    {

    }

    void Update()
    {
        p1Movement();
    
    }

    private void p1Movement()
    {
        Vector3 move = Vector3.zero;

        if (Keyboard.current.upArrowKey.isPressed)
        {
            rb2d.AddForce(Vector2.up * moveSpeed);
        }
        if (Keyboard.current.downArrowKey.isPressed)
        {
            rb2d.AddForce(Vector2.down * moveSpeed);
        }
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            rb2d.AddForce(Vector2.left * moveSpeed);
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            rb2d.AddForce(Vector2.right * moveSpeed);
        }
        move.Normalize();
        rb2d.linearVelocity = move * moveSpeed;
    }
}
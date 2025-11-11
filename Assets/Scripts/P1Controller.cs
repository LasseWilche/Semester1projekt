using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class P1Controller : MonoBehaviour

{
    public Rigidbody2D rb2d;
    public float moveSpeed = 10f;

    void Start()
    {

    }

    void Update()
    {
        p1Movement();
     /*   Vector3 move = Vector3.zero;

        if (Keyboard.current.iKey.isPressed)
            move += Vector3.up;
        if (Keyboard.current.jKey.isPressed)
            move += Vector3.left;
        if (Keyboard.current.kKey.isPressed)
            move += Vector3.down;
        if (Keyboard.current.lKey.isPressed)
            move += Vector3.right;

        if (move != Vector3.zero)
        {
            move.Normalize();
            rb2d.linearVelocity = move * moveSpeed * Time.deltaTime;
        }*/
    }

    private void p1Movement()
    {
        Vector3 move = Vector3.zero;

        if (Keyboard.current.iKey.isPressed)
        {
            rb2d.AddForce(Vector2.up * moveSpeed);
        }
        if (Keyboard.current.kKey.isPressed)
        {
            rb2d.AddForce(Vector2.down * moveSpeed);
        }
        if (Keyboard.current.jKey.isPressed)
        {
            rb2d.AddForce(Vector2.left * moveSpeed);
        }
        if (Keyboard.current.lKey.isPressed)
        {
            rb2d.AddForce(Vector2.right * moveSpeed);
        }
        move.Normalize();
        rb2d.linearVelocity = move * moveSpeed;
    }
}
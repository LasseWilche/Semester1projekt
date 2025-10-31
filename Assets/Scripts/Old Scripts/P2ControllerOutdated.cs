using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class P2Controller : MonoBehaviour
{
    /*  GENERAL  */
    public float moveSpeed;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;

    /*  STUFF FOR DASHING  */
    private float activeMoveSpeed;
    public float dashSpeed;
    public float dashDuration = 0.15f;
    public float dashCooldown = 1f;
    private float dashCounter;
    private float dashCoolCounter;

    /*  STUFF FOR ROTATION  */
    [SerializeField]
    private float rotationSpeed;
    private Vector2 movementInput;
    private Vector2 smoothedMovementInput;
    private Vector2 movementInputSmoothVelocity;

    void Start()
    {
        activeMoveSpeed = moveSpeed;
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovementMethod();
        FuckingRotationMethod();
    }

    private void FuckingRotationMethod()
    {
        /* Guys, please don't make fun of the genius code below */

        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.D))
                rb2d.MoveRotation(45);

            else if (Input.GetKey(KeyCode.A))
                rb2d.MoveRotation(135);

            else
                rb2d.MoveRotation(90);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.S))
                rb2d.MoveRotation(-135);

            else if (Input.GetKey(KeyCode.W))
                rb2d.MoveRotation(135);

            else
                rb2d.MoveRotation(180);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.A))
                rb2d.MoveRotation(-135);

            else if (Input.GetKey(KeyCode.D))
                rb2d.MoveRotation(-45);

            else
                rb2d.MoveRotation(-90);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.W))
                rb2d.MoveRotation(45);

            else if (Input.GetKey(KeyCode.S))
                rb2d.MoveRotation(-45);

            else
                rb2d.MoveRotation(0);
        }
    }

    private void FixedUpdate()
    {

    }

    private void MovementMethod()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        rb2d.linearVelocity = moveInput * activeMoveSpeed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashDuration;
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }

    }
    


}

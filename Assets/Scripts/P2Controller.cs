using System.Collections;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

public class P2ControllerWithRotationThatDidntWorkLol : MonoBehaviour
{
    /*  GENERAL  */
    public float moveSpeed;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;
    bool alive = true;

    /*  STUFF FOR DASHING  */
    private float activeMoveSpeed;
    public float dashSpeed;
    public float dashDuration = 0.15f;
    public float dashCooldown = 1f;
    private float dashCounter;
    private float dashCoolCounter;

    /*  STUFF FOR ROTATION  */
    [SerializeField] private float rotationSpeed;
    [SerializeField] P2SpriteFix SpaghetteFix;



    void Start()
    {
        activeMoveSpeed = moveSpeed;
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (alive) MovementMethod();
    }

    private void FixedUpdate()
    {
        if (alive) RotationMethod();
    }

    private void MovementMethod()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        rb2d.linearVelocity = moveInput * activeMoveSpeed;

        if (Input.GetKeyDown(KeyCode.T))
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

    private void RotationMethod()
    {
        if (moveInput != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, moveInput);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            rb2d.MoveRotation(rotation);
        }
    }

    public void Die()
    {
        alive = false;
        rb2d.linearVelocity = Vector2.zero;
        SpaghetteFix.alive = false;
    }
}

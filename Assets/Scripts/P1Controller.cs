using Unity.VisualScripting;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class P1Controller : MonoBehaviour

{
    public Rigidbody2D rb2d;
    public float moveSpeed;
    public Animator moveAnim;
    private Vector3 move = Vector3.zero;
    bool alive = true;

    void Start()
    {
        moveAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (alive) p1Movement();
    }

    private void p1Movement()
    {
        if (Keyboard.current.upArrowKey.isPressed)
        {
            rb2d.AddForce(Vector2.up * moveSpeed);
            moveAnim.SetBool("isWalking", true);
            moveAnim.SetFloat("InputX", 0);
            moveAnim.SetFloat("InputY", 1);
        } else if (Keyboard.current.upArrowKey.wasReleasedThisFrame)
            {
                moveAnim.SetBool("isWalking", false);
                moveAnim.SetFloat("LastInputX", 0);
                moveAnim.SetFloat("LastInputY", 1);
            }

        if (Keyboard.current.downArrowKey.isPressed)
        {
            rb2d.AddForce(Vector2.down * moveSpeed);
            moveAnim.SetBool("isWalking", true);
            moveAnim.SetFloat("InputX", 0);
            moveAnim.SetFloat("InputY", -1);
        } else if (Keyboard.current.downArrowKey.wasReleasedThisFrame)
            {
                moveAnim.SetBool("isWalking", false);
                moveAnim.SetFloat("LastInputX", 0);
                moveAnim.SetFloat("LastInputY", -1);
            }
        
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            rb2d.AddForce(Vector2.left * moveSpeed);
            moveAnim.SetBool("isWalking", true);
            moveAnim.SetFloat("InputX", -1);
            moveAnim.SetFloat("InputY", 0);
        } else if (Keyboard.current.leftArrowKey.wasReleasedThisFrame)
            {
                moveAnim.SetBool("isWalking", false);
                moveAnim.SetFloat("LastInputX", -1);
                moveAnim.SetFloat("LastInputY", 0);
            }
        
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            rb2d.AddForce(Vector2.right * moveSpeed);
            moveAnim.SetBool("isWalking", true);
            moveAnim.SetFloat("InputX", 1);
            moveAnim.SetFloat("InputY", 0);
        } else if (Keyboard.current.rightArrowKey.wasReleasedThisFrame)
            { 
                Debug.Log("Right key released");
                moveAnim.SetBool("isWalking", false);
                moveAnim.SetFloat("LastInputX", 1);
                moveAnim.SetFloat("LastInputY", 0);
            }
        
        if (Keyboard.current.upArrowKey.isPressed && Keyboard.current.leftArrowKey.isPressed)
        {
            moveAnim.SetBool("isWalking", true);
            moveAnim.SetFloat("InputX", -1);
            moveAnim.SetFloat("InputY", 1);
        } else if (Keyboard.current.upArrowKey.wasReleasedThisFrame && Keyboard.current.leftArrowKey.wasReleasedThisFrame)
            {
                moveAnim.SetBool("isWalking", false);
                moveAnim.SetFloat("LastInputX", -1);
                moveAnim.SetFloat("LastInputY", 1);
            }
        
        if (Keyboard.current.upArrowKey.isPressed && Keyboard.current.rightArrowKey.isPressed)
        {
            moveAnim.SetBool("isWalking", true);
            moveAnim.SetFloat("InputX", 1);
            moveAnim.SetFloat("InputY", 1);
        } else if (Keyboard.current.upArrowKey.wasReleasedThisFrame && Keyboard.current.rightArrowKey.wasReleasedThisFrame)
            {
                moveAnim.SetBool("isWalking", false);
                moveAnim.SetFloat("LastInputX", 1);
                moveAnim.SetFloat("LastInputY", 1);
            }
        
        move.Normalize();
        rb2d.linearVelocity = move * moveSpeed;
    }
    public void Die()
    {
        alive = false;
    }
}
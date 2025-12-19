using UnityEngine;
using UnityEngine.InputSystem;

public class P2SpriteFix : MonoBehaviour
{
    [SerializeField] GameObject gameObjectShoot;
    private Vector2 moveInput;
    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = gameObjectShoot.transform.position;
        SpriteMovementMethod(new InputAction.CallbackContext());
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
    }

    private void SpriteMovementMethod(InputAction.CallbackContext Context)
    {
        if (moveInput != Vector2.zero)
        {
            animator.SetBool("isWalking", true);
            animator.SetFloat("InputX", moveInput.x);
            animator.SetFloat("InputY", moveInput.y);
        } else if (moveInput == Vector2.zero)
        {
            animator.SetBool("isWalking", false);
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);
        }
    }
}

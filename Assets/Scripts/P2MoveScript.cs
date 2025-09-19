using UnityEngine;
using UnityEngine.InputSystem;

public class P2MoveScript : MonoBehaviour

{

    public float moveSpeed = 10f; // Adds a public value of 10 forces to the variable moveSpeed

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = Vector3.zero;

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
            transform.position += move * moveSpeed * Time.deltaTime;
        }
    }
}

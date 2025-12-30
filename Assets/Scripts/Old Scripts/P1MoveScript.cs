using UnityEngine;
using UnityEngine.InputSystem;

public class P1MoveScript : MonoBehaviour

{
    public float moveSpeed = 10f; // Adds a public value of 10 forces to the variable moveSpeed


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow)) // Assigns a key press to any one cardinal direction of movement
            move += Vector3.up;
        if (Input.GetKey(KeyCode.LeftArrow))
            move += Vector3.left;
        if (Input.GetKey(KeyCode.DownArrow))
            move += Vector3.down;
        if (Input.GetKey(KeyCode.RightArrow))
            move += Vector3.right;

        if (move != Vector3.zero) // Checks if the vector does not have a value of (0, 0, 0), so if a button is pressed.
        {
            move.Normalize(); // Normalize makes the character move at the same speed both horizontally, vertically and diagonally
            transform.position += move * moveSpeed * Time.deltaTime; // the math
        }
    }
}

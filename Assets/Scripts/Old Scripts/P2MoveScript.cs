using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class P2MoveScript : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Start()
    {

    }

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






/*
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
        */

using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class P2Sebtroller : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;

    private float activeMoveSpeed;
    public float dashSpeed;

    public float dashDuration = 0.15f;
    public float dashCooldown = 1f;

    private float dashCounter;
    private float dashCoolCounter;
    private Quaternion rotationvl;
    public bool angled;
    void Start()
    {
        activeMoveSpeed = moveSpeed;
        rotationvl = transform.rotation;
        angled = false;
    }

    void Update()
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


        /* Guys, please don't make fun of the genius code below */


        if (angled == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (Input.GetKey(KeyCode.D))
                    StartCoroutine(PlayerRotator2(45, KeyCode.W, KeyCode.D));

                else if (Input.GetKey(KeyCode.A))
                    StartCoroutine(PlayerRotator2(135, KeyCode.W, KeyCode.A));

                else
                    PlayerRotator1(KeyCode.W);
            }

            else if (Input.GetKey(KeyCode.A))
            {
                if (Input.GetKey(KeyCode.S))
                    StartCoroutine(PlayerRotator2(-135, KeyCode.A, KeyCode.S));

                else
                    PlayerRotator1(KeyCode.A);
            }

            else if (Input.GetKey(KeyCode.S))
            {
                if (Input.GetKey(KeyCode.D))
                    StartCoroutine(PlayerRotator2(-45, KeyCode.S, KeyCode.D));

                else
                    PlayerRotator1(KeyCode.S);
            }

            else if (Input.GetKey(KeyCode.D))
            {
                    PlayerRotator1(KeyCode.D);
            }
        }
    }
    void PlayerRotator1(KeyCode key)
    {
        if (key == KeyCode.W) rb2d.MoveRotation(90);            //rotate up
        else if (key == KeyCode.S) rb2d.MoveRotation(-90);      //rotate down
        else if (key == KeyCode.A) rb2d.MoveRotation(180);      //rotate left
        else rb2d.MoveRotation(0);                              //rotate right
    }
    IEnumerator PlayerRotator2(int rotation, KeyCode key1, KeyCode key2)
    {
        angled = true;                                                  //we turn off angled, now we cant rotate from update
        rb2d.MoveRotation(rotation);                                    //we do our initial rotation

        while (Input.GetKey(key1) && Input.GetKey(key2))                //if both keys are pressed we loop
        {
            /*
            if (Input.GetKey(key1) == false || Input.GetKey(key2) == false)
            {
                Debug.Log("Key Let go");
                yield return new WaitForSeconds(0.05f);
                if (Input.GetKey(key1) == false && Input.GetKey(key2) == false)
                {
                    Debug.Log("Stopping at angle");
                    angled = false;
                    rb2d.MoveRotation(rotation);
                }
                else if (Input.GetKey(key1) == false)
                {
                    PlayerRotator1(key2);
                    angled = false;
                }
                else if (Input.GetKey(key2) == false)
                {
                    PlayerRotator1(key1);
                    angled = false;
                }
                break;
            }*/
            yield return new WaitForSeconds(.01f);
        }
        if (Input.GetKey(key1) == false && Input.GetKey(key2) == false) //if both keys are let go we rotate to initial angle, and disabled angled
        {
            angled = false;
            rb2d.MoveRotation(rotation);
        }
        else if (Input.GetKey(key1) == false)                           //if only 1 key is let go, we call PlayerRotate1 with the other key, and disable angled
        {
            PlayerRotator1(key2);
            angled = false;
        }
        else if (Input.GetKey(key2) == false)
        {
            PlayerRotator1(key1);
            angled = false;
        }
    }
}
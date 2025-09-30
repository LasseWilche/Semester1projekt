using System;
using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class EnemyAI : MonoBehaviour
{
    public Rigidbody myrigidbody;                   //makes a public rigidbody variable
    public float startSpeed, movementSpeed;         //makes a public startSpeed variable //makes a public movementSpeed variable
    Transform finalTarget;                          //makes a transform variable which gives us our target
    Vector3 angle;                                  //makes a vector3 variable to describe an angle
    GameObject p1, p2;                  //gets player1 as a variable      //gets player2 as a variable
    public double distance = 0, distanceOffset = 0.2; //sets distance and distanceOffset
    public bool still = false;                      //makes a public bool, if true enemy stands still

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movementSpeed = startSpeed;                 //sets our current movement speed as our start movement speed
        myrigidbody = GetComponent<Rigidbody>();    //sets our rigidbody
        myrigidbody.useGravity = false;             //turns off gravity for our rigidbody
        myrigidbody.freezeRotation = true;          //freezes rotation of enemy
        p1 = GameObject.Find("Player1");            //sets player1 as p1
        p2 = GameObject.Find("Player2");            //setes player2 as p2
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) MoveEnemy();
        if (!still)
        {
            if (Vector2.Distance(p1.transform.position, myrigidbody.transform.position) <
                Vector2.Distance(p2.transform.position, myrigidbody.transform.position)) //finds the closest player
            {
                finalTarget = p1.transform;     //if p1 is closest, our target is p1
            }
            else
            {
                finalTarget = p2.transform;     //if p2 is closest, our target is p2
            }
            
            angle = finalTarget.position - myrigidbody.transform.position;  //finds the difference between our position, and the target position
            angle.Normalize();      //normalizes the angle (makes it into a 1vector)
            
            if (distance+distanceOffset > Vector2.Distance(finalTarget.position, myrigidbody.transform.position) && Vector2.Distance(finalTarget.position, myrigidbody.transform.position) > distance - distanceOffset)
            {
                still = true;           //stops enemy if they are within the offset distance
            }
            else if (distance > Vector2.Distance(finalTarget.position, myrigidbody.transform.position))
            {
                myrigidbody.transform.position -= (angle * movementSpeed * Time.deltaTime);         //moves enemy away from target
            }
            else
            {
                myrigidbody.transform.position += (angle * movementSpeed * Time.deltaTime);        //moves enemy towards target
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //If enemy comes into contact with a player, they know
        if (collision.gameObject.CompareTag("Player")) Debug.Log("They hit the second tower");
    }
    public void MoveEnemy()      //If Called, enemy moves again. Should attack before this is called
    {
        still = false;
    }
}

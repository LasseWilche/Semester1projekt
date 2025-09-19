using Unity.Hierarchy;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyAI : MonoBehaviour
{
    public Rigidbody myrigidbody;
    public float startSpeed;
    public float movementSpeed;
    Transform finalTarget;
    Transform player1;
    Transform player2;
    Vector3 angle;
    GameObject p1;
    GameObject p2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movementSpeed = startSpeed;
        myrigidbody = GetComponent<Rigidbody>();
        myrigidbody.useGravity = false;
        p1 = GameObject.Find("Player1");
        if (p1 != null)
        {
            player1 = p1.transform;
            Debug.Log("Player1 found!");
        }
        p2 = GameObject.Find("Player2");
        if (p2 != null)
        {
            player2 = p2.transform;
            Debug.Log("Player2 found!");
        }
    }

    void Update()
    {

        if (Vector2.Distance(player1.position, myrigidbody.transform.position) <
            Vector2.Distance(player2.position, myrigidbody.transform.position))
        {
            finalTarget = player1;
        }
        else
        {
            finalTarget = player2;
        }
        angle = finalTarget.position - myrigidbody.transform.position;
        angle.Normalize();
        transform.position += movementSpeed * angle * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == p1 || p2){
            // Damage chosen player if enemy unable to attack
            //if enemy attacked, disable attack for x amount of time
            //temporarily we just add force in opposite direction
            Debug.Log("Owch!");
            movementSpeed = 0;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == p1 || p2) {
            Debug.Log("No Longer Colliding");
            movementSpeed = startSpeed;
        }
    }
}

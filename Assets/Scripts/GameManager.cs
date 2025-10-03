using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public class Enemy : MonoBehaviour 
    {
        readonly GameObject p1, p2;                  //gets player1 as a variable      //gets player2 as a variable      
        public float startSpeed, movementSpeed;         //makes a public startSpeed variable //makes a public movementSpeed variable
        public int life;                                //makes a public int with life
        Transform target;                               //gest a target transform as a variable
        Vector3 angle;                                  //makes a angle for movement
        public Rigidbody myrigidbody;                   //rigidbody we are going to move
        public float cooldown, startCooldown;

        public Enemy()
        {
            p1 = GameObject.Find("Player1");            //sets player1 as p1
            p2 = GameObject.Find("Player2");            //setes player2 as p2
            startSpeed = 5;
            movementSpeed = startSpeed;
            life = 3;
            target = gameObject.transform;
            angle = new Vector3(0, 0, 0);
            myrigidbody = GetComponent<Rigidbody>();
            cooldown = 0;
            startCooldown = 3;
        }

        public virtual void Update()
        {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0) MovementScript();
        }
        public virtual void MovementScript()
        {
            if (Vector2.Distance(p1.transform.position, myrigidbody.transform.position) <
                Vector2.Distance(p2.transform.position, myrigidbody.transform.position)) //finds the closest player
            {
                target = p1.transform;     //if p1 is closest, our target is p1
            }
            else
            {
                target = p2.transform;     //if p2 is closest, our target is p2
            }
            angle = target.position - myrigidbody.transform.position;  //finds the difference between our position, and the target position
            angle.Normalize();      //normalizes the angle (makes it into a 1vector)
            myrigidbody.transform.position -= (movementSpeed * Time.deltaTime * angle);
        }
        public virtual void AttackScript()
        {
            Debug.Log("Im attacking rawr");
        }
        public void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                AttackScript();
                cooldown = startCooldown;
            }
        }
        /*
        public void Death()
        {
            GameObject.Find("Crystal").GetComponent<>("Crystal Script").CurrentCharge();
        }
        */
    }
}

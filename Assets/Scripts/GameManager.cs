using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{
    public virtual void Start()
    {

    }
    public virtual void Update()
    {
        
    }
    public class Enemy : GameManager
    {
        public GameObject p1, p2;                  //gets player1 as a variable      //gets player2 as a variable      
        public float startSpeed, movementSpeed;         //makes a public startSpeed variable //makes a public movementSpeed variable
        public int life;                                //makes a public int with life
        public Transform target;                               //gest a target transform as a variable
        public Vector3 angle;                                  //makes a angle for movement
        public float cooldown, startCooldown;

        public Enemy()
        {
            
            p1 = null;            //sets player1 as p1
            p2 = null;            //sets player2 as p2
            startSpeed = 5;
            movementSpeed = startSpeed;
            life = 3;
            target = null;
            angle = new Vector3(0, 0, 0);
            cooldown = 0;
            startCooldown = 3;
        }
        public override void Start()
        {
            p1 = GameObject.Find("Player1");
            p2 = GameObject.Find("Player2");
        }
        public override void Update()
        {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0) MovementScript();
        }
        public virtual void MovementScript()
        {
            Debug.Log("On The Move");
        }
        public virtual void AttackScript(Collision collision)
        {
            Debug.Log("Im attacking" + collision.gameObject);
        }
        public void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                AttackScript(collision);
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

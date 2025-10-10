using UnityEngine;

public class EnemyBaseClass : MonoBehaviour
{
    public GameObject p1, p2;                  //gets player1 as a variable      //gets player2 as a variable      
    public float startSpeed, movementSpeed;         //makes a public startSpeed variable //makes a public movementSpeed variable
    public int life;                                //makes a public int with life
    public Transform target;                               //gest a target transform as a variable
    public Vector3 angle;                                  //makes a angle for movement
    public float cooldown;
    public Rigidbody myrb;

    public EnemyBaseClass()
    {

        p1 = null;            //sets player1 as p1
        p2 = null;            //sets player2 as p2
        startSpeed = 5;
        movementSpeed = startSpeed;
        life = 3;
        target = null;
        angle = new Vector3(0, 0, 0);
        cooldown = 0;
        myrb = null;
    }
    void Start()
    {
        p1 = GameObject.Find("Player1");
        p2 = GameObject.Find("Player2");
        myrb = GetComponent<Rigidbody>();
        myrb.useGravity = false;
        myrb.freezeRotation= true;
        Debug.Log("Constructed");
    }
    private void Update()
    {
        if (cooldown <= 0)
        {
            MovementScript();
        }
        else cooldown -= Time.deltaTime;
    }
    public virtual void MovementScript()
    {
        Debug.Log("On The Move");
    }
    public virtual void AttackScript(Collision collision)
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AttackScript(collision);
            cooldown = 3;
        }
    }
    //Damage function under EnemyHealthManager
    /*public void Death()
    {
        GameObject.Find("Crystal").GetComponent<>("Crystal Script").CurrentCharge();
    }*/
    
}

public class EnemyBaseRanged : EnemyBaseClass
{

}
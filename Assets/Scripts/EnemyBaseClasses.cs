using JetBrains.Annotations;
using System.Transactions;
using UnityEngine;
using System;
public class EnemyBaseRanged : EnemyBaseClass
{
    public int damage;
    public int bullets;
    public double range;
    public double spread;
    static double rangeOffset = 0.25;
    public GameObject bulletType = null;
    public GameObject shootingAngle = null;

    public EnemyBaseRanged(int damage = 1, int bullets = 1, double range = 10.0, double spread = 5.0)
    {
        this.damage = damage;
        this.bullets = bullets;
        this.range = range;
        this.spread = spread;
    }
    public virtual void Shoot(int damage, double spread)
    {
        Debug.Log("pew im shooting at a degree of " + spread);
        //sets the shooting angle towards target angle
        shootingAngle.transform.right = angle;
        //changes the shooting angle by spread amount
        shootingAngle.transform.rotation *= Quaternion.Euler(0,0,(float)spread);
        Debug.Log(shootingAngle.transform.rotation);
        //Instantiates bullet at this position, with the rotation of the shooting angle
        Instantiate(bulletType, this.transform.position, shootingAngle.transform.rotation);
    }
    public override void AttackScript(Collision collision)
    {
        cooldown = 2;
        if (bullets % 2 == 0) //if even number of bullets, every bullet has a spread
        {
            double bulletAngle = spread / bullets * 2;
            for (int i = 1; i < bullets + 1; i++) //every second bullet increments angle
            {
                if (i % 2 == 0) Shoot(damage, -Math.Ceiling((double)i / 2) * bulletAngle); //every second is negative
                if (i % 2 == 1) Shoot(damage, Math.Ceiling((double)i / 2) * bulletAngle);  //every second is positive
            }
        }
        else //if odd number of bullets, first bullet goes at no spread
        {
            double bulletAngle = spread / (bullets - 1) * 2;
            for (int i = 0; i < bullets; i++) //every second bullet increments angle
            {
                if (i == 0) Shoot(damage, 0);
                else
                {
                    if (i % 2 == 0) Shoot(damage, -Math.Ceiling((double)i / 2) * bulletAngle); //every second is negative
                    if (i % 2 == 1) Shoot(damage, Math.Ceiling((double)i / 2) * bulletAngle);  //every second is positive
                }
            }

        }
    }
    public override void MovementScript()
    {

        angle = target.position - myrb.transform.position;  //finds the difference between our position, and the target position
        angle.Normalize();      //normalizes the angle (makes it into a 1vector)
        if ((Vector2.Distance(target.position, myrb.transform.position) < rangeOffset + range) &&   //If enemy is within range+offset
            Vector2.Distance(target.position, myrb.transform.position) > range)                     //And is further than range from target
            AttackScript(null);                                         //Then enemy attacks
        if (Vector2.Distance(target.position, myrb.transform.position) >= range + rangeOffset) //moves towards range + offset of .25 if too far from player
        {
            myrb.transform.position += (movementSpeed * Time.deltaTime * angle); 
        }
        else if (Vector2.Distance(target.position, myrb.transform.position) <= range) //moves towards range if too close to player
        {
            myrb.transform.position -= (movementSpeed * Time.deltaTime * angle);
        }
    }
}
public class EnemyBaseClass : MonoBehaviour
{
    public GameObject p1, p2;                  //gets player1 as a variable      //gets player2 as a variable      
    public float movementSpeed;         //makes a public startSpeed variable //makes a public movementSpeed variable
    public int life;                                //makes a public int with life
    public Transform target;                               //gest a target transform as a variable
    public Vector3 angle;                                  //makes a angle for movement
    public float cooldown;
    public Rigidbody myrb;

    public EnemyBaseClass()
    {

        p1 = null;            //sets player1 as p1
        p2 = null;            //sets player2 as p2
        movementSpeed = 5;
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
            if (Vector2.Distance(p1.transform.position, myrb.transform.position) <
                Vector2.Distance(p2.transform.position, myrb.transform.position)) //finds the closest player
            {
                target = p1.transform;     //if p1 is closest, our target is p1
            }
            else
            {
                target = p2.transform;     //if p2 is closest, our target is p2
            }
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
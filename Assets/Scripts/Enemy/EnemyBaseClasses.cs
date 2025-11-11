using JetBrains.Annotations;
using System.Transactions;
using UnityEngine;
using System;
using System.Collections;
public abstract class EnemyBaseRanged : EnemyBaseClass
{
    public int bullets;
    public double range;
    public double spread;
    static double rangeOffset = 0.25;
    public GameObject bulletType = null;
    public GameObject shootingAngle = null;

    public EnemyBaseRanged(int bullets = 1, double range = 10.0, double spread = 5.0)
    {
        this.bullets = bullets;
        this.range = range;
        this.spread = spread;
    }
    private void Awake()
    {
        shootingAngle = this.transform.Find("ShootingAngle").gameObject; 
        //we have manually inserted a empty game object to help us aim
    }
    public virtual void Shoot(double spread)
    {
        //sets the shooting angle towards target angle
        shootingAngle.transform.right = angle;
        //changes the shooting angle by spread amount
        shootingAngle.transform.rotation *= Quaternion.Euler(0,0,(float)spread);
        //Instantiates bullet at this position, with the rotation of the shooting angle
        Instantiate(bulletType, this.transform.position, shootingAngle.transform.rotation);
    }
    public override IEnumerator AttackScript(Collision collision)
    {
        animator.Play("Shooting");
        cooldown = 2;
        yield return new WaitForSeconds(0.5f);
        
        if (bullets % 2 == 0) //if even number of bullets, every bullet has a spread
        {
            double bulletAngle = spread / bullets * 2;
            for (int i = 1; i < bullets + 1; i++) //every second bullet increments angle
            {
                if (i % 2 == 0) Shoot(-Math.Ceiling((double)i / 2) * bulletAngle); //every second is negative
                if (i % 2 == 1) Shoot(Math.Ceiling((double)i / 2) * bulletAngle);  //every second is positive
            }
        }
        else //if odd number of bullets, first bullet goes at no spread
        {
            double bulletAngle = spread / (bullets - 1) * 2;
            for (int i = 0; i < bullets; i++) //every second bullet increments angle
            {
                if (i == 0) Shoot(0);
                else
                {
                    if (i % 2 == 0) Shoot(-Math.Ceiling((double)i / 2) * bulletAngle); //every second is negative
                    if (i % 2 == 1) Shoot(Math.Ceiling((double)i / 2) * bulletAngle);  //every second is positive
                }
            }

        }
    }
    public override void MovementScript()
    {
        base.MovementScript();
        angle = target.position - myrb.transform.position;  //finds the difference between our position, and the target position
        angle.Normalize();      //normalizes the angle (makes it into a 1vector)
        if ((Vector2.Distance(target.position, myrb.transform.position) < rangeOffset + range) &&   //If enemy is within range+offset
            Vector2.Distance(target.position, myrb.transform.position) > range)                     //And is further than range from target
            if (cooldown <= 0) StartCoroutine(AttackScript(null));                                         //Then enemy attacks
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
public abstract class EnemyBaseClass : MonoBehaviour
{
    public GameObject p1, p2;                  //gets player1 as a variable      //gets player2 as a variable      
    public float movementSpeed;         //makes a public startSpeed variable //makes a public movementSpeed variable
    public Transform target;                               //gest a target transform as a variable
    public Vector3 angle;                                  //makes a angle for movement
    public float cooldown;
    public Rigidbody2D myrb;
    public Animator animator;
    public bool alive;

    public EnemyBaseClass()
    {

        p1 = null;            //sets player1 as p1
        p2 = null;            //sets player2 as p2
        movementSpeed = 5;
        target = null;
        angle = new Vector3(0, 0, 0);
        cooldown = 2;
        myrb = null;
        alive = true;
}
    void Start()
    {
        p1 = GameObject.Find("Player1");
        p2 = GameObject.Find("Player2");
        myrb = GetComponent<Rigidbody2D>();
        myrb.freezeRotation = true;
        Physics2D.gravity = Vector2.zero;
        animator = GetComponent<Animator>();
        animator.Play("Spawn");
    }
    public void Update()
    {
        if (cooldown <= 0 && alive)
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
        animator.Play("Moving");
    }
    public abstract IEnumerator AttackScript(Collision collision);

    public IEnumerator Death()
    {
        alive = false;
        animator.Play("Death");
        yield return new WaitForSeconds(2);
        //insert reward here
        Destroy(gameObject);
    }

}
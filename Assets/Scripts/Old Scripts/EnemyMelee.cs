using UnityEngine;
using System.Timers;
using System;

/*public class MeleEnemy : MonoBehaviour
{
    public EnemyAI enemyAI;
    public EnemyHealthManager hpManager;
    public float cooldown = 3.0f;
    Timer cooldownTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hpManager = GetComponent<EnemyHealthManager>();
        enemyAI = GetComponent<EnemyAI>();
        enemyAI.distance = 0;
        cooldownTimer = new Timer(cooldown*1000);
        cooldownTimer.Elapsed += Attack;
    }
    private void Update()
    {
        cooldown -= Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //If enemy comes into contact with a player, they know
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Melee mode activated");      //enemy is attacking player
            collision.gameObject.GetComponent<PlayerHealthManager>().TakeDamage((int)1); //does 1 damage to player 
            cooldownTimer.Enabled = true;           //cooldown timer started
            enemyAI.still = true;
        }
    }
    private void Attack(object sender, ElapsedEventArgs e)
    {
        Debug.Log("We are so back");
        cooldownTimer.Enabled = false;
        enemyAI.MoveEnemy();
    }
}
*/
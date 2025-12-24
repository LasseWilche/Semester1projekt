using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerHealthManager : HealthManager
{
    [SerializeField] NewP2ShootScript player2;
    [SerializeField] P2ControllerWithRotationThatDidntWorkLol shootScript;
    [SerializeField] Meleescript melee;
    [SerializeField] P1Controller player1;
    public float invincibility;
    private Image[] Health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        invincibility = 0;
        currentHealth = maxHealth;
        gameManager = GameObject.Find("Main Camera").GetComponent<GameManager>();
        if (player2 != null)
        {
            animator = GameObject.Find("P2 with overheat/Sprite").GetComponent<Animator>();
        }
        else animator = GetComponent<Animator>();
        //healthBar.SetMaxHealth(maxHealth);    //Sets UI healthbar to max on start
        if (ScreenFader.Instance != null)
        {
            Health = new Image[3];
            if (player1 != null)
            {
                Health[0] = GameObject.Find("P1_HealthBar/1 Health").GetComponent<Image>();
                Health[1] = GameObject.Find("P1_HealthBar/2 Health").GetComponent<Image>();
                Health[2] = GameObject.Find("P1_HealthBar/3 Health").GetComponent<Image>();
            }
            else
            {
                Health[0] = GameObject.Find("P2_HealthBar/1 Health").GetComponent<Image>();
                Health[1] = GameObject.Find("P2_HealthBar/2 Health").GetComponent<Image>();
                Health[2] = GameObject.Find("P2_HealthBar/3 Health").GetComponent<Image>();
            }
        }
    }
    private void Update()
    {
        if (invincibility != 0) //if player is invincible we tick down depending on how much time has passed since last update
        {
            invincibility -= Time.deltaTime;
            if (invincibility < 0) invincibility = 0;
        }
    }
    public override void TakeDamage(int damage)
    {
        if (invincibility != 0) return; //if player is invincible we dont want to take damage
        invincibility = 1;
        SoundManager.PlaySound(SoundType.HURTINGSOUND1, 0.5f);
        if (damage <= 0) return;
        if (currentHealth <= 0) return;

        base.TakeDamage(damage);
        //healthBar.SetHealth(currentHealth);  //Modifies health bar UI
        if (ScreenFader.Instance != null) Health[currentHealth].gameObject.SetActive(false);
    }
    public override void DieAnimation()
    {
        if (player1 != null)
        {
            melee.Die();
            player1.Die();
        }
        else if (player2 != null)
        {
            player2.Die();
            shootScript.Die();
        }
        animator.Play("Dying");
        Invoke("Dying", 2.5f); //insert length of dying animation
    }
    public override void Dying()
    {
        if (gameManager.bothAlive == true) gameManager.bothAlive = false; //End the game;
        else gameManager.GameOver();
        if (player2 != null)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
        else Destroy(gameObject);
    }
}

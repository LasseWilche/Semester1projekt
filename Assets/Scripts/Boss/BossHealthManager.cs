using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthManager : MonoBehaviour
{
    public int maxHealth { get; private set; } = 50;
    public int currentHealth { get; private set; }
    public Slider hpSlider;
    public GameObject boss;
    public bool bossIsAlive { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        hpSlider.maxValue = maxHealth;
        bossIsAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
           Death();
        }
    }

    public void TakeDamage()
    {
        currentHealth -= 1;
    }

    public void Death()
    {
        bossIsAlive = false;
        Destroy(boss);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet") || collision.gameObject.CompareTag("PlayerMelee"))
        {
            TakeDamage();
            if (collision.gameObject.CompareTag("PlayerBullet"))
            {
                Destroy(collision.gameObject);
            }
        }
    }
}


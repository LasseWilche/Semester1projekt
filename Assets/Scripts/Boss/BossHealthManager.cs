using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthManager : MonoBehaviour
{
    public int maxHealth { get; private set; } = 50;
    private int currentHealth;
    public Slider hpSlider;
    public GameObject gameObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        hpSlider.maxValue = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.value = currentHealth;
    }

    public void TakeDamage()
    {
        currentHealth -= 1;
    }

    public void Death()
    {
        if (currentHealth <= 0)
        {
           Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet") || collision.gameObject.CompareTag("PlayerMelee"))
        {
            TakeDamage();
        }
    }
}


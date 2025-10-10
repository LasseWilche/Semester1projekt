using UnityEngine;

public class BossScript : MonoBehaviour
{
    //BOSS HEALTH VARIABLES
    public int bossMaxHealth;
    public int bossCurrentHealth;

    //BOSS ATTACK VARIABLES
     //Makes sure bullet gets destroyed after time


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bossCurrentHealth = bossMaxHealth;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void CircleAttack()
    {
        while (bossCurrentHealth > 0)
        {
            for (int i = 0; i < 13; i++)
            {
                
            }
            Instantiate(bullet, Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}

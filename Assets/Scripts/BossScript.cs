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
}

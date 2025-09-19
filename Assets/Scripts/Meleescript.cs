using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meleescript : MonoBehaviour
{
    [SerializeField] private Animator anim;

    [SerializeField] private float meleeSpeed;

    [SerializeField] private float damage; 

    float timeUntilMelee;

    private void Update()
    {
        if ((timeUntilMelee <= 0f)) // Check if the timer has reached zero
        {
            if (Input.GetKey(KeyCode.Space)) // Change to your desired key
            {
                anim.SetTrigger("Attack"); // Trigger the attack animation
                timeUntilMelee = meleeSpeed; // Reset the timer
            }
        }
        else
        {
            timeUntilMelee -= Time.deltaTime; // Decrease the timer
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            //other.GetComponent<Enemy>().TakeDamage(damage);
            Debug.Log("enemy hit");
        }
    }





}


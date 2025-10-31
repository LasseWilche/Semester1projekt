using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyHealthManager : HealthManager
{
    public override void DieAnimation()
    {
        animator.Play("Dying");
        //insert charge function
        Invoke("Dying", 3f); //insert length of dying animation
    }
    public override void Dying()
    {
        Debug.Log("Monster die");
        Destroy(gameObject);
    }
}

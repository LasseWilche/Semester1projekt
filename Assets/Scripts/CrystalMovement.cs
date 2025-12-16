using System.Collections;
using UnityEngine;

public class CrystalMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    // Update is called once per frame
    void Update()
    {

    }
    public void StartCrystal()
    {
        if (rb.linearVelocityY == 0)
        {
            rb.linearVelocityY = 0.3f;
            StartCoroutine(ChangeVelocity());
        }
    }
    IEnumerator ChangeVelocity()
    {
        while (true)
        {
        Debug.Log("Gege");
        rb.linearVelocityY *= -1;
        yield return new WaitForSeconds(1f);
        }
    }
}

using UnityEngine;
public class EnemyBulletScript : BasicBulletScript
{
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("hit");
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Player")) Destroy(this.gameObject);
    }
}

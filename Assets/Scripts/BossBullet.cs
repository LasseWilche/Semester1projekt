using UnityEngine;

public class BossBullet : MonoBehaviour
{
    private float speed;
    private Vector2 direction;

    public void Initialize(float bulletSpeed, Vector2 bulletDirection)
    {
        speed = bulletSpeed;
        direction = bulletDirection;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}

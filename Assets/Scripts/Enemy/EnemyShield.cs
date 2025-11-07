using UnityEngine;

public class EnemyShield : MonoBehaviour
{
    private GameObject shieldVisual;
    private int hitCount = 0;
    private int maxHits = 3;
    private string allowedPlayerTag = "Player1Bullet"; // default
    private SpriteRenderer spriteRenderer;

    public void SetupShield(GameObject shieldPrefab, Sprite shieldSprite)
    {
        if (shieldPrefab == null)
        {
            Debug.LogError("Shield prefab missing.");
            return;
        }

        // Instantiate visual as child
        shieldVisual = Instantiate(shieldPrefab, transform);
        shieldVisual.transform.localPosition = Vector3.zero;
        spriteRenderer = shieldVisual.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = shieldSprite;
        spriteRenderer.sortingOrder = 10;

        // Determine which player can break it
        if (shieldPrefab.name.ToLower().Contains("player1"))
        {
            allowedPlayerTag = "Player1Bullet";
            maxHits = 2;
        }
        else
        {
            allowedPlayerTag = "Player2Bullet";
            maxHits = 3;
        }

        // Add trigger collider for hits if not already present
        var collider = shieldVisual.GetComponent<Collider2D>();
        if (collider == null)
        {
            collider = shieldVisual.AddComponent<CircleCollider2D>();
        }
        collider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(allowedPlayerTag)) return;

        hitCount++;
        if (hitCount >= maxHits)
        {
            Destroy(shieldVisual);
            Destroy(this); // remove shield component
        }
    }
}

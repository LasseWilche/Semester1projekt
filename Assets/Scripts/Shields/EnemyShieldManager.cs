using UnityEngine;

public class EnemyShieldManager : MonoBehaviour
{
    [Header("Shield Settings")]
    public GameObject shieldPrefab;        // Prefab with animator + sprite renderer
    public int shieldHP = 0;               // Set dynamically by LevelSpawner
    public float shieldOpacity = 0.5f;     // Set dynamically by LevelSpawner
    public float animationSpeed = 1f;      // Set dynamically by LevelSpawner

    private ShieldController shieldInstance;

    /// <summary>
    /// Returns true if the enemy currently has a shield instance.
    /// </summary>
    public bool HasShield => shieldInstance != null;

    /// <summary>
    /// Called directly by LevelSpawner to apply a shield to this enemy.
    /// </summary>
    public void ApplyShield(int hp, float opacity, float animSpeed)
    {
        // Already shielded
        if (shieldInstance != null) return;

        // Prefab missing
        if (shieldPrefab == null)
        {
            Debug.LogWarning("Shield Prefab missing on EnemyShieldManager!");
            return;
        }

        // Spawn shield as child of enemy
        GameObject shieldObj = Instantiate(shieldPrefab, transform);
        shieldObj.transform.localPosition = Vector3.zero;

        // Setup sorting
        SpriteRenderer enemySR = GetComponent<SpriteRenderer>();
        SpriteRenderer shieldSR = shieldObj.GetComponent<SpriteRenderer>();

        if (enemySR != null && shieldSR != null)
        {
            shieldSR.sortingLayerID = enemySR.sortingLayerID;
            shieldSR.sortingOrder = enemySR.sortingOrder + 10;  // Always on top
        }

        // Grab component
        shieldInstance = shieldObj.GetComponent<ShieldController>();

        // Apply values
        shieldInstance.shieldHP = hp;
        shieldInstance.opacity = opacity;
        shieldInstance.animationSpeed = animSpeed;
    }

    /// <summary>
    /// External damage interface (called by projectiles).
    /// </summary>
    public void DamageShield()
    {
        if (shieldInstance != null)
        {
            shieldInstance.DamageShield();
        }
    }
}

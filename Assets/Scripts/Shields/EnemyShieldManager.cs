using UnityEngine;

public class EnemyShieldManager : MonoBehaviour
{
    [Header("Shield Setup")]
    public GameObject shieldPrefab;      // The shield object prefab
    public Transform shieldParent;       // Where the shield should be attached

    private GameObject activeShield;     // The instantiated shield
    private ShieldBehaviour shieldBehaviour;

    public void ApplyShield(int hp, float opacity, float animSpeed)
    {
        if (shieldPrefab == null || shieldParent == null)
        {
            Debug.LogError("ShieldManager missing prefab or parent!");
            return;
        }

        // Spawn the shield
        activeShield = Instantiate(shieldPrefab, shieldParent.position, Quaternion.identity, shieldParent);

        // Set behaviour
        shieldBehaviour = activeShield.GetComponent<ShieldBehaviour>();
        shieldBehaviour.Initialize(hp, opacity, animSpeed, this.gameObject);
    }

    // Called by the ShieldBehaviour when the shield breaks
    public void ShieldDestroyed()
    {
        // Re-enable taking damage on this enemy
        EnemyHealthManager enemyHealth = GetComponent<EnemyHealthManager>(); // <-- Replace with your real health script name

        if (enemyHealth != null)
            enemyHealth.shieldActive = false;  // Your enemies must have a "public bool shieldActive"

        activeShield = null;
    }
}

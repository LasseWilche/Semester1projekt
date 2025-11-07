using UnityEngine;
using System.Collections.Generic;

public class EnemyShieldManager : MonoBehaviour
{
    [Header("Shield Settings")]
    [Tooltip("Chance (0–1) that a spawned enemy gets a shield.")]
    [Range(0f, 1f)] public float shieldChance = 0.2f;

    [Tooltip("How many guaranteed shields must spawn per level.")]
    public int shieldGuarantee = 3;

    [Tooltip("Prefab for shields that only Player1 can damage.")]
    public GameObject player1ShieldPrefab;

    [Tooltip("Prefab for shields that only Player2 can damage.")]
    public GameObject player2ShieldPrefab;

    [Tooltip("Sprite displayed on the shielded enemy.")]
    public Sprite shieldSprite;

    private LevelSpawner levelSpawner;
    private int shieldsSpawned = 0;

    private void Awake()
    {
        levelSpawner = GetComponent<LevelSpawner>();
        if (levelSpawner == null)
        {
            Debug.LogError("EnemyShieldManager requires LevelSpawner on the same GameObject.");
        }
    }

    /// <summary>
    /// Called from LevelSpawner when an enemy is spawned.
    /// </summary>
    public void TryApplyShield(GameObject enemyInstance, int remainingWeight)
    {
        if (enemyInstance == null) return;

        bool forceShield = false;

        // Force shield if not enough shields spawned and we are nearing end of level
        if (shieldsSpawned < shieldGuarantee && remainingWeight <= 3 * (shieldGuarantee - shieldsSpawned))
        {
            forceShield = true;
        }

        bool shouldShield = forceShield || (Random.value <= shieldChance);
        if (!shouldShield) return;

        // Pick which shield type
        GameObject chosenShieldPrefab = Random.value < 0.5f ? player1ShieldPrefab : player2ShieldPrefab;

        // Attach shield component to enemy
        var shield = enemyInstance.AddComponent<EnemyShield>();
        shield.SetupShield(chosenShieldPrefab, shieldSprite);

        shieldsSpawned++;
    }

    public void ResetShields()
    {
        shieldsSpawned = 0;
    }
}

using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    [Header("Spawners")]
    public enemySpawner[] spawners;

    private enemySpawner lastSpawner = null;

    [Header("Enemy Types & Weights")]
    public GameObject[] enemyPrefabs;
    public int[] enemyWeights;

    [Header("Chance Weights (lower = rarer, higher = more common)")]
    public float[] enemyChanceModifiers;

    [Header("Level Settings")]
    public int levelWeight = 20; // enemy cost budget for this level
    public int maxEnemies = 10; // maximum enemies alive at one time

    private int currentWeight = 0;
    private float spawnTimer = 0f;

    [Header("Spawn Timing")]
    public float spawnInterval = 10f; // spawns 3 enemies at once every 10 sec
    public int batchSpawnCount = 3;   // spawn 3 per wave

    [Header("Shield Settings")]
    public int shieldHP = 3;
    public float shieldOpacity = 0.5f;
    public float shieldAnimSpeed = 1.0f;
    public float shieldChancePercent = 20f; // 20% chance per enemy

    private void Start()
    {
        if (enemyPrefabs.Length != enemyWeights.Length ||
            enemyPrefabs.Length != enemyChanceModifiers.Length)
        {
            Debug.LogError("Enemy arrays must be the same length!");
        }
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;
            AttemptSpawnBatch();
        }
    }

    private void AttemptSpawnBatch()
    {
        for (int i = 0; i < batchSpawnCount; i++)
        {
            if (currentWeight >= levelWeight)
                return;

            if (enemySpawner.activeEnemies >= maxEnemies)
                return;

            SpawnWeightedEnemy();
        }
    }

    private void SpawnWeightedEnemy()
    {
        GameObject chosenEnemy = PickWeightedEnemy(out int weightCost);

        if (chosenEnemy == null)
            return;

        // Prevent exceeding level weight
        if (currentWeight + weightCost > levelWeight)
            return;

        // Pick spawner (cannot repeat same one twice)
        enemySpawner chosenSpawner = PickSpawner();

        if (chosenSpawner == null)
            return;

        GameObject enemyInstance = chosenSpawner.SpawnEnemy(chosenEnemy);

        currentWeight += weightCost;

        // Apply shield based on random chance
        TryAssignShield(enemyInstance);
    }

    private GameObject PickWeightedEnemy(out int weightCost)
    {
        weightCost = 0;

        // Build the weighted list dynamically
        List<GameObject> weightedList = new List<GameObject>();
        List<int> weightList = new List<int>();

        for (int i = 0; i < enemyPrefabs.Length; i++)
        {
            weightList.Add(enemyWeights[i]);

            int weightCount = Mathf.RoundToInt(enemyChanceModifiers[i] * 10);

            for (int k = 0; k < weightCount; k++)
                weightedList.Add(enemyPrefabs[i]);
        }

        if (weightedList.Count == 0)
            return null;

        // Choose randomly
        GameObject chosen = weightedList[Random.Range(0, weightedList.Count)];

        // Assign cost
        int index = System.Array.IndexOf(enemyPrefabs, chosen);
        weightCost = enemyWeights[index];

        return chosen;
    }

    private enemySpawner PickSpawner()
    {
        if (spawners.Length == 0)
            return null;

        List<enemySpawner> validSpawners = new List<enemySpawner>();

        foreach (var spawner in spawners)
        {
            if (spawner != lastSpawner)
                validSpawners.Add(spawner);
        }

        enemySpawner chosen = validSpawners[Random.Range(0, validSpawners.Count)];
        lastSpawner = chosen;

        return chosen;
    }

    private void TryAssignShield(GameObject enemy)
    {
        if (enemy == null) return;

        // Random chance
        if (Random.Range(0f, 100f) > shieldChancePercent)
            return;

        EnemyShieldManager shield = enemy.GetComponent<EnemyShieldManager>();

        if (shield == null)
            return;

        shield.ApplyShield(shieldHP, shieldOpacity, shieldAnimSpeed);
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class EnemyType
{
    [Header("Enemy Settings")]
    public GameObject prefab;

    [Tooltip("How much of the level weight this enemy consumes.")]
    public int weight = 1;

    [Tooltip("Higher = more likely to spawn. Example: Follow = 3, Sniper = 1.")]
    public float chanceWeight = 1f;
}

public class LevelSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public enemySpawner[] spawners;     // Your corner spawners
    public int maxEnemies = 20;         // Max enemies alive at once
    public float spawnInterval = 10f;   // Time between waves
    public int enemiesPerWave = 3;      // How many spawn per wave

    [Header("Level Settings")]
    public int levelWeight = 20;        // Total "budget" for this level
    public EnemyType[] enemyTypes;      // Enemy prefabs with weight + chanceWeight

    private int currentWeight = 0;
    private int lastSpawnerIndex = -1;
    private int sameSpawnerCount = 0;

    private EnemyShieldManager shieldManager; // Reference to shield system

    private void Awake()
    {
        shieldManager = GetComponent<EnemyShieldManager>();
    }

    private void Start()
    {
        if (spawners == null || spawners.Length == 0)
        {
            Debug.LogError("No spawners assigned to LevelSpawner!");
            return;
        }

        if (enemyTypes == null || enemyTypes.Length == 0)
        {
            Debug.LogError("No enemy types assigned to LevelSpawner!");
            return;
        }

        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            int totalActive = GetTotalActiveEnemies();

            if (totalActive < maxEnemies && currentWeight < levelWeight)
            {
                SpawnWave();
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnWave()
    {
        int spawnedThisWave = 0;
        List<int> usedSpawners = new List<int>();

        while (spawnedThisWave < enemiesPerWave && currentWeight < levelWeight)
        {
            // Valid spawners (not reused this wave)
            List<int> validSpawners = new List<int>();
            for (int i = 0; i < spawners.Length; i++)
            {
                if (!usedSpawners.Contains(i))
                    validSpawners.Add(i);
            }

            if (validSpawners.Count == 0)
                break;

            int spawnerIndex = ChooseSpawner(validSpawners);
            enemySpawner chosenSpawner = spawners[spawnerIndex];
            usedSpawners.Add(spawnerIndex);

            int remainingWeight = levelWeight - currentWeight;
            EnemyType chosenEnemy = ChooseWeightedEnemy(remainingWeight);

            if (chosenEnemy == null)
                break;

            // --- Spawn and get instance ---
            GameObject enemyInstance = chosenSpawner.SpawnEnemy(chosenEnemy.prefab);
            if (enemyInstance != null && shieldManager != null)
            {
                shieldManager.TryApplyShield(enemyInstance, remainingWeight);
            }

            currentWeight += chosenEnemy.weight;
            spawnedThisWave++;
        }

        Debug.Log($"Wave spawned {spawnedThisWave} enemies (Weight: {currentWeight}/{levelWeight})");
    }

    private EnemyType ChooseWeightedEnemy(int remainingWeight)
    {
        // Filter enemies that fit within remaining weight
        List<EnemyType> validEnemies = new List<EnemyType>();
        foreach (var e in enemyTypes)
        {
            if (e.weight <= remainingWeight)
                validEnemies.Add(e);
        }

        if (validEnemies.Count == 0)
            return null;

        // Total chance weight
        float totalChance = 0f;
        foreach (var e in validEnemies)
        {
            totalChance += Mathf.Max(0.01f, e.chanceWeight);
        }

        float randomPoint = Random.value * totalChance;
        float cumulative = 0f;

        foreach (var e in validEnemies)
        {
            cumulative += Mathf.Max(0.01f, e.chanceWeight);
            if (randomPoint <= cumulative)
                return e;
        }

        return validEnemies[validEnemies.Count - 1];
    }

    private int ChooseSpawner(List<int> validSpawners)
    {
        int spawnerIndex;
        int attempts = 0;

        do
        {
            spawnerIndex = validSpawners[Random.Range(0, validSpawners.Count)];
            attempts++;

            if (spawnerIndex == lastSpawnerIndex)
                sameSpawnerCount++;
            else
                sameSpawnerCount = 1;

        } while (sameSpawnerCount > 1 && attempts < 20);

        lastSpawnerIndex = spawnerIndex;
        return spawnerIndex;
    }

    private int GetTotalActiveEnemies()
    {
        int total = 0;
        foreach (var spawner in spawners)
        {
            total += spawner.activeEnemies;
        }
        return total;
    }
}

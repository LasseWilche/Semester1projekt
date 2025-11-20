using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
public class EnemySpawnManager : MonoBehaviour
{
    [Header("Spawner Settings")] //cool header to segment variables in unity
    public enemySpawner[] spawners; // array to setup spawners
    public float spawnInterval = 5f; //seconds inbetween each enemy spawner activating
    public int maxEnemies = 10; // max enemies at a time)
 
    [Header("Enemy Types")]
    public GameObject[] enemyPrefabs; // add all enemy prefabs here in the inspector
 
    private int lastSpawnerIndex = -1;
    private int sameSpawnerCount = 0;
 
    private void Start()
    {
        if (spawners == null || spawners.Length == 0) //checks if we forgot to add spawners
        {
            Debug.LogError("No spawners assigned to EnemySpawnManager!");
            return;
        }
 
        if (enemyPrefabs == null || enemyPrefabs.Length == 0) //checks if we have assigned enemy prefabs in the spawn manager
        {
            Debug.LogError("No enemy prefabs assigned to EnemySpawnManager!");
            return;
        }
 
        StartCoroutine(SpawnLoop());
    }
 
    private IEnumerator SpawnLoop() //while loop to spawn enemies at a random spawner every spawn interval
    {
        while (true)
        {
            int totalActive = GetTotalActiveEnemies();
            if (totalActive < maxEnemies)
            {
                enemySpawner chosenSpawner = ChooseSpawner();
                GameObject enemyPrefab = ChooseEnemyType();
 
                if (chosenSpawner != null && enemyPrefab != null)
                {
                    chosenSpawner.SpawnEnemy(enemyPrefab);
                }
            }
 
            yield return new WaitForSeconds(spawnInterval);
        }
    }
 
    private enemySpawner ChooseSpawner() //loop to keep track of which active spawner we use and that it cant spawn enemies more than twice in a row. 
    {
        int spawnerIndex;
        int attempts = 0;
 
        do
        {
            spawnerIndex = Random.Range(0, spawners.Length);
            attempts++;
 
            if (spawnerIndex == lastSpawnerIndex)
                sameSpawnerCount++;
            else
                sameSpawnerCount = 1;
 
        } while (sameSpawnerCount > 2 && attempts < 20);
 
        lastSpawnerIndex = spawnerIndex;
        return spawners[spawnerIndex];
    }
 
    private GameObject ChooseEnemyType() //choosing a random enemy (can be updated to match enemy weights fx.)
    {
        if (enemyPrefabs.Length == 0) return null;
 
        int index = Random.Range(0, enemyPrefabs.Length);
        return enemyPrefabs[index];
    }
 
    private int GetTotalActiveEnemies() //active enemies tracker to stop at a global maximum
    {
        int total = 0;
        foreach (var spawner in spawners)
        {
            total += enemySpawner.activeEnemies;
        }
        return total;
    }
}

using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [HideInInspector] public int activeEnemies = 0;

    public GameObject SpawnEnemy(GameObject enemyPrefab)
    {
        if (enemyPrefab == null)
        {
            Debug.LogError("No enemy prefab provided to spawner.");
            return null;
        }

        GameObject enemyInstance = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        activeEnemies++;

        // Optional: add a callback to reduce activeEnemies when enemy dies
        // (you can handle this via an EnemyDeath script later)

        return enemyInstance;
    }
}

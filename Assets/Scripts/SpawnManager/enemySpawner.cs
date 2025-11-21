using System.Runtime.CompilerServices;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [Header("Tracking")]
    public int activeEnemies = 0;
    public GameObject wallSpawnerTeal = null;
    public GameObject wallSpawnerGreen = null;

    // chosen enemy spawned
    // return type changed to GameObject so other systems (LevelSpawner, ShieldManager) can use the spawned enemy
    public GameObject SpawnEnemy(GameObject enemyPrefab)
    {
        if (enemyPrefab == null)
        {
            Debug.LogWarning("Tried to spawn with a null enemyPrefab!");
            return null;
        }

        // Active wall spawn tile
        if (wallSpawnerGreen != null)   // if we haven't set any spawners, we are not near the wall
        {
            // if enemy has the followtype script, we use teal tiles, otherwise we use green
            if (enemyPrefab.GetComponent<FollowType>() != null)
                wallSpawnerTeal.SetActive(true);
            else
                wallSpawnerGreen.SetActive(true);
        }

        GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

        activeEnemies++;

        // tracking within the spawner (if we wanna have spawner limits later down the line)
        EnemyTracker tracker = newEnemy.AddComponent<EnemyTracker>();
        tracker.spawner = this;

        return newEnemy;   // <--- REQUIRED FIX
    }

    // tracking if enemy dies
    public void OnEnemyDestroyed()
    {
        activeEnemies = Mathf.Max(0, activeEnemies - 1);
    }
}

// can be used to setup new spawn if enemy is destroyed
public class EnemyTracker : MonoBehaviour
{
    public enemySpawner spawner;

    private void OnDestroy()
    {
        if (spawner != null)
        {
            spawner.OnEnemyDestroyed();
        }
    }
}

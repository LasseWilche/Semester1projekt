using UnityEngine;
 
public class enemySpawner : MonoBehaviour
{
    [Header("Tracking")]
    public int activeEnemies = 0; 
 
//chosen enemy spawned
    public void SpawnEnemy(GameObject enemyPrefab)
    {
        if (enemyPrefab == null)
        {
            Debug.LogWarning("Tried to spawn with a null enemyPrefab!");
            return;
        }
 
        GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
 
        activeEnemies++;
 
        //tracking within the spawner (if we wanna have spawner limits later down the line). 
        EnemyTracker tracker = newEnemy.AddComponent<EnemyTracker>();
        tracker.spawner = this;
    }
 
//tracking if enemy dies
    public void OnEnemyDestroyed()
    {
        activeEnemies = Mathf.Max(0, activeEnemies - 1);
    }
}
 
//can be used to setup new spawn if enemy is destroyed
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